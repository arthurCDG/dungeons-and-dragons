using dnd_domain.Players.Enums;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using FluentResults;
using System;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services.ValidationServices;

internal sealed class PlayersValidationService(IPlayersRepository playersRepository) : IPlayersValidationService
{
    private readonly IPlayersRepository _playersRepository = playersRepository;

    public async Task<Result> ValidateAsync(PlayerCreationPayload playerCreationPayload)
    {
        if (!Enum.IsDefined(typeof(Class), playerCreationPayload.Class))
            return new Result().WithError($"Invalid class : {playerCreationPayload.Class}.");

        if (!Enum.IsDefined(typeof(Species), playerCreationPayload.Species))
            return new Result().WithError($"Invalid species: {playerCreationPayload.Species}.");

        if (!Enum.IsDefined(typeof(PlayerGender), playerCreationPayload.Gender))
            return new Result().WithError($"Invalid gender: {playerCreationPayload.Gender}.");

        if (await _playersRepository.UserNameExistsAsync(playerCreationPayload.Name))
            return new Result().WithError($"Username {playerCreationPayload.Name} already exists.");

        return new Result();
    }
}
