using dnd_domain.Players.Models;

namespace dnd_services.Players;

public interface IAttacksService
{
    Task<Hero> AttackHeroAsync(int heroId, AttackPayload payload);
    Task<Monster> AttackMonsterAsync(int monsterId, AttackPayload payload);
}