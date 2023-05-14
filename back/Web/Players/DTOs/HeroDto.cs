using dnd_domain.Items.Models;
using dnd_domain.Players.Enums;
using dungeons_and_dragons.Items.DTOs;
using System.Collections.Generic;

namespace dungeons_and_dragons.Players.DTOs;

public class HeroDto : PlayerDto
{
    public int SquareId { get; set; }
    public HeroClass Class { get; set; }
    public HeroRace Race { get; set; }
    public List<StoredItemDto> StoredItems { get; set; } = new();
}
