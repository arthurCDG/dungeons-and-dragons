using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

public interface IPlayersService
{
    Task<List<Player>> GetAsync(int userId);
    Task<Player> GetByIdAsync(int id);
    Task<Player> CreateAsync(int userId, PlayerCreationPayload playerCreationPayload);
    Task CreateDungeonMasterAsync(int campaignId, int userId, PlayerCreationPayload playerCreationPayload);
}