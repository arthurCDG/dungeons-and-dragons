using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class PlayerCreationPayload
{
    public int UserId { get; set; }
    public PlayerType PlayerType { get; set; }
}
