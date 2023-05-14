namespace dnd_domain.Fields.Models;

public class Square
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public Position Position { get; set; } = new();
}
