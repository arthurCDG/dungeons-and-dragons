using dnd_domain.Campaigns.Models;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class MovementDto
{
    public int HeroId { get; set; }
    public int FormerSquareId { get; set; }
    public int NewSquareId { get; set; }

    public static MovementDto FromDomain(Movement movement)
        => new()
        {
            HeroId = movement.HeroId,
            FormerSquareId = movement.FormerSquareId,
            NewSquareId = movement.NewSquareId
        };
}
