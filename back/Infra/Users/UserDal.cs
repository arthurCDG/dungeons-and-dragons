using dnd_domain.Users;
using dnd_infra.Players.DALs;
using System;
using System.Collections.Generic;

namespace dnd_infra.Users;

internal sealed class UserDal
{
    public int Id { get; set; }
    public bool IsAvailable { get; set; } = false;
    public required string Name { get; set; }
    public required byte[] PasswordHash { get; set; }
    public string? PasswordResetToken { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public string? PictureUrl { get; set; }
    public DateTimeOffset? ResetTokenExpirationDate { get; set; }

    public List<PlayerDal> Players { get; set; } = new();

    public User ToDomain()
        => new()
        {
            Id = Id,
            PictureUrl = PictureUrl,
            Name = Name,
            Players = Players.ConvertAll(p => p.ToDomain())
        };
}
