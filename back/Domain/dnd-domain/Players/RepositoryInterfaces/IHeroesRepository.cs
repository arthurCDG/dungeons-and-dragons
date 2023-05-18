using dnd_domain.Players.Models;

namespace dnd_domain.Players.Repositories;

public interface IHeroesRepository
{
    Task<Hero> AttackAsync(int id, AttackPayload attack);
    Task<Hero> UpdateAsync(int id, PlayerPayload heroPayload);
}