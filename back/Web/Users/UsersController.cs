using dnd_domain.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Users;

[SwaggerTag("Users")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class UsersController : ControllerBase
{
    public const string Route = "api/users";

    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    //public Task<User> GetAsync(int id)
    //  => _usersService.GetByIdAsync(id);

    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status403Forbidden)]
    //public Task<User> PostAsync([FromBody] UserPayload userPayload)
    //    => _usersService.CreateAsync(userPayload);
}
