using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Players.Configurations;

internal static class PlayersConfigurations
{
    public static void ApplyPlayersConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HeroDalConfiguration());
        modelBuilder.ApplyConfiguration(new MonsterDalConfiguration());
    }
}
