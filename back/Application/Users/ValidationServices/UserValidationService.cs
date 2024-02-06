using dnd_domain.Users;
using System.Threading.Tasks;

namespace dnd_application.Users.ValidationServices;

internal sealed class UserValidationService
{
    private readonly IUsersRepository _usersRepository;

    public UserValidationService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<bool> IsValidUserPayloadAsync(UserPayload userPayload)
    {
        if (string.IsNullOrWhiteSpace(userPayload.UserName))
            return false;

        if (string.IsNullOrWhiteSpace(userPayload.Password))
            return false;

        if (await _usersRepository.UserNameExistsAsync(userPayload.UserName))
            return false;

        return true;
    }

    public async Task<bool> IsValidLoginPayloadAsync(LoginPayload loginPayload)
    {
        if (string.IsNullOrWhiteSpace(loginPayload.UserName))
            return false;

        if (string.IsNullOrWhiteSpace(loginPayload.Password))
            return false;

        if (await _usersRepository.UserNameExistsAsync(loginPayload.UserName))
            return true;

        return false;
    }
}
