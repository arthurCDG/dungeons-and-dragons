using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
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

    public PlayersRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<Player>> GetAsync(int adventureId)
        => _context.Players
            .Include(p => p.Profile)
            .Include(p => p.Attributes)
            .Include(p => p.MaxAttributes)
            .Include(p => p.StoredItems)
            .Include(p => p.TurnOrder)
            .Where(h => h.AdventureId == adventureId)
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

    public async Task<Player> AttackAsync(int id, AttackPayload attack)
    {
        PlayerDal player = await _context.Players
            .Include(p => p.Attributes)
            .SingleAsync(h => h.Id == id);

        int lostLifePoints = ComputeLostLifePoints(attack, player.Attributes.Shield);

        player.Attributes.LifePoints -= lostLifePoints;

        if (player.Attributes.LifePoints <= 0)
        {
            player.Attributes.LifePoints = 0;
            player.IsDead = true;
        }

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

    private static void UpdatePlayer(PlayerDal dal, PlayerPayload playerPayload)
    {
        dal.Attributes.LifePoints = playerPayload.LifePoints ?? dal.Attributes.LifePoints;
        dal.Attributes.ManaPoints = playerPayload.ManaPoints ?? dal.Attributes.ManaPoints;
        dal.Attributes.FootSteps = playerPayload.FootSteps ?? dal.Attributes.FootSteps;
        dal.Attributes.Shield = playerPayload.Shield ?? dal.Attributes.Shield;
        dal.Profile.ImageUrl = playerPayload.ImageUrl ?? dal.Profile.ImageUrl;
    }
}
