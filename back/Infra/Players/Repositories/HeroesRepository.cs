using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class HeroesRepository : IHeroesRepository
{
    private readonly GlobalDbContext _context;

    public HeroesRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<Hero>> GetAsync(int campaignId)
        => _context.Heroes
            .Where(h => h.CampaignId == campaignId)
            .Select(h => h.ToDomain())
            .ToListAsync();

    public async Task<Hero> AttackAsync(int id, AttackPayload attack)
    {
        HeroDal hero = await _context.Heroes.SingleAsync(h => h.Id == id);

        int lostLifePoints = ComputeLostLifePoints(attack, hero.Shield);

        hero.LifePoints -= lostLifePoints;

        if (hero.LifePoints <= 0)
        {
            hero.LifePoints = 0;
            hero.IsDead = true;
        }

        await _context.SaveChangesAsync();

        return hero.ToDomain();
    }

    public async Task<Hero> UpdateAsync(int id, PlayerPayload heroPayload)
    {
        HeroDal dal = await _context.Heroes.SingleAsync(h => h.Id == id);
        UpdateHero(dal, heroPayload);
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

    private static void UpdateHero(HeroDal dal, PlayerPayload heroPayload)
    {
        dal.LifePoints = heroPayload.LifePoints ?? dal.LifePoints;
        dal.ManaPoints = heroPayload.ManaPoints ?? dal.ManaPoints;
        dal.FootSteps = heroPayload.FootSteps ?? dal.FootSteps;
        dal.Shield = heroPayload.Shield ?? dal.Shield;
        dal.ImageUrl = heroPayload.ImageUrl ?? dal.ImageUrl;
    }
}
