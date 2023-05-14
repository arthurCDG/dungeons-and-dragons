namespace dnd_infra.Campaigns.Rooms.Squares.DALs;

internal sealed class PositionDal
{
    public int Id { get; set; }
    public int SquareId { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
}
