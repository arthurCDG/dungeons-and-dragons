using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellDalConfiguration : IEntityTypeConfiguration<SpellDal>
{
    public void Configure(EntityTypeBuilder<SpellDal> builder)
    {
        builder.ToTable("Spells", "Items");

        builder.HasKey(a => a.Id);
    }
}