using dnd_domain.Campaigns.Adventures;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

public interface IAdventuresService
{
    Task<Adventure> GetByIdAsync(int id);
    Task<Adventure> StartAsync(int campaignId, AdventureType adventureType);
}