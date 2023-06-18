using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_domain.Users;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Seeder;
using dnd_infra.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns;

internal sealed class CampaignsRepository : ICampaignsRepository
{
    private readonly GlobalDbContext _context;
    private readonly ItemsSeeder _itemsSeeder;
    private readonly PlayersSeeder _playersSeeder;
    private readonly IUsersRepository _usersRepository;

    public CampaignsRepository(GlobalDbContext context, ItemsSeeder itemsSeeder, PlayersSeeder playersSeeder, IUsersRepository usersRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _itemsSeeder = itemsSeeder ?? throw new ArgumentNullException(nameof(itemsSeeder));
        _playersSeeder = playersSeeder ?? throw new ArgumentNullException(nameof(playersSeeder));
        _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
    }

    public async Task<Campaign> GetAsync(int campaignId)
    {
        CampaignDal dal = await _context.Campaigns
            .Include(c => c.Adventures)
                .ThenInclude(a => a.Rooms)
                    .ThenInclude(r => r.Squares)
                        .ThenInclude(s => s.Position)
            .Include(c => c.Adventures)
                .ThenInclude(a => a.Players)
                    .ThenInclude(p => p.StoredItems)
            .SingleAsync(c => c.Id == campaignId);

        return dal.ToDomain();
    }

    public async Task CreateAsync(CampaignPayload campaignPayload)
    {
        try
        {
            List<UserDal> users = await _context.Users.Where(u => campaignPayload.UserIds.Contains(u.Id)).ToListAsync();

            CampaignDal campaign = new()
            {
                Name = campaignPayload.Name,
                Level = campaignPayload.Level,
                StartsAt = DateTime.UtcNow,
                AssociatedUsers = users.Select(u => new UserCampaignAssociationDal() { UserId = u.Id }).ToList()
            };

            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();

            // Seed First adventure - will have to see how to do this when we have 10+ adventures
            AdventureDal adventure = await SeedAdventureAsync(campaign.Id, campaignPayload.AdventurePayload);
            campaign.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

            await _itemsSeeder.SeedItemsAsync(); // Should be seeded once in DB and that's it ?
            await _playersSeeder.SeedPlayersAsync(adventure.Id);
        }
        catch (Exception e)
        {
            throw new InvalidProgramException($"Campaign could not be created because of this exception: {e}");
        }
    }

    private async Task<AdventureDal> SeedAdventureAsync(int adventureId, AdventurePayload adventurePayload)
    {
        AdventureDal adventureDal = new()
        {
            Name = GetAdventureName(adventurePayload.Adventure),
            Type = adventurePayload.Adventure,
            Rooms = await SeedRoomsAsync(adventureId, adventurePayload.Adventure)
        };

        return adventureDal;
    }

    private static string GetAdventureName(AdventureType adventure)
        => adventure switch
        {
            AdventureType.GoblinBandits => "Les bandits gobelins", // TODO lokalise name
            _ => throw new InvalidOperationException($"Unknown adventure: {adventure}")
        };

    private async Task<List<RoomDal>> SeedRoomsAsync(int adventureId, AdventureType adventure)
        => adventure switch
        {
            AdventureType.GoblinBandits => await GetGoblinBanditsRoomsAsync(adventureId),
            _ => throw new InvalidOperationException($"Unknown adventure: {adventure}")
        };

private async Task<List<RoomDal>> GetGoblinBanditsRoomsAsync(int adventureId)
    {
        RoomDal disabledRoom = new() { AdventureId = adventureId };
        RoomDal bottomLeftRoom = new() { AdventureId = adventureId };
        RoomDal topMiddleLeftRoom = new() { AdventureId = adventureId };
        RoomDal topMiddleRightRoom = new() { AdventureId = adventureId };
        RoomDal bottomMiddleRightRoom = new() { AdventureId = adventureId };
        RoomDal topRightRoom = new() { AdventureId = adventureId, IsStartRoom = true };
        RoomDal bottomRightRoom = new() { AdventureId = adventureId };

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
