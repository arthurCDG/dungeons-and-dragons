using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IAttacksRepository
{
    Task<Player> AttackAsync(AttackPayload attackPayload);
}