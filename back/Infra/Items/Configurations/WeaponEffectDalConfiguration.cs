using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal class WeaponEffectDalConfiguration : IEntityTypeConfiguration<WeaponEffectDal>
{
    public void Configure(EntityTypeBuilder<WeaponEffectDal> builder)
    {
        builder.ToTable("WeaponEffects", "Items");

        builder.HasKey(a => a.Id);

        builder.HasOne<WeaponDal>()
            .WithMany(weapon => weapon.Effects)
            .HasForeignKey(effect => effect.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}