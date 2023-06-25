using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerProfileDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public PlayerGender Gender { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public HeroClass? Class { get; set; }
    public HeroRace? Race { get; set; }
    public MonsterType? MonsterType { get; set; }

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
            Race = Race,
            MonsterType = MonsterType,
        };
}
