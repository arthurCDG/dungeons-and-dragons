using dnd_domain.Users;
using System.Threading.Tasks;

namespace dnd_application.Users;

public interface IAuthService
{
    Task<User?> AuthenticateAsync(LoginPayload loginPayload);
    string GenerateToken(User user);
}