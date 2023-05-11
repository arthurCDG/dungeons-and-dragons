using dnd_infra.Items.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionDalConfiguration : IEntityTypeConfiguration<PotionDal>
{
    public void Configure(EntityTypeBuilder<PotionDal> builder)
    {
        builder.ToTable("Potions", "Items");

        builder.HasKey(potion => potion.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(potion => potion.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StoredItemDal>()
            .WithOne(storedItem => storedItem.Potion)
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.PotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
