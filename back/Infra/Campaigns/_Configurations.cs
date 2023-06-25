using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.Configurations;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Campaigns;

internal static class CampaignsConfigurations
{
    public static void ApplyCampaignsConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CampaignDalConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureDalConfiguration());
        modelBuilder.ApplyConfiguration(new RoomDalConfiguration());
        modelBuilder.ApplyConfiguration(new SquareDalConfiguration());
        modelBuilder.ApplyConfiguration(new SquareTrapDalConfiguration());
        modelBuilder.ApplyConfiguration(new PositionDalConfiguration());
    }
}
