using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class SquareDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Position Position { get; set; } = new();

    public bool? HasTopWall { get; set; }
    public bool? HasRightWall { get; set; }
    public bool? HasBottomWall { get; set; }
    public bool? HasLeftWall { get; set; }
    public bool? IsDisabled { get; set; }
    public bool? IsDoor { get; set; }

    public SquareTrap? Trap { get; set; }
    public Player? Player { get; set; }

    private static SquareDto FromDomain(Square square, List<Player> players)
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
            Position = square.Position,
            Trap = square.Trap,
            Player = players.SingleOrDefault(h => h.SquareId == square.Id),
        };
}
