using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerProfileDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }

    public required Class Class { get; set; }
    public required PlayerGender Gender { get; set; }
    public string? ImageUrl { get; set; }
    public required string Name { get; set; }
    public required Race Race { get; set; }
    public required PlayerRole Role { get; set; }

    public PlayerProfile ToDomain()
        => new()
        {
            Id = Id,
            PlayerId = PlayerId,
            Class = Class,
            Gender = Gender,
            ImageUrl = ImageUrl,
            Name = Name,
            Race = Race
        };
}
