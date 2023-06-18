using dnd_domain.Campaigns.Enums;
using dnd_domain.Players.Models;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Adventure
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }

    public List<Player> Players { get; set; } = new();
    public List<Room> Rooms { get; set; } = new();
}
