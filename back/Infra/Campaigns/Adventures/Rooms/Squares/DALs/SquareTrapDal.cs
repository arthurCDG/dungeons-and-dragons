using dnd_domain.Boards.Enums;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;

internal sealed class SquareTrapDal
{
    public int Id { get; set; }
    public int SquareId { get; set; }
    public SquareTrapType Type { get; set; }

    public SquareTrap ToDomain()
        => new()
        {
            Id = Id,
            SquareId = SquareId,
            Type = Type
        };
}