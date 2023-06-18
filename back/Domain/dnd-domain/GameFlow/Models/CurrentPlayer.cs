using dnd_domain.Players.Models;

namespace dnd_domain.GameFlow.Models;

public class CurrentPlayer
{
    public int CampaignId { get; set; }
    public Hero? Hero { get; set; }
    public Monster? Monster { get; set; }
}
