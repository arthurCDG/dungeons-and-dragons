using dnd_domain.Users;
using FluentResults;
using System.Threading.Tasks;

namespace dnd_application.Users;

public interface IAuthService
{
    Task<Result<User?>> AuthenticateAsync(LoginPayload loginPayload);
    string GenerateToken(User user);
}