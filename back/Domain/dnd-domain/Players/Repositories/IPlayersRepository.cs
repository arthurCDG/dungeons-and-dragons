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
    Task<Player> UpdateAsync(int id, PlayerPayload playerPayload);

    Task<bool> UserNameExistsAsync(string name);
    Task<bool> ExistsAsync(int id);
    Task<bool> AreAvailableAsync(IEnumerable<int> playerIds);

    Task CreateDungeonMasterAsync(int campaignId, int UserId, PlayerCreationPayload playerCreationPayload);
    Task SeedMonstersAsync(int campaignId, int adventureId);
}