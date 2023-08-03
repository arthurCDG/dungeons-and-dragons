using dnd_domain.Campaigns.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task<List<Campaign>> GetAsync(int playerId);
    Task<Campaign> GetByIdAsync(int campaignId);
    Task<Campaign> GetFromAdventureAsync(int adventureId);
    Task<Campaign> CreateAsync(CampaignPayload campaignPayload);
    Task UpdatePlayersAsync(int id, CampaignPayload campaignPayload);
}