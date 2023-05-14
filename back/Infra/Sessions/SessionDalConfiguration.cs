using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Sessions;

internal sealed class SessionDalConfiguration : IEntityTypeConfiguration<SessionDal>
{
    public void Configure(EntityTypeBuilder<SessionDal> builder)
    {
        builder.ToTable("Sessions", ProjectSchema.Sessions);

        builder.HasKey(a => a.Id);

        builder.Property(e => e.StartsAt)
            .HasColumnType("datetime2(2)");

        builder.Property(e => e.EndsAt)
             .HasColumnType("datetime2(2)");
    }
}
