using dnd_application.Players;
using dnd_domain.Players.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Players.Controllers;

[Authorize]
[SwaggerTag("Players")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class CreatablePlayersServiceController : ControllerBase
{
    public const string Route = "service/users/{userId}/creatable-players";

    private readonly ICreatablePlayersService _creatablePlayersService;

    public CreatablePlayersServiceController(ICreatablePlayersService creatablePlayersService)
    {
        _creatablePlayersService = creatablePlayersService ?? throw new System.ArgumentNullException(nameof(creatablePlayersService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<CreatablePlayer>> GetAsync(int userId)
        => _creatablePlayersService.GetAsync(userId);
}
