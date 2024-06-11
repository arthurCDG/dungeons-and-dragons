using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_domain.Users;

public class User
{
    public required int Id { get; set; }
    public bool IsAvailable { get; set; } = false;
    public required string Name { get; set; }
    public string? PictureUrl { get; set; }

    public List<Player> Players { get; set; } = new();

    public bool IsDungeonMaster => Players.Any(p => p.Profile?.Role == PlayerRole.Monster);
}
