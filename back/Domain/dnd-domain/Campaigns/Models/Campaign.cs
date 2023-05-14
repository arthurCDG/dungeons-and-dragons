using dnd_domain.Campaigns.Enums;
using dnd_domain.Players.Models;

namespace dnd_domain.Campaigns.Models;

public class Campaign
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public Adventure Adventure { get; set; }

    public List<Room> Rooms { get; set; } = new();
    public List<Hero> Heroes { get; set; } = new();
    public List<Monster> Monsters { get; set; } = new();
}
