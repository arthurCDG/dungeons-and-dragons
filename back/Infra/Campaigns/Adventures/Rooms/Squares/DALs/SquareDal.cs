using dnd_domain.Campaigns.Adventures.Rooms.Squares;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;

internal sealed class SquareDal
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public PositionDal Position { get; set; } = null!;

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
    public SquareTrapDal? Trap { get; set; }

    public Square ToDomain()
        => new()
        {
            Id = Id,
            RoomId = RoomId,
            ImageUrl = ImageUrl,
            HasTopWall = HasTopWall,
            HasRightWall = HasRightWall,
            HasBottomWall = HasBottomWall,
            HasLeftWall = HasLeftWall,
            HasLockedChest = HasLockedChest,
            HasOpenedChest = HasOpenedChest,
            HasPillar = HasPillar,
            IsDisabled = IsDisabled,
            IsDoor = IsDoor,
            Position = Position.ToDomain(),
            Trap = Trap?.ToDomain(),
        };
}
