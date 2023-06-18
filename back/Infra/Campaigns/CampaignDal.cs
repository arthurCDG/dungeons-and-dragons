using dnd_domain.Campaigns.Models;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Users;
using System;
using System.Collections.Generic;

namespace dnd_infra.Campaigns;

internal sealed class CampaignDal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<AdventureDal> Adventures { get; set; } = new();
    public List<UserCampaignAssociationDal> AssociatedUsers { get; set; } = new();

    public Campaign ToDomain()
        => new()
        {
            Id = Id,
            StartsAt = StartsAt,
            EndsAt = EndsAt,
            Adventures = Adventures.ConvertAll(a => a.ToDomain()),
            AssociatedUsers = AssociatedUsers.ConvertAll(au => au.ToDomain())
        };
}
