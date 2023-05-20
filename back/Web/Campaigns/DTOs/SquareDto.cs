using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;

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
    public Hero? Hero { get; set; }
    public Monster? Monster { get; set; }
}
