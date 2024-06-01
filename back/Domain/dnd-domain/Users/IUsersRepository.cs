using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Users;

public interface IUsersRepository
{
    Task<User> CreateAsync(UserPayload payload);
    Task<List<User>> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload);

    Task<bool> UserNameExistsAsync(string userName);
    Task<bool> CrendentialsMatchAsync(LoginPayload loginPayload);
}