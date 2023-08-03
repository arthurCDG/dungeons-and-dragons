using dnd_domain.Campaigns.Adventures.Rooms.Squares;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class MovementDto
{
    public int PlayerId { get; set; }
    public int FormerSquareId { get; set; }
    public int NewSquareId { get; set; }

    public static MovementDto FromDomain(Movement movement)
        => new()
        {
            PlayerId = movement.PlayerId,
            FormerSquareId = movement.FormerSquareId,
            NewSquareId = movement.NewSquareId
        };
}
