using dnd_domain.Players.Models;
using System.Collections.Generic;

namespace dnd_domain.Users;

public class UserPayload
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }

    public List<PlayerCreationPayload> PlayerPayloads { get; set; } = new();
}