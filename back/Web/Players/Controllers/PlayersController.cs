using dnd_application.Players;
using dnd_domain.Players.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Players.Controllers;

[SwaggerTag("Players")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class PlayersController : ControllerBase
{
    public const string Route = "api/users/{userId}/players";
    private readonly IPlayersService _playersService;

    public PlayersController(IPlayersService playersService)
    {
        _playersService = playersService ?? throw new System.ArgumentNullException(nameof(playersService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<Player>> GetAsync(int userId)
        => _playersService.GetAsync(userId);

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<Player> GetByIdAsync(int id)
    {
        var toto = await _playersService.GetByIdAsync(id);
        return toto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Player> CreateAsync(int userId, [FromBody] PlayerCreationPayload playerCreationPayload)
        => _playersService.CreateAsync(userId, playerCreationPayload);

    [HttpPost("dungeon-master")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload)
        => _playersService.CreateDungeonMasterAsync(campaignId, userId, playerCreationPayload);
}
