using dnd_domain.GameFlow.Models;
using dnd_infra.Players.DALs;

namespace dnd_infra.GameFlow.DALs;

internal sealed class CurrentPlayerDal
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public int PlayerId { get; set; }
    public PlayerDal Player { get; set; } = new();

    public CurrentPlayer ToDomain()
        => new()
        {
            AdventureId = AdventureId,
            Player = Player.ToDomain(),
        };
}
