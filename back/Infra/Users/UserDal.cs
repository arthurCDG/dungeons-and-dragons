using dnd_domain.Users;
using dnd_infra.Players.DALs;
using System.Collections.Generic;

namespace dnd_infra.Users;

internal sealed class UserDal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }

    public List<PlayerDal> Players { get; set; } = new();

    public User ToDomain()
        => new()
        {
            Id = Id,
            Password = Password,
            PictureUrl = PictureUrl,
            Name = Name,
            Players = Players.ConvertAll(p => p.ToDomain())
        };
}
