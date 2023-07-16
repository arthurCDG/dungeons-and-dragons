using dnd_domain.Campaigns.Enums;

namespace dnd_domain.Campaigns.Models;

public class CreatableCampaign
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CampaignType Type { get; set; }
}
