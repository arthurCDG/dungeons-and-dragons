using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Users;

public interface IUsersRepository
{
    Task<List<User>> GetAsync(HashSet<int> userIds);
}