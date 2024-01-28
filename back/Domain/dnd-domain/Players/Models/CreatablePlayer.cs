using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class CreatablePlayer
{
    public required Class Class { get; set; }
    public required string Description { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required PlayerMaxAttributes MaxAttributes { get; set; }
    public required Race Race { get; set; }
    public required PlayerRole Role { get; set; }
    public required PlayerType Type { get; set; }
}
