using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class PlayerProfile
{
    public int Id { get; set; }
    public int PlayerId { get; set; }

    public required Class Class { get; set; }
    public required string FirstName { get; set; }
    public required PlayerGender Gender { get; set; }
    public string? ImageUrl { get; set; }
    public string? LastName { get; set; }
    public required Race Race { get; set; }
}
