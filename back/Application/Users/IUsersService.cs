using dnd_domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

public interface IUsersService
{
    Task<List<User>> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(UserPayload payload);
}