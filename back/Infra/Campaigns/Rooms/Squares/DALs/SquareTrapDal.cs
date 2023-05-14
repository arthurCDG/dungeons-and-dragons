using dnd_domain.Boards.Enums;

namespace dnd_infra.Campaigns.Rooms.Squares.DALs;

internal sealed class SquareTrapDal
{
    public int Id { get; set; }
    public int SquareId { get; set; }
    public SquareTrapType Type { get; set; }
}