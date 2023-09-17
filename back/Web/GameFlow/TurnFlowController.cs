using dnd_application.GameFlow;
using dnd_domain.GameFlow.Models;
using dungeons_and_dragons.GameFlow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[Authorize]
[SwaggerTag("GameFlow")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class TurnFlowController : ControllerBase
{
    public const string Route = "services/adventures/{adventureId}";
    private readonly ITurnFlowService _turnFlowService;

    public TurnFlowController(ITurnFlowService turnFlowService)
    {
        _turnFlowService = turnFlowService ?? throw new System.ArgumentNullException(nameof(turnFlowService));
    }

    [HttpGet("current-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<CurrentPlayerDto> GetCurrentPlayer(int adventureId)
    {
        CurrentPlayer currentPlayer = await _turnFlowService.GetCurrentPlayerAsync(adventureId);
        return CurrentPlayerDto.FromDomain(currentPlayer);
    }

    [HttpGet("next-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<CurrentPlayerDto> GetNextPlayer(int adventureId)
    {
        CurrentPlayer currentPlayer = await _turnFlowService.GetNextCurrentPlayerAsync(adventureId);
        return CurrentPlayerDto.FromDomain(currentPlayer);
    }

    [HttpPost("enable-current-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task EnableCurrentPlayer(int adventureId)
        => _turnFlowService.EnableCurrentPlayerAsync(adventureId);
}
