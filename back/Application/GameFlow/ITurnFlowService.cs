using dnd_domain.GameFlow.Models;
using System.Threading.Tasks;

namespace dnd_application.GameFlow;

public interface ITurnFlowService
{
    Task EnableCurrentPlayerAsync(int campaignId);
    Task<CurrentPlayer> GetCurrentPlayerIdAsync(int campaignId);
    Task<int> GetNextPlayerIdAsync(int campaignId);
    Task<bool> IsCurrentPlayerAsync(int campaignId, int playerId);
}