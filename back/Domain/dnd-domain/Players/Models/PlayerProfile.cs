using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class PlayerProfile
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
}
