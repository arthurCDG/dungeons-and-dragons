using dnd_domain.Campaigns.Models;

namespace dnd_services.Campaigns;

public interface ICampaignsService
{
    Task<Campaign> GetAsync(int sessionId);
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}