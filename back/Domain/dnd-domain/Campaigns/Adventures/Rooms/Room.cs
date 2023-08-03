using System.Collections.Generic;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;

namespace dnd_domain.Campaigns.Adventures.Rooms;

public class Room
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public List<Square> Squares { get; set; } = new();

    public bool? IsStartRoom { get; set; }
}
