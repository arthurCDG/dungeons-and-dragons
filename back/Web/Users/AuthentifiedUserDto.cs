namespace dungeons_and_dragons.Users;

public class AuthentifiedUserDto
{
    public required int UserId { get; set; }
    public required string? Token { get; set; }
}
