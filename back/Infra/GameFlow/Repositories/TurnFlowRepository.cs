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

    public async Task<CurrentPlayer> GetCurrentPlayerAsync(int adventureId)
    {
        CurrentPlayerDal currentPlayer = await GetCurrentPlayerDalAsync(adventureId);
        return currentPlayer!.ToDomain();
    }

    private async Task<CurrentPlayerDal> GetCurrentPlayerDalAsync(int adventureId)
    {
        CurrentPlayerDal? currentPlayer = await _context.CurrentPlayers
            .Include(cp => cp.Player)
            .FirstOrDefaultAsync(cp => cp.AdventureId == adventureId);

        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(adventureId);
        currentPlayer ??= await CreateCurrentPlayerAsync(adventureId, turnOrders);

        return currentPlayer!;
    }

    public async Task<CurrentPlayer> GetNextCurrentPlayerAsync(int adventureId)
    {
        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(adventureId);
        
        CurrentPlayerDal currentPlayer = await GetCurrentPlayerDalAsync(adventureId);

        int currentTurnOrder = turnOrders.Single(to => to.PlayerId == currentPlayer.Id).Order;
        TurnOrderDal nextTurnOrder = turnOrders.FirstOrDefault(to => to.Order > currentTurnOrder) ?? turnOrders.First();
        CurrentPlayerDal nextCurrentPlayer = ForgeNextCurrentPlayerDal(nextTurnOrder, adventureId);
        
        _context.CurrentPlayers.Remove(currentPlayer);
        await _context.SaveChangesAsync();
        
        return nextCurrentPlayer.ToDomain();
    }

    private CurrentPlayerDal ForgeNextCurrentPlayerDal(TurnOrderDal nextTurnOrder, int adventureId)
    {
        CurrentPlayerDal nextCurrentPlayer = new()
        {
            PlayerId = nextTurnOrder.PlayerId,
            AdventureId = adventureId
        };
        _context.Add(nextCurrentPlayer);
        
        return nextCurrentPlayer;
    }

    public async Task EnableCurrentPlayerAsync(int adventureId)
    {
        CurrentPlayerDal? currentPlayer = await _context.CurrentPlayers.FirstOrDefaultAsync(cp => cp.AdventureId == adventureId);
        List<TurnOrderDal> turnOrders = await GetTurnOrdersAsync(adventureId);
        currentPlayer ??= await CreateCurrentPlayerAsync(adventureId, turnOrders);

        PlayerDal player = await _context.Players
            .Include(p => p.Attributes)
            .Include(p => p.MaxAttributes)
            .SingleAsync(h => h.Id == currentPlayer!.PlayerId);

        player.Attributes = new()
        {
            PlayerId = currentPlayer!.PlayerId,
            LifePoints = player.MaxAttributes.MaxLifePoints,
            ManaPoints = player.MaxAttributes.MaxManaPoints,
            FootSteps = player.MaxAttributes.MaxFootSteps,
            Shield = player.MaxAttributes.MaxShield,
            AttackCount = player.MaxAttributes.MaxAttackCount,
            HealCount = player.MaxAttributes.MaxHealCount,
            ChestSearchCount = player.MaxAttributes.MaxChestSearchCount,
            TrapSearchCount = player.MaxAttributes.MaxTrapSearchCount
        };

        await _context.SaveChangesAsync(); 
    }

    private async Task<List<TurnOrderDal>> GetTurnOrdersAsync(int adventureId)
    {
        List<PlayerDal> players = await _context.Players
            .Include(p => p.TurnOrder)
            .Where(p => !p.IsDead && p.Campaigns.Any(c => c.Id == adventureId))
            .ToListAsync();

        List<TurnOrderDal?> turnOrders = players.Select(p => p.TurnOrder).ToList();

        bool allPlayersHaveTurnOrders = turnOrders.Any() && players.All(p => p.TurnOrder is not null);

        return allPlayersHaveTurnOrders
            ? turnOrders.OrderBy(to => to?.Order).ToList()
            : await CreateTurnOrdersAsync(adventureId);
    }

    private async Task<List<TurnOrderDal>> CreateTurnOrdersAsync(int adventureId)
    {
        List<PlayerDal> heroes = await _context.Players
            .Include(p => p.Profile)
            .Where(p => !p.IsDead && p.Campaigns.Any(c => c.Id == adventureId) && p.Profile.Class.HasValue && p.Profile.Race.HasValue)
            .ToListAsync();

        List<PlayerDal> monsters = await _context.Players
            .Include(p => p.Profile)
            .Where(p => !p.IsDead && p.Campaigns.Any(c => c.Id == adventureId) && p.Profile.MonsterType.HasValue)
            .ToListAsync();

        List<int> playersOrders = Enumerable.Range(1, heroes.Count).ToList();
        List<int> monstersOrders = Enumerable.Range(heroes.Count + 1, monsters.Count).ToList();
        List<TurnOrderDal> turnOrders = new();

        foreach (PlayerDal hero in heroes)
        {
            int randomOrder = GetRandomOrder(playersOrders);
            var turnOrder = new TurnOrderDal() { PlayerId = hero.Id, Order = randomOrder, AdventureId = adventureId };
            turnOrders.Add(turnOrder);
        }

        foreach (PlayerDal monster in monsters)
        {
            int randomOrder = GetRandomOrder(monstersOrders);
            var turnOrder = new TurnOrderDal() { PlayerId = monster.Id, Order = randomOrder, AdventureId = adventureId };
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

    private async Task<CurrentPlayerDal?> CreateCurrentPlayerAsync(int adventureId, List<TurnOrderDal> turnOrders)
    {
        TurnOrderDal turnOrder = turnOrders.OrderBy(to => to.Order).First();

        CurrentPlayerDal currentPlayer = new()
        {
            AdventureId = adventureId,
            PlayerId = turnOrder.PlayerId
        };

        _context.CurrentPlayers.Add(currentPlayer);
        await _context.SaveChangesAsync();

        return currentPlayer;
    }
}
