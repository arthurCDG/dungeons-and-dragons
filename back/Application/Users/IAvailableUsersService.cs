using dnd_domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

public interface IAvailableUsersService
{
    Task<List<User>> GetAsync();
    Task MarkAsAvailableAsync(int userId);
    Task MarkAsUnavailableAsync(int userId);
}