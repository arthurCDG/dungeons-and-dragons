using dnd_domain.Campaigns.Models;
using dnd_domain.Fields.Models;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface ISquareMovementRepository
{
    Task<Movement> MoveToSquareAsync(MovementRequestPayload movementRequest);

}