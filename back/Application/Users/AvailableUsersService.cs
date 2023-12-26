using dnd_domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal sealed class AvailableUsersService : IAvailableUsersService
{
    private readonly IAvailableUsersRepository _repository;

    public AvailableUsersService(IAvailableUsersRepository availableUsersRepository)
    {
        _repository = availableUsersRepository ?? throw new ArgumentNullException(nameof(availableUsersRepository));
    }

    public Task<List<User>> GetAsync()
        => _repository.GetAsync();

    public Task MarkAsAvailableAsync(int userId)
        => _repository.MarkAsAvailableAsync(userId);

    public Task MarkAsUnavailableAsync(int userId)
        => _repository.MarkAsUnavailableAsync(userId);
}
