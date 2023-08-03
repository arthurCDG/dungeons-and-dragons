using dnd_domain.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Campaigns.Adventures.Rooms;

internal sealed class RoomDal
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public List<SquareDal> Squares { get; set; } = new();

    public bool? IsStartRoom { get; set; }

    public Room ToDomain()
        => new()
        {
            Id = Id,
            AdventureId = AdventureId,
            IsStartRoom = IsStartRoom,
            Squares = Squares.Select(s => s.ToDomain()).ToList()
        };
}
