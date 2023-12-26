using dnd_application.Players;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Players.Controllers;

[Authorize]
[SwaggerTag("Availability service")]
[ApiController, Route(Route)]
[EnableCors]
public class AvailablePlayersServiceController : ControllerBase
{
    public const string Route = "service/available-players";
    private readonly IAvailablePlayersService _service;

    public AvailablePlayersServiceController(IAvailablePlayersService availablePlayersService)
    {
        _service = availablePlayersService ?? throw new System.ArgumentNullException(nameof(availablePlayersService));
    }

    [HttpGet("players")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<Player>> GetAsync()
        => _service.GetAsync();

    [HttpPost("players")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsAvailablePlayerAsync([FromBody] int playerId)
        => _service.MarkAsAvailableAsync(playerId);

    [HttpDelete("players/{playerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsUnavailableAsync(int playerId)
        => _service.MarkAsUnavailableAsync(playerId);
}
