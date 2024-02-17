using dnd_application.Users.ValidationServices;
using dnd_domain.Users;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Users;

internal sealed class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUserValidationService _validationService;

    public UsersService(IUsersRepository usersRepository, IUserValidationService validationService)
    {
        _usersRepository = usersRepository;
        _validationService = validationService;
    }

    public Task<List<User>> GetAsync()
        => _usersRepository.GetAsync();

    public Task<User> GetByIdAsync(int id)
        => _usersRepository.GetByIdAsync(id);

    public async Task<Result<User>> CreateAsync(UserPayload userPayload)
    {
        Result result = await _validationService.ValidateUserPayloadAsync(userPayload);
        if (result.IsFailed)
        {
            return result;
        }

        return await _usersRepository.CreateAsync(userPayload);
    }

    public async Task<Result<User?>> GetFromLoginPayloadAsync(LoginPayload loginPayload)
    {
        Result result = await _validationService.ValidateLoginPayloadAsync(loginPayload);
        if (result.IsFailed)
        {
            return result;
        }

        return await _usersRepository.GetFromLoginPayloadAsync(loginPayload);
    }
}
