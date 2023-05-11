using dnd_domain.Seeder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Controllers;

[SwaggerTag("Exports")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
public class SessionsSeederController : ControllerBase
{
    public const string Route = "services/seeder/sessions";
    private readonly ISessionSeeder _sessionSeeder;

    public SessionsSeederController(ISessionSeeder sessionSeeder)
    {
        _sessionSeeder = sessionSeeder;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task SeedAsync()
        => _sessionSeeder.SeedSessionAssync();
}
