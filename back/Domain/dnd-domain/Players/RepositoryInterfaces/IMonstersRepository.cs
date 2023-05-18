using dnd_domain.Players.Models;

namespace dnd_domain.Players.Repositories;

public interface IMonstersRepository
{
    Task<Monster> AttackAsync(int id, AttackPayload attack);
    Task<Monster> UpdateAsync(int id, PlayerPayload monsterPayload);
}