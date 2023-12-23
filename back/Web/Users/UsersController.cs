using dnd_application.Users;
using dnd_domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Users;

[Authorize]
[SwaggerTag("Users")]
[ApiController, Route(Route)]
[EnableCors]
public class UsersController : ControllerBase
{
    public const string Route = "api/users";
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<User>> GetAsync()
         => _usersService.GetAsync();

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<User> GetByIdAsync(int id)
      => _usersService.GetByIdAsync(id);
}
