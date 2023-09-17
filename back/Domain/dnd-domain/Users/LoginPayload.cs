namespace dnd_domain.Users;

public class LoginPayload
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
