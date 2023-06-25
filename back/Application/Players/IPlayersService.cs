using dnd_domain.Players.Models;
using System.Threading.Tasks;

namespace dnd_application.Players;

public interface IPlayersService
{
    Task<Player> CreateAsync(PlayerCreationPayload playerCreationPayload);
    Task CreateDungeonMasterAsync(int campaignId, PlayerCreationPayload playerCreationPayload);
}