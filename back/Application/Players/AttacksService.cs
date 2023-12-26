using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class AttacksService : IAttacksService
{
    private readonly IPlayersRepository _playersRepository;

    public AttacksService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository ?? throw new ArgumentNullException(nameof(playersRepository));
    }

    public Task<Player> AttackPlayerAsync(int playerId, AttackPayload attackPyload)
        => _playersRepository.AttackAsync(playerId, attackPyload);
}
