using dnd_domain.Users;
using System;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<Adventure> Adventures { get; set; } = new();
    public List<UserCampaignAssociation> AssociatedUsers { get; set; } = new();
}
