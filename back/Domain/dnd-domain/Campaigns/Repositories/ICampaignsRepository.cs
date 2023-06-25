using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task<Campaign> GetAsync(int campaignId);
    Task<Campaign> GetFromAdventureAsync(int adventureId);
    Task<List<Player>> GetPlayersAsync(int id);
    Task CreateAsync(CampaignPayload campaignPayload);
    Task UpdateAsync(int id, CampaignPayload campaignPayload);
}