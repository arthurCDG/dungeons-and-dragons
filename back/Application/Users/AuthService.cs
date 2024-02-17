using dnd_domain.Users;
using FluentResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUsersService _usersService;

    public AuthService(IConfiguration configuration, IUsersService usersService)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
    }

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Name)
        };

        var token = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
            claims,
            expires: DateTime.Now.AddDays(7), // TODO reduce after tests
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public Task<Result<User?>> AuthenticateAsync(LoginPayload loginPayload)
        => _usersService.GetFromLoginPayloadAsync(loginPayload);
}
