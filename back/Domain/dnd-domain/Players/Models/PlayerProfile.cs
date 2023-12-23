using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class PlayerProfile
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
}
