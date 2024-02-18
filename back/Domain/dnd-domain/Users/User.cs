using dnd_domain.Players.Models;
using System.Collections.Generic;

namespace dnd_domain.Users;

public class User
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public string? PictureUrl { get; set; }

    public List<Player> Players { get; set; } = new();
}
