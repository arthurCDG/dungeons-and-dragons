using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IPlayersRepository
{
    Task<List<Player>> GetAsync(int campaignId);
    Task<Player> GetByIdAsync(int id);
    Task<Player> CreateAsync(PlayerCreationPayload playerCreationPayload);
    Task<Player> UpdateAsync(int id, PlayerPayload playerPayload);
    Task<Player> AttackAsync(int id, AttackPayload attack);
}