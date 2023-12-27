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
[SwaggerTag("Available players")]
[ApiController, Route(Route)]
[EnableCors]
public class AvailablePlayersController : ControllerBase
{
    public const string Route = "api/available-players";
    private readonly IAvailablePlayersService _service;

    public AvailablePlayersController(IAvailablePlayersService availablePlayersService)
    {
        _service = availablePlayersService ?? throw new System.ArgumentNullException(nameof(availablePlayersService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<Player>> GetAsync()
        => _service.GetAsync();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsAvailablePlayerAsync([FromBody] int playerId)
        => _service.MarkAsAvailableAsync(playerId);

    [HttpDelete("{playerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsUnavailableAsync(int playerId)
        => _service.MarkAsUnavailableAsync(playerId);
}
