using dnd_domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal sealed class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository ?? throw new System.ArgumentNullException(nameof(usersRepository));
    }

    public Task<List<User>> GetAsync()
        => _usersRepository.GetAsync();

    public Task<User> GetByIdAsync(int id)
        => _usersRepository.GetByIdAsync(id);

    public Task<User> CreateAsync(UserPayload payload)
        => _usersRepository.CreateAsync(payload);
}
