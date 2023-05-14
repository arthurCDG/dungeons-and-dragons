namespace dnd_domain.Campaigns.Models;

public class Square
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Position Position { get; set; } = new();

    public bool? IsDoor { get; set; }
    public bool? IsHeroStartingSquare { get; set; }
    public bool? IsMonsterStartingSquare { get; set; }
    public SquareTrap? Trap { get; set; }
}
