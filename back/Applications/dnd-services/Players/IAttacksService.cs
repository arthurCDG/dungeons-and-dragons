using dnd_domain.Players.Models;
using System.Threading.Tasks;

namespace dnd_services.Players;

public interface IAttacksService
{
    Task<Hero> AttackHeroAsync(int heroId, AttackPayload payload);
    Task<Monster> AttackMonsterAsync(int monsterId, AttackPayload payload);
}