using dnd_domain.Fields.Models;
using dnd_domain.Players.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Controllers;

[SwaggerTag("Movements")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
public class SquareMovementController : ControllerBase
{
    public const string Route = "services/movement";
    private readonly ISquareMovementService _squareMovementService;

    public SquareMovementController(ISquareMovementService squareMovementService)
    {
        _squareMovementService = squareMovementService ?? throw new System.ArgumentNullException(nameof(squareMovementService));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MoveToPositionAsync(int heroId, MovementRequestPayload movementRequest)
        => _squareMovementService.MoveToSquareAsync(heroId, movementRequest);
}
