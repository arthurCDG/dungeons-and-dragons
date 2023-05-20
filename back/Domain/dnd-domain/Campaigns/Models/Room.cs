using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Room
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public List<Square> Squares { get; set; } = new();

    public bool? IsStartRoom { get; set; }
}
