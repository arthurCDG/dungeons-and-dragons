using dnd_services.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Controllers;

[SwaggerTag("Sessions")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
public class SessionsController : ControllerBase
{
    public const string Route = "api/sessions";
    private readonly ISessionsService _sessionsService;

    public SessionsController(ISessionsService sessionsService)
    {
        _sessionsService = sessionsService ?? throw new System.ArgumentNullException(nameof(sessionsService));
    }

    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status200Ok)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    //public Task PostAsync()
    //    => _sessionsService.GetAsync();

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task PostAsync()
        => _sessionsService.CreateAsync();
}
