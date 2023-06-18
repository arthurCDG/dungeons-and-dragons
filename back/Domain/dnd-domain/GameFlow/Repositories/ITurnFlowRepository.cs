using dnd_domain.GameFlow.Models;
using System.Threading.Tasks;

namespace dnd_domain.GameFlow.Repositories;

public interface ITurnFlowRepository
{
    Task<CurrentPlayer> GetCurrentPlayerAsync(int campaignId);
    Task<CurrentPlayer> GetNextCurrentPlayerAsync(int campaignId);
    Task EnableCurrentPlayerAsync(int campaignId);
}