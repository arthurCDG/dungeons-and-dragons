using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IHeroesRepository
{
    Task<List<Hero>> GetAsync(int campaignId);
    Task<Hero> GetByIdAsync(int id);
    Task<Hero> AttackAsync(int id, AttackPayload attack);
    Task<Hero> UpdateAsync(int id, PlayerPayload heroPayload);
}