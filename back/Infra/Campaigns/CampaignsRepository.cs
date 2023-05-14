using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Seeder;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns;

internal sealed class CampaignsRepository : ICampaignsRepository
{
    private readonly GlobalDbContext _context;
    private readonly ItemsSeeder _itemsSeeder;
    private readonly PlayersSeeder _playersSeeder;

    public CampaignsRepository(GlobalDbContext context, ItemsSeeder itemsSeeder, PlayersSeeder playersSeeder)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _itemsSeeder = itemsSeeder ?? throw new ArgumentNullException(nameof(itemsSeeder));
        _playersSeeder = playersSeeder ?? throw new ArgumentNullException(nameof(playersSeeder));
    }

    public async Task<Campaign> GetAsync(int sessionId)
    {
        CampaignDal dal = await _context.Campaigns
            .Include(c => c.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(c => c.Heroes)
                    .ThenInclude(r => r.StoredItems)
            .Include(c => c.Monsters)
                    .ThenInclude(r => r.StoredItems)
            .FirstAsync(c => c.SessionId == sessionId);

        return dal.ToDomain();
    }

    public async Task CreateAsync(int sessionId, CampaignPayload campaignPayload)
    {
        SessionDal sessionDal = await _context.Sessions.SingleAsync(s => s.Id == sessionId);

        try
        {
            CampaignDal campaignDal = new()
            {
                SessionId = sessionId,
                Adventure = Adventure.GoblinBandits,
                StartsAt = sessionDal.StartsAt
            };

            _context.Campaigns.Add(campaignDal);
            await _context.SaveChangesAsync();

            List<RoomDal> rooms = await GetRoomsAsync(campaignDal.Id, campaignPayload.Adventure);
            campaignDal.Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            await _context.SaveChangesAsync();

            await _itemsSeeder.SeedItemsAsync(campaignDal.Id);
            await _playersSeeder.SeedPlayersAsync(campaignDal.Id);
        }
        catch (Exception e)
        {
            throw new InvalidProgramException($"Campaign could not be created because of this exception: {e}");
        }
    }

    private async Task<List<RoomDal>> GetRoomsAsync(int campaignId, Adventure adventure)
        => adventure switch
        {
            Adventure.GoblinBandits => await GetGoblinBanditsRoomsAsync(campaignId),
            _ => throw new InvalidOperationException($"Unknown adventure: {adventure}")
        };

    private async Task<List<RoomDal>> GetGoblinBanditsRoomsAsync(int campaignId)
    {
        // Start room for heroes

        RoomDal roomDal = new()
        {
            CampaignId = campaignId,
            IsStartRoom = true
        };

        _context.Rooms.Add(roomDal);
        await _context.SaveChangesAsync();

        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                SquareDal squareDal = new() { Position = new() { X = x, Y = y }, RoomId = roomDal.Id };

                if (x == 0 && (y == 1 || y == 2 || y == 3 || y == 4))
                {
                    squareDal.IsHeroStartingSquare = true;
                }

                if (x == 5 && y == 4)
                {
                    squareDal.IsDoor = true;
                }

                _context.Add(squareDal);
            }
        }

        await _context.SaveChangesAsync();

        // First room with goblins

        RoomDal firstGoblinRoomDal = new()
        {
            CampaignId = campaignId
        };

        _context.Rooms.Add(firstGoblinRoomDal);
        await _context.SaveChangesAsync();

        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                SquareDal squareDal = new() { Position = new() { X = x, Y = y }, RoomId = firstGoblinRoomDal.Id };

                if (x == 5 && (y == 1 || y == 2 || y == 3))
                {
                    squareDal.IsMonsterStartingSquare = true;
                }

                if ((x == 0 && y == 4) || (x == 4 && y == 0))
                {
                    squareDal.IsDoor = true;
                }

                _context.Add(squareDal);
            }
        }

        await _context.SaveChangesAsync();
        return new List<RoomDal> { roomDal, firstGoblinRoomDal };
    }
}
