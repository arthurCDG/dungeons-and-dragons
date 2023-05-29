using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

public interface ICampaignsService
{
    Task<Campaign> GetAsync(int sessionId, int campaignId);
    Task CreateAsync(int sessionId, CampaignPayload campaignPayload);
}