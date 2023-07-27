using dnd_domain.Campaigns.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

public interface ICampaignsService
{
    Task<List<Campaign>> GetAsync(int playerId);
    Task<Campaign> GetByIdAsync(int campaignId);
    Task<Campaign> GetFromAdventureAsync(int adventureId);
    Task CreateAsync(CampaignPayload campaignPayload);
    Task UpdateAsync(int id, CampaignPayload campaignPayload);
}