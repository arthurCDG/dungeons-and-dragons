using dnd_domain.Campaigns.Enums;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Adventure
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsCompleted { get; set; } = false;

    public List<Room> Rooms { get; set; } = new();
}
