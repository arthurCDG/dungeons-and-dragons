using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class CreatablePlayer
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PlayerType PlayerType { get; set; }
    public PlayerMaxAttributes MaxAttributes { get; set; } = null!;
}
