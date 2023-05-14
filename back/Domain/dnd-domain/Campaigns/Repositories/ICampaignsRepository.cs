namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}