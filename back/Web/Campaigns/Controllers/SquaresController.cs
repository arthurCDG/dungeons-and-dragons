using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using dnd_services.Campaigns.Rooms.Squares;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Squares")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class SquaresController : ControllerBase
{
    public const string Route = "api/squares";
    private readonly ISquaresService _squaresService;

    public SquaresController(ISquaresService squaresService)
    {
        _squaresService = squaresService ?? throw new System.ArgumentNullException(nameof(squaresService));
    }

    [HttpGet("{squareId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Player?> GetSquarePlayerIfAnyAsync(int squareId)
        => _squaresService.GetSquarePlayerIfAnyAsync(squareId);
}
