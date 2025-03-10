using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using dnd_infra.Campaigns;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class PlayersRepository(GlobalDbContext context, PlayersFactory playersFactory) : IPlayersRepository
{
    private readonly GlobalDbContext _context = context;
    private readonly PlayersFactory _playersFactory = playersFactory;

    public Task<List<Player>> GetAsync(int userId)
        => _context.Players
            .Include(p => p.Profile)
            .Include(p => p.MaxAttributes)
            .Include(p => p.Square)
                .ThenInclude(s => s.Position)
            .Where(p => p.UserId == userId)
            .Select(h => h.ToDomain())
            .ToListAsync();

    public async Task<Player> GetByIdAsync(int id)
    {
        PlayerDal player = await _context.Players
            .Include(p => p.Profile)
            .Include(p => p.Attributes)
            .Include(p => p.MaxAttributes)
            .Include(p => p.StoredItems)
            .Include(p => p.TurnOrder)
             .Include(p => p.Square)
                .ThenInclude(s => s.Position)
            .FirstAsync(p => p.Id == id);

        return player.ToDomain();
    }

    public async Task<Player> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload)
    {
        PlayerDal player = PlayersFactory.ForgePlayer(userId, playerCreationPayload);

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return player.ToDomain();
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

    public Task<bool> UserNameExistsAsync(string name)
        => _context.Players.AnyAsync(p => p.Profile.Name == name);

    public Task<bool> ExistsAsync(int id)
        => _context.Players.AnyAsync(p => p.Profile.Id == id);

    public Task<bool> AreAvailableAsync(IEnumerable<int> playerIds)
        => _context.Players.Where(p => playerIds.Contains(p.Id))
                           .AllAsync(p => p.CampaignId == null && p.IsAvailable);

    public Task SeedMonstersAsync(int campaignId, int adventureId)
        => _playersFactory.ForgeMonstersFromAdventureAsync(campaignId, adventureId);

    public async Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload)
    {
        CampaignDal campaign = await _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .FirstAsync(c => c.Id == campaignId);

        List<PlayerDal> monsters = campaign.Players
            .Where(p => p.Profile.Role == PlayerRole.Monster)
            .ToList();

        foreach (PlayerDal player in monsters)
        {
            player.UserId = userId;
        }

        await _context.SaveChangesAsync();
    }

    private static void UpdatePlayer(PlayerDal dal, PlayerPayload playerPayload)
    {
        dal.Attributes!.LifePoints = playerPayload.LifePoints ?? dal.Attributes.LifePoints;
        dal.Attributes.ManaPoints = playerPayload.ManaPoints ?? dal.Attributes.ManaPoints;
        dal.Attributes.FootSteps = playerPayload.FootSteps ?? dal.Attributes.FootSteps;
        dal.Attributes.Shield = playerPayload.Shield ?? dal.Attributes.Shield;
        dal.Profile.ImageUrl = playerPayload.ImageUrl ?? dal.Profile.ImageUrl;
    }
}
