using dnd_domain.Campaigns;

namespace dnd_services.Campaigns;

public interface ICampaignsService
{
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}