using dnd_application.Users.ValidationServices;
using dnd_domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal sealed class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly UserValidationService _validationService;

    public UsersService(IUsersRepository usersRepository, UserValidationService validationService)
    {
        _usersRepository = usersRepository;
        _validationService = validationService;
    }

    public Task<List<User>> GetAsync()
        => _usersRepository.GetAsync();

    public Task<User> GetByIdAsync(int id)
        => _usersRepository.GetByIdAsync(id);

    public async Task<User> CreateAsync(UserPayload userPayload)
    {
        if (!await _validationService.IsValidUserPayloadAsync(userPayload))
        {
            throw new ArgumentException("Invalid user payload"); // TODO Should be a fluent result
        }

        return await _usersRepository.CreateAsync(userPayload);
    }

    public async Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload)
    {
        if (!await _validationService.IsValidLoginPayloadAsync(loginPayload))
        {
            throw new ArgumentException("Invalid login payload"); // TODO Should be a fluent result
        }

        return await _usersRepository.GetFromLoginPayloadAsync(loginPayload);
    }
}
