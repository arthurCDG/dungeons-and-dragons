using dnd_domain.Campaigns.Adventures;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IPlayersRepository
{
    Task<List<Player>> GetAsync(int userId);
    Task<Player> GetByIdAsync(int id);
    Task<Player> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload);
    Task CreateDungeonMasterAsync(int campaignId, int UserId, PlayerCreationPayload playerCreationPayload);
    
    Task<Player> UpdateAsync(int id, PlayerPayload playerPayload);

    Task SeedMonstersAsync(int campaignId, int adventureId);

    Task<Player> AttackAsync(int id, AttackPayload attack);
}