using dnd_infra.Items.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ChestTrapDalConfiguration : IEntityTypeConfiguration<ChestTrapDal>
{
    public void Configure(EntityTypeBuilder<ChestTrapDal> builder)
    {
        builder.ToTable("ChestTraps", "Items");

        builder.HasKey(chestTtap => chestTtap.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(chestTtap => chestTtap.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
