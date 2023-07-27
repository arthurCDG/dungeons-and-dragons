using dnd_domain.Campaigns.Enums;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Adventure
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public AdventureStatus Status { get; set; }


    public List<Room> Rooms { get; set; } = new();
}
