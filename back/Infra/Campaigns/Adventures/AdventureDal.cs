using dnd_domain.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using System.Collections.Generic;

namespace dnd_infra.Campaigns.Adventures;

internal class AdventureDal
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public AdventureStatus Status { get; set; }

    public List<RoomDal> Rooms { get; set; } = new();

    public Adventure ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Name = Name,
            Type = Type,
            Status = Status,
            Rooms = Rooms.ConvertAll(p => p.ToDomain())
        };
}
