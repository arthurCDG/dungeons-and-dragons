using dnd_domain.Items.Models;
using dnd_domain.Players.Enums;
using System.Collections.Generic;

namespace dungeons_and_dragons.Players.DTOs;

public class MonsterDto
{
    public int SquareId { get; set; }
    public MonsterType Type { get; set; } = new();
    public List<StoredItem> StoredItems { get; set; } = [];
}
