using dnd_domain.Users;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

public interface IUsersService
{
    Task<List<User>> GetAsync();
    Task<User> GetByIdAsync(int id);
    Task<Result<User>> CreateAsync(UserPayload userPayload);
    Task<Result<User?>> GetFromLoginPayloadAsync(LoginPayload loginPayload);
}