using dnd_domain.Campaigns.Adventures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

public interface ICreatableAdventuresService
{
    Task<List<CreatableAdventure>> GetAsync(int campaignId);
}