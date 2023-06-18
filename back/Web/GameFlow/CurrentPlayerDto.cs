using dnd_domain.GameFlow.Models;
using dnd_domain.Players.Models;

namespace dungeons_and_dragons.GameFlow;

public class CurrentPlayerDto
{
    public int AdventureId { get; set; }
    public Player? Player { get; set; }

    public static CurrentPlayerDto FromDomain(CurrentPlayer currentPlayer)
        => new()
        {
            AdventureId = currentPlayer.AdventureId,
            Player = currentPlayer.Player
        };
}
