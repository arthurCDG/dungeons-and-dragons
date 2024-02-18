using dnd_domain.Users;
using FluentResults;
using System.Threading.Tasks;

namespace dnd_application.Users.ValidationServices;

internal sealed class UserValidationService : IUserValidationService
{
    private readonly IUsersRepository _usersRepository;

    public UserValidationService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<Result> ValidateUserPayloadAsync(UserPayload userPayload)
    {
        if (string.IsNullOrWhiteSpace(userPayload.UserName))
            return new Result().WithError("UserName is required");

        if (string.IsNullOrWhiteSpace(userPayload.Password))
            return new Result().WithError("Password is required");

        if (await _usersRepository.UserNameExistsAsync(userPayload.UserName))
            return new Result().WithError("UserName already exists.");

        return new Result();
    }

    public async Task<Result> ValidateLoginPayloadAsync(LoginPayload loginPayload)
    {
        if (string.IsNullOrWhiteSpace(loginPayload.UserName))
            return new Result().WithError("UserName is required");

        if (string.IsNullOrWhiteSpace(loginPayload.Password))
            return new Result().WithError("Password is required");

        if (!await _usersRepository.UserNameExistsAsync(loginPayload.UserName))
            return new Result().WithError("UserName does not exist.");

        if (!await _usersRepository.PasswordExistsAsync(loginPayload.UserName))
            return new Result().WithError("Password is incorrect.");

        return new Result();
    }
}
