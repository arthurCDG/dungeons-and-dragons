using dnd_domain.Players.Models;

namespace dnd_domain.GameFlow.Models;

public class CurrentPlayer
{
    public int AdventureId { get; set; }
    public required Player Player { get; set; }
}
