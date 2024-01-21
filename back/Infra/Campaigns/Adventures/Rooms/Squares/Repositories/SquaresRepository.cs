using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;
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

    public async Task<Square> GetByIdAsync(int id)
    {
        SquareDal square = await _context.Squares.Include(s => s.Position).SingleAsync(s => s.Id == id);
        return square.ToDomain();
    }

    public async Task<Player?> GetSquarePlayerIfAnyAsync(int id)
    {
        PlayerDal? playerDal = await _context.Players
            .Include(p => p.Profile)
            .Include(p => p.MaxAttributes)
            .SingleOrDefaultAsync(h => h.SquareId == id);

        return playerDal?.ToDomain() ?? null;
    }

    public async Task PlaceHeroesOnSquaresAsync(int campaignId, int adventureId)
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
        AdventureDal adventure = campaign.Adventures.Single(a => a.Id == adventureId);

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
        List<PlayerDal> heroes = players.Where(p => p.Profile!.Class != null && p.Profile.Race != null).ToList();
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
