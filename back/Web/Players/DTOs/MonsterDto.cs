using dnd_domain.Items.Models;
using dnd_domain.Players.Enums;
using dungeons_and_dragons.Items.DTOs;
using System.Collections.Generic;

namespace dungeons_and_dragons.Players.DTOs;

public class MonsterDto
{
    public int SquareId { get; set; }
    public MonsterType Type { get; set; } = new();
    public List<StoredItemDto> StoredItems { get; set; } = new();
}
