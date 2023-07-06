using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class PlayersService : IPlayersService
{
    private readonly IPlayersRepository _playersRepository;

    public PlayersService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
    }

    public Task<List<Player>> GetAsync(int userId)
        => _playersRepository.GetAsync(userId);

    public Task<Player> GetByIdAsync(int id)
     => _playersRepository.GetByIdAsync(id);

    public Task<Player> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload)
        => _playersRepository.CreateAsync(userId, playerCreationPayload);

    public Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload)
        => _playersRepository.CreateDungeonMasterAsync(campaignId, userId, playerCreationPayload);

}
