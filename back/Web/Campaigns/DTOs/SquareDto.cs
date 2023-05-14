using dnd_domain.Campaigns.Models;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class SquareDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public PositionDto Position { get; set; } = new();

    public bool? IsDoor { get; set; }
    public bool? IsHeroStartingSquare { get; set; }
    public bool? IsMonsterStartingSquare { get; set; }
    public SquareTrapDto? Trap { get; set; }
}
