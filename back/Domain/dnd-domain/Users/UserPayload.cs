﻿namespace dnd_domain.Users;

public class UserPayload
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }
}