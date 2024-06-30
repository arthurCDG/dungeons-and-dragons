using dnd_domain.Items.Enums;
using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public abstract class Item
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public required string Description { get; set; }
    public required string Explanation { get; set; }
    public string? ImageUrl { get; set; }
    public int Level { get; set; }
    public string Name { get; set; } = null!;

    public List<Effect> Effects { get; set; } = new();
}
