﻿using dnd_domain.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.Campaigns.Adventures.Rooms;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using dnd_domain.Players.Repositories;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using Microsoft.Data;
using System.Transactions;

namespace dnd_infra.Campaigns.Adventures;

internal sealed class AdventuresRepository : IAdventuresRepository
{
    private readonly GlobalDbContext _context;
    private readonly ISquaresRepository _squaresRepository;
    private readonly IPlayersRepository _playersRepository;

    public AdventuresRepository(GlobalDbContext context, ISquaresRepository squaresRepository, IPlayersRepository playersRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _squaresRepository = squaresRepository ?? throw new ArgumentNullException(nameof(squaresRepository));
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
    }

    public Task<Adventure> GetByIdAsync(int id)
        => _context.Adventures
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Trap)
            .Where(a => a.Id == id)
            .Select(a => a.ToDomain())
            .SingleAsync();

    public async Task<Adventure> StartAsync(int campaignId, AdventureType adventureType)
    {
        AdventureDal adventure = await SeedAdventureAsync(campaignId, adventureType); // Type should be retrieved from campaign in a helper or factory

        adventure.Status = AdventureStatus.Started;
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
                Status = AdventureStatus.Started
            };

            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

            await SeedRoomsAsync(adventure.Id, type);
            await _playersRepository.SeedMonstersAsync(campaignId, type);

            await _squaresRepository.PlaceHeroesOnSquaresAsync(campaignId);

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
