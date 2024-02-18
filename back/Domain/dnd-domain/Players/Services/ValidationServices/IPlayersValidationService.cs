using dnd_domain.Players.Payloads;
using FluentResults;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services.ValidationServices;

public interface IPlayersValidationService
{
    Task<Result> ValidateAsync(PlayerCreationPayload playerCreationPayload);
}