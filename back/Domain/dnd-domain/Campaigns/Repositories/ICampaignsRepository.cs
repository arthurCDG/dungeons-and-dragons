using dnd_domain.Campaigns.Models;

namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task<Campaign> GetAsync(int sessionId);
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}