using dnd_application.Players;
using dnd_domain.Players.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Players.Controllers;

[SwaggerTag("Players")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class PlayersController : ControllerBase
{
    public const string Route = "api/players";
    private readonly IPlayersService _playersService;

    public PlayersController(IPlayersService playersService)
    {
        _playersService = playersService ?? throw new System.ArgumentNullException(nameof(playersService));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Player> AttackAsync([FromBody] PlayerCreationPayload playerCreationPayload)
        => _playersService.CreateAsync(playerCreationPayload);

    [HttpPost("dungeon-master")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task CreateDungeonMasterAsync(int campaignId, PlayerCreationPayload playerCreationPayload)
        => _playersService.CreateDungeonMasterAsync(campaignId, playerCreationPayload);
}
