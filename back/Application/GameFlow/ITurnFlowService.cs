using dnd_domain.GameFlow.Models;
using System.Threading.Tasks;

namespace dnd_application.GameFlow;

public interface ITurnFlowService
{
    Task EnableCurrentPlayerAsync(int campaignId);
    Task<CurrentPlayer> GetCurrentPlayerAsync(int campaignId);
    Task<CurrentPlayer> GetNextCurrentPlayerAsync(int campaignId);
    Task<bool> IsCurrentPlayerAsync(int campaignId, int playerId);
}