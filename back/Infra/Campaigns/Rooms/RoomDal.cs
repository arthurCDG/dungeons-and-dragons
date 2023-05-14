using dnd_infra.Campaigns.Rooms.Squares.DALs;
using System.Collections.Generic;

namespace dnd_infra.Campaigns.Rooms;

internal sealed class RoomDal
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public List<SquareDal> Squares { get; set; } = new();

    public bool? IsStartRoom { get; set; }
}
