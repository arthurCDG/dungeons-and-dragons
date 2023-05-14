namespace dnd_infra.Campaigns.Rooms.Squares.DALs;

internal sealed class SquareDal
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public PositionDal Position { get; set; } = new();

    public bool? IsDoor { get; set; }
    public bool? IsHeroStartingSquare { get; set; }
    public bool? IsMonsterStartingSquare { get; set; }
    public SquareTrapDal? Trap { get; set; }
}
