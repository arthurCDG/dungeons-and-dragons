using dnd_application.Users;
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
[SwaggerTag("Available dungeon masters")]
[ApiController, Route(Route)]
[EnableCors]
public class AvailableDungeonMastersController : ControllerBase
{
    public const string Route = "api/available-dungeon-masters";
    private readonly IAvailableUsersService _service;

    public AvailableDungeonMastersController(IAvailableUsersService service)
    {
        _service = service ?? throw new System.ArgumentNullException(nameof(service));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<User>> GetAsync()
        => _service.GetAsync();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsAvailableAsync([FromBody] int userId)
        => _service.MarkAsAvailableAsync(userId);

    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task MarkAsUnavailableAsync(int userId)
        => _service.MarkAsUnavailableAsync(userId);
}
