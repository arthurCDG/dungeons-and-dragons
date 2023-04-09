using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionDalConfiguration : IEntityTypeConfiguration<PotionDal>
{
    public void Configure(EntityTypeBuilder<PotionDal> builder)
    {
        builder.ToTable("Potions", "Items");

        builder.HasKey(a => a.Id);
    }
}