using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ChestTrapDalConfiguration : IEntityTypeConfiguration<ChestTrapDal>
{
    public void Configure(EntityTypeBuilder<ChestTrapDal> builder)
    {
        builder.ToTable("ChestTraps", "Items");

        builder.HasKey(a => a.Id);
    }
}
