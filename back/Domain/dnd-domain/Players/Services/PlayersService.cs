using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

internal sealed class PlayersService : IPlayersService
{
    private readonly IPlayersRepository _playersRepository;

    public PlayersService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
    }

    public Task<List<Player>> GetAsync(int campaignId)
        => _playersRepository.GetAsync(campaignId);

    public Task<Player> GetByIdAsync(int id)
    => _playersRepository.GetByIdAsync(id);

    public Task<Player> AttackAsync(int id, AttackPayload attackPayload)
        => _playersRepository.AttackAsync(id, attackPayload);

    public Task<Player> UpdateAsync(int id, PlayerPayload playerPayload)
        => _playersRepository.UpdateAsync(id, playerPayload);
}
