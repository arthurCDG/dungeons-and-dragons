using dnd_domain.Campaigns.Adventures;
using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Campaigns;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class PlayersRepository : IPlayersRepository
{
    private readonly GlobalDbContext _context;
    private readonly PlayersFactory _playersFactory;

    public PlayersRepository(GlobalDbContext context, PlayersFactory playersFactory)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _playersFactory = playersFactory ?? throw new ArgumentNullException(nameof(playersFactory));
    }

    public Task<List<Player>> GetAsync(int userId)
        => _context.Players
            .Include(p => p.Profile)
            .Include(p => p.MaxAttributes)
            .Where(p => p.UserId == userId)
            .Select(h => h.ToDomain())
            .ToListAsync();

    public Task<Player> GetByIdAsync(int id)
        => _context.Players
            .Include(p => p.Profile)
            .Include(p => p.Attributes)
            .Include(p => p.MaxAttributes)
            .Include(p => p.StoredItems)
            .Include(p => p.TurnOrder)
            .Where(h => h.Id == id)
            .Select(h => h.ToDomain())
            .SingleAsync();

    public async Task<Player> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload)
    {
        PlayerDal player = await _playersFactory.ForgePlayerAsync(userId, playerCreationPayload);

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return player.ToDomain();
    }

    public Task SeedMonstersAsync(int campaignId, AdventureType type)
        => _playersFactory.ForgeMonstersFromAdventureAsync(campaignId, type);

    public async Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload)
    {
        CampaignDal campaign = await _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .FirstAsync(c => c.Id == campaignId);

        List<PlayerDal> players = campaign.Players
            .Where(p => p.Profile.MonsterType != null)
            .ToList();

        foreach (PlayerDal player in players)
        {
            player.UserId = userId;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Player> UpdateAsync(int id, PlayerPayload playerPayload)
    {
        PlayerDal dal = await _context.Players
            .Include(p => p.Attributes)
            .Include(p => p.Profile)
            .SingleAsync(h => h.Id == id);

        UpdatePlayer(dal, playerPayload);
        return dal.ToDomain();
    }

    private static void UpdatePlayer(PlayerDal dal, PlayerPayload playerPayload)
    {
        dal.Attributes!.LifePoints = playerPayload.LifePoints ?? dal.Attributes.LifePoints;
        dal.Attributes.ManaPoints = playerPayload.ManaPoints ?? dal.Attributes.ManaPoints;
        dal.Attributes.FootSteps = playerPayload.FootSteps ?? dal.Attributes.FootSteps;
        dal.Attributes.Shield = playerPayload.Shield ?? dal.Attributes.Shield;
        dal.Profile.ImageUrl = playerPayload.ImageUrl ?? dal.Profile.ImageUrl;
    }

    public async Task<Player> AttackAsync(int id, AttackPayload attack)
    {
        PlayerDal player = await _context.Players
            .Include(p => p.Attributes)
            .SingleAsync(h => h.Id == id);

        int lostLifePoints = ComputeLostLifePoints(attack, player.Attributes!.Shield);

        player.Attributes.LifePoints -= lostLifePoints;

        if (player.Attributes.LifePoints <= 0)
        {
            player.Attributes.LifePoints = 0;
            player.IsDead = true;
        }

        await _context.SaveChangesAsync();

        return player.ToDomain();
    }

    private static int ComputeLostLifePoints(AttackPayload attack, int shield)
    {
        if (attack.MeleeAttack is not null)
        {
            return Math.Abs(shield - attack.MeleeAttack ?? 0);
        }
        else
        {
            return attack.RangeAttack ?? 0;
        }
    }
}
