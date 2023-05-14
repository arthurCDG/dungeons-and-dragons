using dnd_domain.Boards.Enums;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class SquareTrapDto
{
    public int Id { get; set; }
    public int SquareId { get; set; }
    public SquareTrapType Type { get; set; }
}
