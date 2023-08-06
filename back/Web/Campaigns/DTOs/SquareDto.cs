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
    public bool? HasLockedChest { get; set; }
    public bool? HasOpenedChest { get; set; }
    public bool? HasPillar { get; set; }

    public bool? IsDisabled { get; set; }
    public bool? IsDoor { get; set; }

    public SquareTrap? Trap { get; set; }
    public Player? Player { get; set; }
}
