using dnd_domain.Campaigns.Enums;

namespace dnd_domain.Campaigns.Models;

public class CreatableCampaign
{
    public required string Description { get; set; }
    public required string Name { get; set; }
    public required int MaxPlayers { get; set; }
    public required CampaignType Type { get; set; }
    public required bool CanBeCreated { get; set; }
}
