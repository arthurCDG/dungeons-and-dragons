﻿using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Models;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.Repositories;

internal sealed class SquaresRepository : ISquaresRepository
{
    private readonly GlobalDbContext _context;

    public SquaresRepository(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task<List<Square>> GetAsync(int adventureId)
    {
        List<SquareDal> squares = await _context.Rooms.Where(r => r.AdventureId == adventureId).SelectMany(r => r.Squares).ToListAsync();
        return squares.ConvertAll(s => s.ToDomain());
    }

    public async Task<Player?> GetSquarePlayerIfAnyAsync(int squareId)
    {
        PlayerDal? playerDal = await _context.Players.SingleOrDefaultAsync(h => h.SquareId == squareId);
        return playerDal?.ToDomain() ?? null;
    }

    public async Task PlaceHeroesOnSquaresAsync(int campaignId)
    {
        CampaignDal campaign = await _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .Include(c => c.Players)
                .ThenInclude(p => p.MaxAttributes)
            .Include(c => c.Players)
                .ThenInclude(p => p.Attributes)
            .Include(c => c.Players)
                .ThenInclude(p => p.TurnOrder)
            .Include(c => c.Adventures)
                .ThenInclude(a => a.Rooms)
                    .ThenInclude(r => r.Squares)
                        .ThenInclude(s => s.Position)
            .SingleAsync(c => c.Id == campaignId);

        List<PlayerDal> players = campaign.Players;
        AdventureDal adventure = campaign.Adventures.Single(a => a.IsActive && !a.IsCompleted);

        switch (adventure.Type)
        {
            case AdventureType.GoblinBandits:
                await PlaceHeroesOnGoblinBanditsSquaresAsync(adventure.Rooms, players);
                break;
            default: throw new InvalidOperationException($"Unknown adventure type: {adventure.Type}.");
        }
    }

    private async Task PlaceHeroesOnGoblinBanditsSquaresAsync(List<RoomDal> rooms, List<PlayerDal> players)
    {
        List<PlayerDal> heroes = players.Where(p => p.Profile.Class != null && p.Profile.Race != null).ToList();
        List<SquareDal> squares = rooms.SelectMany(r => r.Squares).ToList();

        List<int> heroesSartingSquareIds = squares
            .Where(s => s.Position.X == 1 && (s.Position.Y == 18 || s.Position.Y == 19 || s.Position.Y == 20 || s.Position.Y == 21))
            .Select(s => s.Id)
            .ToList();

        for (var i = 0; i < heroes.Count; i++)
        {
            heroes[i].SquareId = heroesSartingSquareIds[i];
        }

        await _context.SaveChangesAsync();
    }
}
