using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class RoomDto
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public List<SquareDto> Squares { get; set; } = new();

    public bool? IsStartRoom { get; set; }
}
