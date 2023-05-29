using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IMonstersRepository
{
    Task<List<Monster>> GetAsync(int campaignId);
    Task<Monster> GetByIdAsync(int id);
    Task<Monster> AttackAsync(int id, AttackPayload attack);
    Task<Monster> UpdateAsync(int id, PlayerPayload monsterPayload);
}