using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns.Adventures;

public interface IAdventuresRepository
{
    Task<Adventure> StartAsync(int campaignId, int id);
}