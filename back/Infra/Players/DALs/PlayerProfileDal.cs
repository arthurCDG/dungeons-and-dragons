using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerProfileDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }

    public required Class Class { get; set; }
    public required string FirstName { get; set; }
    public required PlayerGender Gender { get; set; }
    public required string ImageUrl { get; set; }
    public string? LastName { get; set; }
    public required Race Race { get; set; }
    public required PlayerRole Role { get; set; }

    public PlayerProfile ToDomain()
        => new()
        {
            Id = Id,
            PlayerId = PlayerId,
            FirstName = FirstName,
            LastName = LastName,
            Gender = Gender,
            ImageUrl = ImageUrl,
            Class = Class,
            Race = Race
        };
}
