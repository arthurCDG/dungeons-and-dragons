using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class StoredItemDalConfiguration : IEntityTypeConfiguration<StoredItemDal>
{
    public void Configure(EntityTypeBuilder<StoredItemDal> builder)
    {
        builder.ToTable("StoredItems", "Items");

        builder.HasKey(storedItem => storedItem.Id);

        builder.HasOne<HeroDal>()
            .WithMany()
            .HasForeignKey(storedItem => storedItem.HeroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(storedItem => storedItem.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ArtefactDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.ArtefactId);

        builder.HasOne<PotionDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.PotionId);

        builder.HasOne<SpellDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.SpellId);

        builder.HasOne<WeaponDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.WeaponId);
    }
}
