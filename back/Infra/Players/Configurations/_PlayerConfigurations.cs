using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Players.Configurations;

internal static class _PlayerConfigurations
{
    public static void ApplyPlayerConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlayerDalConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerProfileDalConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerAttributesDalConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerMaxAttributesDalConfiguration());
    }
}
