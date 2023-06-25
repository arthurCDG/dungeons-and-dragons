using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class PlayersService : IPlayersService
{
    private readonly IPlayersRepository _playersRepository;

    public PlayersService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
    }

    public Task<Player> CreateAsync(PlayerCreationPayload playerCreationPayload)
        => _playersRepository.CreateAsync(playerCreationPayload);

    public Task CreateDungeonMasterAsync(int campaignId, PlayerCreationPayload playerCreationPayload)
        => _playersRepository.CreateDungeonMasterAsync(campaignId, playerCreationPayload);

}
