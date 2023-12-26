using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class AvailablePlayersService : IAvailablePlayersService
{
    private readonly IAvailablePlayersRepository _availablePlayersRepository;

    public AvailablePlayersService(IAvailablePlayersRepository availablePlayersRepository)
    {
        _availablePlayersRepository = availablePlayersRepository ?? throw new System.ArgumentNullException(nameof(availablePlayersRepository));
    }

    public Task<List<Player>> GetAsync()
        => _availablePlayersRepository.GetAsync();

    public Task MarkAsAvailableAsync(int playerId)
        => _availablePlayersRepository.MarkAsAvailableAsync(playerId);

    public Task MarkAsUnavailableAsync(int playerId)
        => _availablePlayersRepository.MarkAsUnavailableAsync(playerId);
}
