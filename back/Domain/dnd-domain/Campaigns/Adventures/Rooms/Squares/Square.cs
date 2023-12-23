namespace dnd_domain.Campaigns.Adventures.Rooms.Squares;

public class Square
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public Position Position { get; set; } = null!;

    public bool? HasTopWall { get; set; }
    public bool? HasRightWall { get; set; }
    public bool? HasBottomWall { get; set; }
    public bool? HasLeftWall { get; set; }
    public bool? HasLockedChest { get; set; }
    public bool? HasOpenedChest { get; set; }
    public bool? HasPillar { get; set; }

    public string? ImageUrl { get; set; }
    public bool? IsDisabled { get; set; }
    public bool? IsDoor { get; set; }
    public SquareTrap? Trap { get; set; }
}
