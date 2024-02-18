using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using dnd_domain.Players.Services.ValidationServices;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class PlayersService : IPlayersService
{
    private readonly IPlayersRepository _playersRepository;
    private readonly IPlayersValidationService _playersValidationService;

    public PlayersService(IPlayersRepository playersRepository, IPlayersValidationService playersValidationService)
    {
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
        _playersValidationService = playersValidationService;
    }

    public Task<List<Player>> GetAsync(int userId)
        => _playersRepository.GetAsync(userId);

    public Task<Player> GetByIdAsync(int id)
     => _playersRepository.GetByIdAsync(id);

    public async Task<Result<Player>> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload)
    {
        Result result = await _playersValidationService.ValidateAsync(playerCreationPayload);
        if (result.IsFailed)
        {
            return result;
        }

        return await _playersRepository.CreateAsync(userId, playerCreationPayload);
    }

    public Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload)
        => _playersRepository.CreateDungeonMasterAsync(campaignId, userId, playerCreationPayload);

}
