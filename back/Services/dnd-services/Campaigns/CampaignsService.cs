using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Models;

namespace dnd_services.Campaigns;

internal sealed class CampaignsService : ICampaignsService
{
    private readonly ICampaignsRepository _campaignsRepository;

    public CampaignsService(ICampaignsRepository campaignsRepository)
    {
        _campaignsRepository = campaignsRepository ?? throw new ArgumentNullException(nameof(campaignsRepository));
    }

    public Task<Campaign> GetAsync(int sessionId)
        => _campaignsRepository.GetAsync(sessionId);

    public Task CreateAsync(int sessionId, CampaignPayload campaignPayload)
        => _campaignsRepository.CreateAsync(sessionId, campaignPayload);
}
