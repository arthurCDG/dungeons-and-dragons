using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

public interface IHeroesService
{
    Task<List<Hero>> GetAsync(int campaignId);
    Task<Hero> AttackAsync(int id, AttackPayload attack);
    Task<Hero> UpdateAsync(int id, PlayerPayload heroPayload);
}