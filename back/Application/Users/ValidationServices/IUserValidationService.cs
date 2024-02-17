using dnd_domain.Users;
using FluentResults;
using System.Threading.Tasks;

namespace dnd_application.Users.ValidationServices;

public interface IUserValidationService
{
    Task<Result> ValidateLoginPayloadAsync(LoginPayload loginPayload);
    Task<Result> ValidateUserPayloadAsync(UserPayload userPayload);
}