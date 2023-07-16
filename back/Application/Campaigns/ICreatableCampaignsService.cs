using dnd_domain.Campaigns.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

public interface ICreatableCampaignsService
{
    Task<List<CreatableCampaign>> GetAsync(int playerId);
}