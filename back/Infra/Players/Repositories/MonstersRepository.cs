using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class MonstersRepository : IMonstersRepository
{
    private readonly GlobalDbContext _context;

    public MonstersRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<Monster>> GetAsync(int campaignId)
        => _context.Monsters
            .Where(m => m.CampaignId == campaignId)
            .Select(m => m.ToDomain())
            .ToListAsync();

    public async Task<Monster> AttackAsync(int id, AttackPayload attack)
    {
        MonsterDal monster = await _context.Monsters.SingleAsync(h => h.Id == id);

        int lostLifePoints = ComputeLostLifePoints(attack, monster.Shield);

        monster.LifePoints -= lostLifePoints;

        if (monster.LifePoints <= 0)
        {
            monster.LifePoints = 0;
            monster.IsDead = true;
        }

        await _context.SaveChangesAsync();
        return monster.ToDomain();
    }

    public async Task<Monster> UpdateAsync(int id, PlayerPayload monsterPayload)
    {
        MonsterDal dal = await _context.Monsters.SingleAsync(h => h.Id == id);
        UpdateMonster(dal, monsterPayload);
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

    private static void UpdateMonster(MonsterDal dal, PlayerPayload monsterPayload)
    {
        dal.LifePoints = monsterPayload.LifePoints ?? dal.LifePoints;
        dal.ManaPoints = monsterPayload.ManaPoints ?? dal.ManaPoints;
        dal.FootSteps = monsterPayload.FootSteps ?? dal.FootSteps;
        dal.Shield = monsterPayload.Shield ?? dal.Shield;
        dal.ImageUrl = monsterPayload.ImageUrl ?? dal.ImageUrl;
    }
}
