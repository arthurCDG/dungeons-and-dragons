using dnd_domain.Boards.Enums;

namespace dnd_domain.Campaigns.Models;

public class SquareTrap
{
    public int Id { get; set; }
    public int SquareId { get; set; }
    public SquareTrapType Type { get; set; }
}
