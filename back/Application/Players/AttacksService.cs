using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class AttacksService(IAttacksRepository attacksRepository) : IAttacksService
{
    private readonly IAttacksRepository _attacksRepository = attacksRepository;

    public async Task<Player> AttackPlayerAsync(AttackPayload attackPyload)
    {
        // TODO add attacksValidationService
        // Check if attacker and defender playerIds exist
        // Check if defender's already dead
        // Check if attacker's attributes attackCount is >= 1
        // Check if attacker has a matching weapon or spell for his attack type

        return await _attacksRepository.AttackAsync(attackPyload);
    }
}
