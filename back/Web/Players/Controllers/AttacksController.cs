using dnd_domain.Players.Models;
using dnd_application.Players;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Attacks")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class AttacksController : ControllerBase
{
    public const string Route = "services/attack";
    private readonly IAttacksService _attacksService;

    public AttacksController(IAttacksService attacksService)
    {
        _attacksService = attacksService ?? throw new System.ArgumentNullException(nameof(attacksService));
    }

    [HttpPost("hero/{heroId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Hero> AttackAsync(int heroId, [FromBody] AttackPayload payload)
        => _attacksService.AttackHeroAsync(heroId, payload);

    [HttpPost("monster/{monsterId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Monster> AttackMonsterAsync(int monsterId, [FromBody] AttackPayload payload)
        => _attacksService.AttackMonsterAsync(monsterId, payload);
}
