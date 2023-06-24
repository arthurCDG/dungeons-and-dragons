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

    public Task<Campaign> GetAsync(int campaignId)
        => _campaignsRepository.GetAsync(campaignId);

    public Task CreateAsync(CampaignPayload campaignPayload)
        => _campaignsRepository.CreateAsync(campaignPayload);

    public Task UpdateAsync(int id, CampaignPayload campaignPayload)
        => _campaignsRepository.UpdateAsync(id, campaignPayload);
}
