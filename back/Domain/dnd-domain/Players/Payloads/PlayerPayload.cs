using dnd_domain.Items.Models;

namespace dnd_domain.Players.Payloads;

public class PlayerPayload
{
    public int? LifePoints { get; set; }
    public int? ManaPoints { get; set; }
    public int? FootSteps { get; set; }
    public int? Shield { get; set; }
    public string? ImageUrl { get; set; }
}
