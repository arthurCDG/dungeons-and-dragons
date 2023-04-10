using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal class WeaponDalConfiguration : IEntityTypeConfiguration<WeaponDal>
{
    public void Configure(EntityTypeBuilder<WeaponDal> builder)
    {
        builder.ToTable("Weapons", "Items");

        builder.HasKey(a => a.Id);
    }
}
