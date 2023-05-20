using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns;

public interface ICampaignsRepository
{
    Task<Campaign> GetAsync(int sessionId, int campaignId);
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}