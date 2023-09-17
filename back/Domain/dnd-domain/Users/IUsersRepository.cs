using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Users;

public interface IUsersRepository
{
    Task<List<User>> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(UserPayload payload);
    Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload);
}