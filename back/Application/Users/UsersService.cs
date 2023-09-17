using dnd_domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal sealed class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
    }

    public Task<List<User>> GetAsync()
        => _usersRepository.GetAsync();

    public Task<User> GetByIdAsync(int id)
        => _usersRepository.GetByIdAsync(id);

    public Task<User> CreateAsync(UserPayload userPayload)
        => _usersRepository.CreateAsync(userPayload);

    public Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload)
        => _usersRepository.GetFromLoginPayloadAsync(loginPayload);
}
