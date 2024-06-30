using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionDalConfiguration : IEntityTypeConfiguration<PotionDal>
{
    public void Configure(EntityTypeBuilder<PotionDal> builder)
    {
        builder.ToTable("Potions", ProjectSchema.Items);

        builder.HasKey(potion => potion.Id);

        builder.HasMany<StoredItemDal>()
               .WithOne(storedItem => storedItem.Potion)
               .HasForeignKey(storedItem => storedItem.PotionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
