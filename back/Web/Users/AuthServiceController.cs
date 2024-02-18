using dnd_application.Users;
using dnd_domain.Users;
using FluentResults;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Users;

[SwaggerTag("Auth")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class AuthServiceController : ControllerBase
{
    public const string Route = "services/auth";
    private readonly IUsersService _usersService;
    private readonly IAuthService _authService;

    public AuthServiceController(IUsersService usersService, IAuthService authService)
    {
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<AuthentifiedUserDto>> SignUpUserAsync([FromBody] UserPayload userPayload)
    {
        Result<User> result = await _usersService.CreateAsync(userPayload);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors[0]);
        }

        var token = _authService.GenerateToken(result.Value);

        AuthentifiedUserDto authentifiedUserDto = new()
        {
            UserId = result.Value.Id,
            Token = token
        };

        return Ok(authentifiedUserDto);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<AuthentifiedUserDto>> LoginUserAsync([FromBody] LoginPayload loginPayload)
    {
        Result<User?> result = await _authService.AuthenticateAsync(loginPayload);

        if (result.IsFailed)
        {
            return BadRequest(result.Errors[0]);
        }

        if (result.Value is not null)
        {
            var token = _authService.GenerateToken(result.Value);

            AuthentifiedUserDto authentifiedUserDto = new()
            {
                UserId = result.Value.Id,
                Token = token
            };

            return Ok(authentifiedUserDto);
        }

        return NotFound("user not found");
    }
}
