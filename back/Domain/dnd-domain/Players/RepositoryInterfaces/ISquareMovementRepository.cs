using dnd_domain.Campaigns.Models;
using dnd_domain.Fields.Models;

namespace dnd_domain.Players.Repositories;

public interface ISquareMovementRepository
{
    Task<Movement> MoveToSquareAsync(MovementRequestPayload movementRequest);

}