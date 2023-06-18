using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Players.DALs;
using System.Collections.Generic;

namespace dnd_infra.Campaigns.Adventures;

internal class AdventureDal
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }

    public List<PlayerDal> Players { get; set; } = new();
    public List<RoomDal> Rooms { get; set; } = new();

    public Adventure ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Name = Name,
            Type = Type,
            Players = Players.ConvertAll(p => p.ToDomain()),
            Rooms = Rooms.ConvertAll(p => p.ToDomain())
        };
}
