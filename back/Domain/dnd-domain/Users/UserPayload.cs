namespace dnd_domain.Users;

public class UserPayload
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PictureUrl { get; set; }
}