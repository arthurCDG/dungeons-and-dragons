using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

internal sealed class CampaignsService(ICampaignsRepository campaignsRepository) : ICampaignsService
{
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;

    public Task<List<Campaign>> GetAsync(int playerId)
        => _campaignsRepository.GetAsync(playerId);

    public Task<Campaign> GetByIdAsync(int campaignId)
        => _campaignsRepository.GetByIdAsync(campaignId);

    public Task<Campaign> GetFromAdventureAsync(int adventureId)
        => _campaignsRepository.GetFromAdventureAsync(adventureId);

    public Task<Campaign> CreateAsync(CampaignPayload campaignPayload)
        => _campaignsRepository.CreateAsync(campaignPayload);

    public Task UpdateAsync(int id, CampaignPayload campaignPayload)
        => _campaignsRepository.UpdatePlayersAsync(id, campaignPayload);
}
