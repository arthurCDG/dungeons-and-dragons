using dnd_domain.GameFlow.Models;
using dnd_domain.GameFlow.Repositories;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.GameFlow.Repositories;

internal sealed class TurnFlowRepository : ITurnFlowRepository
{
    private readonly GlobalDbContext _context;

    public TurnFlowRepository(GlobalDbContext dbContext)
    {
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<CurrentPlayer> GetCurrentPlayerAsync(int campaignId)
    {
        CurrentPlayerDal currentPlayer = await GetCurrentPlayerDalAsync(campaignId);
        return currentPlayer!.ToDomain();
    }

    private async Task<CurrentPlayerDal> GetCurrentPlayerDalAsync(int campaignId)
    {
        CurrentPlayerDal? currentPlayer = await _context.CurrentPlayers
            .Include(cp => cp.Hero)
            .Include(cp => cp.Monster)
            .FirstOrDefaultAsync(cp => cp.CampaignId == campaignId);

        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(campaignId);
        currentPlayer ??= await CreateCurrentPlayerAsync(campaignId, turnOrders);

        return currentPlayer!;
    }

    public async Task<CurrentPlayer> GetNextCurrentPlayerAsync(int campaignId)
    {
        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(campaignId);
        
        CurrentPlayerDal currentPlayer = await GetCurrentPlayerDalAsync(campaignId);

        int currentTurnOrder;
        if (currentPlayer.HeroId is not null)
        {
            currentTurnOrder = turnOrders.Single(to => to.HeroId == currentPlayer.HeroId).Order;
        }
        else
        {
            currentTurnOrder = turnOrders.Single(to => to.MonsterId == currentPlayer.MonsterId).Order;
        }

        TurnOrderDal nextTurnOrder = turnOrders.FirstOrDefault(to => to.Order > currentTurnOrder) ?? turnOrders.First();
        CurrentPlayerDal nextCurrentPlayer = ForgeNextCurrentPlayerDal(nextTurnOrder, campaignId);
        
        _context.CurrentPlayers.Remove(currentPlayer);
        await _context.SaveChangesAsync();
        
        return nextCurrentPlayer.ToDomain();
    }

    private CurrentPlayerDal ForgeNextCurrentPlayerDal(TurnOrderDal nextTurnOrder, int campaignId)
    {
        if (nextTurnOrder.HeroId is not null)
        {
            CurrentPlayerDal nextCurrentPlayer = new()
            {
                HeroId = nextTurnOrder.HeroId,
                CampaignId = campaignId
            };
            _context.Add(nextCurrentPlayer);
            return nextCurrentPlayer;
        }
        else
        {
            CurrentPlayerDal nextCurrentPlayer = new()
            {
                MonsterId = nextTurnOrder.MonsterId,
                CampaignId = campaignId
            };
            _context.Add(nextCurrentPlayer);
            return nextCurrentPlayer;
        }
    }

    public async Task EnableCurrentPlayerAsync(int campaignId)
    {
        CurrentPlayerDal? currentPlayer = await _context.CurrentPlayers.FirstOrDefaultAsync(cp => cp.CampaignId == campaignId);
        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(campaignId);
        currentPlayer ??= await CreateCurrentPlayerAsync(campaignId, turnOrders);

        if (currentPlayer?.HeroId is not null)
        {
            HeroDal hero = await _context.Heroes.SingleAsync(h => h.Id == currentPlayer.HeroId);
            hero.Actions = new()
            {
                HeroId = currentPlayer.HeroId,
                RemainingAttacks = hero.MaxAttackCount,
                RemainingHeals = hero.MaxHealCount,
                RemainingFootSteps = hero.MaxFootStepsCount,
                RemainingChestSearch = hero.MaxChestSearchCount,
                RemainingTrapSearch = hero.MaxTrapSearchCount
            };

            await _context.SaveChangesAsync(); 
        }

        else if (currentPlayer?.MonsterId is not null)
        {
            MonsterDal monster = await _context.Monsters.SingleAsync(h => h.Id == currentPlayer.MonsterId);
            monster.Actions = new()
            {
                MonsterId = currentPlayer.MonsterId,
                RemainingAttacks = monster.MaxAttackCount,
                RemainingHeals = monster.MaxHealCount,
                RemainingFootSteps = monster.MaxFootStepsCount,
                RemainingChestSearch = monster.MaxChestSearchCount,
                RemainingTrapSearch = monster.MaxTrapSearchCount
            };

            await _context.SaveChangesAsync();
        }
    }

    private async Task<List<TurnOrderDal>> GetTurnOrdersAsync(int campaignId)
    {
        List<HeroDal> heroes = await _context.Heroes.Where(h => !h.IsDead && h.CampaignId == campaignId).Include(h => h.TurnOrder).ToListAsync();
        List<MonsterDal> monsters = await _context.Monsters.Where(m => !m.IsDead && m.CampaignId == campaignId).Include(m => m.TurnOrder).ToListAsync();

        List<TurnOrderDal> turnOrders = heroes.Select(h => h.TurnOrder)
            .Union(monsters.Select(m => m.TurnOrder))
            .ToList();

        bool allPlayersHaveTurnOrders = heroes.All(h => h.TurnOrder is not null) && monsters.All(m => m.TurnOrder is not null);

        return allPlayersHaveTurnOrders
            ? turnOrders.OrderBy(to => to?.Order).ToList()
            : await CreateTurnOrdersAsync(campaignId);
    }

    private async Task<List<TurnOrderDal>> CreateTurnOrdersAsync(int campaignId)
    {
        List<HeroDal> heroes = await _context.Heroes.Where(h => !h.IsDead && h.CampaignId == campaignId).ToListAsync();
        List<MonsterDal> monsters = await _context.Monsters.Where(m => !m.IsDead && m.CampaignId == campaignId).ToListAsync();

        List<int> heroesOrders = Enumerable.Range(1, heroes.Count).ToList();
        List<int> monstersOrders = Enumerable.Range(heroes.Count + 1, monsters.Count).ToList();
        List<TurnOrderDal> turnOrders = new();

        foreach (HeroDal hero in heroes)
        {
            int randomOrder = GetRandomOrder(heroesOrders);
            var turnOrder = new TurnOrderDal() { HeroId = hero.Id, Order = randomOrder };
            turnOrders.Add(turnOrder);
        }

        foreach (MonsterDal monster in monsters)
        {
            int randomOrder = GetRandomOrder(monstersOrders);
            var turnOrder = new TurnOrderDal() { MonsterId = monster.Id, Order = randomOrder };
            turnOrders.Add(turnOrder);
        }

        _context.TurnOrders.AddRange(turnOrders);
        await _context.SaveChangesAsync();

        return turnOrders
            .OrderBy(to => to.Order)
            .ToList();
    }

    private static int GetRandomOrder(List<int> orders)
    {
        Random random = new();
        int randomIndex = random.Next(orders.Count);

        int randomOrder = orders.ElementAt(randomIndex);
        orders.RemoveAt(randomIndex);

        return randomOrder;
    }

    private async Task<CurrentPlayerDal?> CreateCurrentPlayerAsync(int campaignId, List<TurnOrderDal> turnOrders)
    {
        TurnOrderDal turnOrder = turnOrders.OrderBy(to => to.Order).First();

        CurrentPlayerDal currentPlayer = new()
        {
            CampaignId = campaignId,
            HeroId = turnOrder.HeroId ?? null,
            MonsterId = turnOrder.MonsterId ?? null
        };

        _context.CurrentPlayers.Add(currentPlayer);
        await _context.SaveChangesAsync();

        return currentPlayer;
    }
}
