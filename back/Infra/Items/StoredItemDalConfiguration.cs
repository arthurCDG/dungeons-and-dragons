using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items;

internal sealed class StoredItemDalConfiguration : IEntityTypeConfiguration<StoredItemDal>
{
    public void Configure(EntityTypeBuilder<StoredItemDal> builder)
    {
        builder.ToTable("StoredItems", ProjectSchema.Items);

        builder.HasKey(storedItem => storedItem.Id);

        builder.HasOne<PlayerDal>()
               .WithMany(hero => hero.StoredItems)
               .HasForeignKey(storedItem => storedItem.PlayerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
