using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Models;
using System;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

internal sealed class CampaignsService : ICampaignsService
{
    private readonly ICampaignsRepository _campaignsRepository;

    public CampaignsService(ICampaignsRepository campaignsRepository)
    {
        _campaignsRepository = campaignsRepository ?? throw new ArgumentNullException(nameof(campaignsRepository));
    }

    public Task<Campaign> GetAsync(int sessionId, int campaignId)
        => _campaignsRepository.GetAsync(sessionId, campaignId);

    public Task CreateAsync(int sessionId, CampaignPayload campaignPayload)
        => _campaignsRepository.CreateAsync(sessionId, campaignPayload);
}
