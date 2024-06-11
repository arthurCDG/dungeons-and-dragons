using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Players.Repositories;
using dnd_infra.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace dnd_infra.Campaigns.Adventures;

internal sealed class AdventuresRepository
(
    GlobalDbContext context,
    ISquaresRepository squaresRepository,
    IPlayersRepository playersRepository
) : IAdventuresRepository
{
    private readonly GlobalDbContext _context = context;
    private readonly ISquaresRepository _squaresRepository = squaresRepository;
    private readonly IPlayersRepository _playersRepository = playersRepository;

    public Task<Adventure> GetByIdAsync(int id)
        => _context.Adventures
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Trap)
            .AsSplitQuery()
            .Where(a => a.Id == id)
            .Select(a => a.ToDomain())
            .SingleAsync();

    public async Task<Adventure> StartAsync(int campaignId, AdventureType adventureType)
    {
        AdventureDal adventure = await SeedAdventureAsync(campaignId, adventureType);

        adventure.StartsAt = DateTimeOffset.UtcNow;
        await _context.SaveChangesAsync();

        return adventure.ToDomain();
    }

    private async Task<AdventureDal> SeedAdventureAsync(int campaignId, AdventureType type)
    {
        try
        {
            AdventureDal adventure = new()
            {
                Name = AdventureFactoryHelper.GetAdventureName(type),
                Type = type,
                CampaignId = campaignId,
                StartsAt = DateTimeOffset.UtcNow
            };

            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

            await SeedRoomsAsync(adventure.Id, type);
            await _playersRepository.SeedMonstersAsync(campaignId, adventure.Id);

            await _squaresRepository.PlaceHeroesOnSquaresAsync(campaignId, adventure.Id);

            return adventure;
        }
        catch (Exception e)
        {
            throw new TransactionAbortedException($"Adventure could not be seeded because of this exception: {e}.");
        }
    }

    private async Task<List<RoomDal>> SeedRoomsAsync(int adventureId, AdventureType adventure)
        => adventure switch
        {
            AdventureType.GoblinBandits => await SeedGoblinBanditsRoomsAsync(adventureId),
            _ => throw new ArgumentException($"Unknown adventure: {adventure}")
        };

    private async Task<List<RoomDal>> SeedGoblinBanditsRoomsAsync(int adventureId)
    {
        RoomDal disabledRoom = new() { AdventureId = adventureId };
        RoomDal bottomLeftRoom = new() { AdventureId = adventureId };
        RoomDal topMiddleLeftRoom = new() { AdventureId = adventureId };
        RoomDal topMiddleRightRoom = new() { AdventureId = adventureId };
        RoomDal bottomMiddleRightRoom = new() { AdventureId = adventureId };
        RoomDal topRightRoom = new() { AdventureId = adventureId, IsStartRoom = true };
        RoomDal bottomRightRoom = new() { AdventureId = adventureId };

        List<RoomDal> rooms = new()
        {
            disabledRoom,
            bottomLeftRoom,
            topMiddleLeftRoom,
            topMiddleRightRoom,
            bottomMiddleRightRoom,
            topRightRoom,
            bottomRightRoom
        };
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

                if ((x >= 1 && x <= 3 && y == 7) || (x >= 4 && x <= 6 && y == 4))
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

                if (x == 7 && y == 4)
                {
                    squareDal.HasRightWall = true;
                }

                if (x == 8 && y >= 5 && y <= 11)
                {
                    if (y == 8)
                    {
                        squareDal.IsDoor = true;
                    }
                    else
                    {
                        squareDal.HasTopWall = true;
                    }
                }

                if (y == 11 && (x == 8 || x == 10 || x == 11))
                {
                    squareDal.HasRightWall = true;
                }

                if (x == 7 && (y == 1 || y == 2))
                {
                    squareDal.HasLockedChest = true;
                }

                _context.Add(squareDal);

                // Top-middle-left room (2 pillars and 3 traps)

                if ((x >= 1 && x <= 3 && y >= 8 && y <= 11) || (x >= 4 && x <= 7 && y >= 5 && y <= 11))
                {
                    squareDal.RoomId = topMiddleLeftRoom.Id;
                }

                if (y == 11 && x >= 1 && x <= 7)
                {
                    if (x == 4)
                    {
                        squareDal.IsDoor = true;
                    }
                    else
                    {
                        squareDal.HasRightWall = true;
                    }
                }

                if (y == 5 && (x == 4 || x == 7))
                {
                    squareDal.HasPillar = true;
                }

                // Top-middle-right room (6 chest and 3 goblins)

                if (x >= 1 && x <= 7 && y >= 12 && y <= 17)
                {
                    squareDal.RoomId = topMiddleRightRoom.Id;
                }

                if (x == 7 && y >= 12 && y <= 17)
                {
                    squareDal.HasBottomWall = true;
                }

                if (y == 17 && x >= 1 && x <= 7)
                {
                    squareDal.HasRightWall = true;
                }

                if (y == 12 && (x == 2 || x == 6))
                {
                    squareDal.HasLockedChest = true;
                }

                if (y == 17 && (x == 1 || x == 3 || x == 5 || x == 7))
                {
                    squareDal.HasLockedChest = true;
                }

                // Bottom-middle-right room (2 chests and 2 pillars)

                if (x >= 8 && x <= 11 && y >= 12 && y <= 17)
                {
                    squareDal.RoomId = bottomMiddleRightRoom.Id;
                }

                if (x == 9 && y == 12)
                {
                    squareDal.IsDoor = true;
                }

                if (y == 17 && (x == 8 || x == 10 || x == 11))
                {
                    squareDal.HasRightWall = true;
                }

                if (x == 11 && (y == 14 || y == 15))
                {
                    squareDal.HasLockedChest = true;
                }

                if (x == 8 && (y == 13 || y == 16))
                {
                    squareDal.HasPillar = true;
                }

                // Top right room (start room for heroes)

                if (x >= 1 && x <= 5 && y >= 18 && y <= 22)
                {
                    squareDal.RoomId = topRightRoom.Id;
                }

                if (x == 5 && y >= 18 && y <= 22)
                {
                    if (y == 21)
                    {
                        squareDal.IsDoor = true;
                    }
                    else
                    {
                        squareDal.HasBottomWall = true;
                    }
                }

                // Bottom right room (1 goblin)

                if (x >= 6 && x <= 11 && y >= 18 && y <= 22)
                {
                    squareDal.RoomId = bottomRightRoom.Id;
                }

                if (x == 9 && y == 18)
                {
                    squareDal.IsDoor = true;
                }

                _context.Add(squareDal);
            }
        }

        await _context.SaveChangesAsync();
        return rooms;
    }
}
