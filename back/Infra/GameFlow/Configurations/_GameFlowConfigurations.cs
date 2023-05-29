using Microsoft.EntityFrameworkCore;

namespace dnd_infra.GameFlow.Configurations;

internal static class _GameFlowConfigurations
{
    public static void ApplyGameFlowConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CurrentPlayerDalConfiguration());
        modelBuilder.ApplyConfiguration(new TurnOrderDalConfiguration());
        modelBuilder.ApplyConfiguration(new ActionsDalConfiguration());
    }
}