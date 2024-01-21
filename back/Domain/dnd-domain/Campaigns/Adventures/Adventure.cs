using dnd_domain.Campaigns.Adventures.Rooms;
using System;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Adventures;

public class Adventure
{
    public int Id { get; set; }
    public required int CampaignId { get; set; }
    public required string Name { get; set; }
    public required AdventureType Type { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<Room> Rooms { get; set; } = new();
}
