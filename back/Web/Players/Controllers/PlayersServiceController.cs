using dnd_application.Players;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[Authorize]
[SwaggerTag("Players")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class PlayersServiceController(IAttacksService attacksService) : ControllerBase
{
    public const string Route = "services/players";

    private readonly IAttacksService _attacksService = attacksService;

    [HttpPost("attack")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Player> AttackAsync([FromBody] AttackPayload attackPayload)
        => _attacksService.AttackPlayerAsync(attackPayload);

    [HttpPost("heal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Player> HealAsync([FromBody] AttackPayload attackPayload)
        => _attacksService.AttackPlayerAsync(attackPayload);
}
