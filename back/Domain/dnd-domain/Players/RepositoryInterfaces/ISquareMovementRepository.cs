using dnd_domain.Fields.Models;

namespace dnd_domain.Players.Repositories;

public interface ISquareMovementRepository
{
    Task MoveToSquareAsync(int heroId, MovementRequestPayload movementRequest);

}