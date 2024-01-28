using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Players.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.Mappers;

public static class SquareDtoMapper
{
    public static SquareDto ToDto(Square square, List<Player> players)
        => new()
        {
            Id = square.Id,
            RoomId = square.RoomId,
            ImageUrl = square.ImageUrl,
            IsDisabled = square.IsDisabled,
            IsDoor = square.IsDoor,
            HasBottomWall = square.HasBottomWall,
            HasTopWall = square.HasTopWall,
            HasLeftWall = square.HasLeftWall,
            HasRightWall = square.HasRightWall,
            HasLockedChest = square.HasLockedChest,
            HasOpenedChest = square.HasOpenedChest,
            HasPillar = square.HasPillar,
            Position = square.Position,
            Trap = square.Trap,
            Player = players.FirstOrDefault(h => h.Square?.Id == square.Id),
        };
}
