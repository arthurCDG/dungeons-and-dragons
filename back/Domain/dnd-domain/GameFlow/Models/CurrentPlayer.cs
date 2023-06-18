using dnd_domain.Players.Models;

namespace dnd_domain.GameFlow.Models;

public class CurrentPlayer
{
    public int AdventureId { get; set; }
    public Player Player { get; set; } = new();
}
