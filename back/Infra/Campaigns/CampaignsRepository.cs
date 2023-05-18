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

    public async Task<Campaign> GetAsync(int sessionId, int campaignId)
    {
        CampaignDal dal = await _context.Campaigns
            .Include(c => c.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(c => c.Heroes)
                    .ThenInclude(r => r.StoredItems)
            .Include(c => c.Monsters)
                    .ThenInclude(r => r.StoredItems)
            .SingleAsync(c => c.SessionId == sessionId && c.Id == campaignId);

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
        RoomDal disabledRoom = new() { CampaignId = campaignId };
        RoomDal bottomLeftRoom = new() { CampaignId = campaignId };
        RoomDal topMiddleLeftRoom = new() { CampaignId = campaignId };
        RoomDal topMiddleRightRoom = new() { CampaignId = campaignId };
        RoomDal bottomMiddleRightRoom = new() { CampaignId = campaignId };
        RoomDal topRightRoom = new() { CampaignId = campaignId, IsStartRoom = true };
        RoomDal bottomRightRoom = new() { CampaignId = campaignId };

        List<RoomDal> rooms = new() { disabledRoom, bottomLeftRoom, topMiddleLeftRoom, topMiddleRightRoom, bottomMiddleRightRoom, topRightRoom, bottomRightRoom };
        _context.Rooms.AddRange(rooms);
        await _context.SaveChangesAsync();

        for (int x = 1; x <= 11; x++)
        {
            for (int y = 1; y <= 22; y++)
            {
                SquareDal squareDal = new() { Position = new() { X = x, Y = y } };

                // Board frame

                if (x == 1)
                {
                    squareDal.HasTopWall = true;
                }

                if (y == 1)
                {
                    squareDal.HasLeftWall = true;
                }

                if (x == 11)
                {
                    squareDal.HasBottomWall = true;
                }

                if (y == 22)
                {
                    squareDal.HasRightWall = true;
                }

                // Top left room (disabled)

                if ((x == 3 & (y == 5 || y == 6 || y == 7)) || (x == 6 && y >= 1 && y <= 4))
                {
                    squareDal.HasBottomWall = true;
                }

                if ((x >= 1 && x <= 3 & y == 7) || (x >= 4 && x <= 6 && y == 4))
                {
                    squareDal.HasRightWall = true;
                }

                if ((x >= 1 && x <= 6 && y >= 1 && y <= 4) || (x >= 1 && x <= 3 && y >= 1 && y <= 7))
                {
                    squareDal.RoomId = disabledRoom.Id;
                    squareDal.IsDisabled = true;
                }

                // Bottom-left room (2 chests and 2 goblins)

                if ((x == 7 && y >= 1 && y <= 4) || (x >= 8 && x <= 11 && y >= 1 && y <= 11))
                {
                    squareDal.RoomId = bottomLeftRoom.Id;
                }

                _context.Add(squareDal);

                // Top-middle-left room (2 pillars and 3 traps)

                if ((x >= 1 && x <= 3 && y >= 8 && y <= 11) || (x >= 4 && x <= 7 && y >= 5 && y <= 11))
                {
                    squareDal.RoomId = topMiddleLeftRoom.Id;
                }

                // Top-middle-right room (6 chest and 3 goblins)

                if (x >= 1 && x <= 7 && y >= 12 && y <= 17)
                {
                    squareDal.RoomId = topMiddleRightRoom.Id;
                }

                // Bottom-middle-right room (6 chest and 3 goblins)

                if (x >= 8 && x <= 11 && y >= 12 && y <= 17)
                {
                    squareDal.RoomId = bottomMiddleRightRoom.Id;
                }

                // Top right room (start room for heroes)

                if (x >= 1 && x <= 5 && y >= 18 && y <= 22)
                {
                    squareDal.RoomId = topRightRoom.Id;
                }


                // Bottom right room (1 goblin)

                if (x >= 6 && x <= 11 && y >= 18 && y <= 22)
                {
                    squareDal.RoomId = bottomRightRoom.Id;
                }

                _context.Add(squareDal);
            }
        }

        await _context.SaveChangesAsync();
        return rooms;
    }
}
