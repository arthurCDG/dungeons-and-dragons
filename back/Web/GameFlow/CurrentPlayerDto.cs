using dnd_domain.Players.Models;

namespace dungeons_and_dragons.GameFlow;

public class CurrentPlayerDto
{
    public int CampaignId { get; set; }
    public int? HeroId { get; set; }
    public Hero? Hero { get; set; }
    public int? MonsterId { get; set; }
    public Monster? Monster { get; set; }
}
