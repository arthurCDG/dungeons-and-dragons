﻿using dnd_domain.Campaigns.Adventures.Rooms;
using System;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Adventures;

public class Adventure
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<Room> Rooms { get; set; } = new();
}
