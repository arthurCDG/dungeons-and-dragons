using dnd_domain.Users;
using dnd_infra.Players.DALs;
using System.Collections.Generic;

namespace dnd_infra.Users;

internal sealed class UserDal
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string? PictureUrl { get; set; }
    public string? NickName { get; set; }

    public List<PlayerDal> Players { get; set; } = new();

    public User ToDomain()
        => new()
        {
            Id = Id,
            FirstName = FirstName,
            LastName = LastName,
            PictureUrl = PictureUrl,
            NickName = NickName,
            Players = Players.ConvertAll(p => p.ToDomain())
        };
}
