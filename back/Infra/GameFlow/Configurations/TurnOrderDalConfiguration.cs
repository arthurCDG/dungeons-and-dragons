using dnd_infra.GameFlow.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.GameFlow.Configurations;

internal sealed class TurnOrderDalConfiguration : IEntityTypeConfiguration<TurnOrderDal>
{
    public void Configure(EntityTypeBuilder<TurnOrderDal> builder)
    {
        builder.ToTable("TurnOrders", ProjectSchema.GameFlow);

        builder.HasKey(turnOrder => turnOrder.Id);

        builder.HasOne<PlayerDal>()
            .WithOne(h => h.TurnOrder)
            .HasForeignKey<TurnOrderDal>(turnOrder => turnOrder.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
