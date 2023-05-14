using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class StoredItemDalConfiguration : IEntityTypeConfiguration<StoredItemDal>
{
    public void Configure(EntityTypeBuilder<StoredItemDal> builder)
    {
        builder.ToTable("StoredItems", ProjectSchema.Items);

        builder.HasKey(storedItem => storedItem.Id);

        builder.HasOne<HeroDal>()
            .WithMany(hero => hero.StoredItems)
            .HasForeignKey(storedItem => storedItem.HeroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MonsterDal>()
            .WithMany(monster => monster.StoredItems)
            .HasForeignKey(storedItem => storedItem.MonsterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SpellDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.SpellId);

        builder.HasOne<WeaponDal>()
            .WithOne()
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.WeaponId);
    }
}
