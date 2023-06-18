using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

public interface ICampaignsService
{
    Task<Campaign> GetAsync(int campaignId);
    Task CreateAsync(CampaignPayload campaignPayload);
}