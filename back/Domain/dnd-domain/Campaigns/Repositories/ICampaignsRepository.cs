using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task<Campaign> GetAsync(int campaignId);
    Task CreateAsync(CampaignPayload campaignPayload);
}