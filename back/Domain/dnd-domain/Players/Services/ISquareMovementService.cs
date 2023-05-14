using dnd_domain.Fields.Models;

namespace dnd_domain.Players.Services;

public interface ISquareMovementService
{
    Task MoveToSquareAsync(int heroId, MovementRequestPayload movementRequest);
}