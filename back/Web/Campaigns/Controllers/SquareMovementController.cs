using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Fields.Models;
using dnd_domain.Players.Services;
using dungeons_and_dragons.Campaigns.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Movements")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class SquareMovementController : ControllerBase
{
    public const string Route = "services/squares/movement";
    private readonly ISquareMovementService _squareMovementService;

    public SquareMovementController(ISquareMovementService squareMovementService)
    {
        _squareMovementService = squareMovementService ?? throw new System.ArgumentNullException(nameof(squareMovementService));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<MovementDto> MoveToPositionAsync(MovementRequestPayload movementRequest)
    {
        Movement movement = await _squareMovementService.MoveToSquareAsync(movementRequest);
        return MovementDto.FromDomain(movement);
    }
}
