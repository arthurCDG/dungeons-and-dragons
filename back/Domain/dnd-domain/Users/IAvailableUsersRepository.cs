using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Users;

public interface IAvailableUsersRepository
{
    Task<List<User>> GetAsync();
    Task MarkAsAvailableAsync(int userId);
    Task MarkAsUnavailableAsync(int userId);
}