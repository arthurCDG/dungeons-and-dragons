using dnd_domain.Campaigns.Models;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;

internal sealed class SquareDal
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public PositionDal Position { get; set; } = new();

    public bool? HasTopWall { get; set; }
    public bool? HasRightWall { get; set; }
    public bool? HasBottomWall { get; set; }
    public bool? HasLeftWall { get; set; }
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
            IsDisabled = IsDisabled,
            IsDoor = IsDoor,
            Position = Position.ToDomain(),
            Trap = Trap?.ToDomain(),
        };
}
