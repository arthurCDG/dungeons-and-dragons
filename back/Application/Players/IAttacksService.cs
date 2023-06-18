using dnd_domain.Players.Models;
using System.Threading.Tasks;

namespace dnd_application.Players;

public interface IAttacksService
{
    Task<Player> AttackPlayerAsync(int heroId, AttackPayload attackPayload);
}