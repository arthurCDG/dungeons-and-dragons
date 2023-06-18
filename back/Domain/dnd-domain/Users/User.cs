using dnd_domain.Players.Models;
using System.Collections.Generic;

namespace dnd_domain.Users;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }
    public string? NickName { get; set; }

    public List<Player> Players { get; set; } = new();
}
