using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerProfileDal
{
    public int Id { get; set; }
    public HeroClass? Class { get; set; }
    public required string FirstName { get; set; }
    public PlayerGender Gender { get; set; }
    public required string ImageUrl { get; set; }
    public string? LastName { get; set; }
    public MonsterType? MonsterType { get; set; }
    public int PlayerId { get; set; }
    public HeroRace? Race { get; set; }

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
