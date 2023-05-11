using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal class ArtefactEffectDalConfiguration : IEntityTypeConfiguration<ArtefactEffectDal>
{
    public void Configure(EntityTypeBuilder<ArtefactEffectDal> builder)
    {
        builder.ToTable("ArtefactEffects", "Items");

        builder.HasKey(artefactEffect => artefactEffect.Id);

        builder.Property(artefactEffect => artefactEffect.Effect).HasConversion(new EnumToStringConverter<ArtefactEffectType>());

        builder.HasOne<ArtefactDal>()
            .WithMany(a => a.Effects)
            .HasForeignKey(artefactEffect => artefactEffect.ArtefactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
