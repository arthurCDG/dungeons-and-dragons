using dnd_domain.Users;
using dnd_infra.Players.DALs;
using System.Collections.Generic;

namespace dnd_infra.Users;

internal sealed class UserDal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
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
