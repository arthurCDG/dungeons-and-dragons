using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Dice;

internal sealed class DieDalConfiguration : IEntityTypeConfiguration<DieDal>
{
    public void Configure(EntityTypeBuilder<DieDal> builder)
    {
        builder.ToTable("Dice", "dbo"); // Other project schema ?

        builder.HasKey(a => a.Id);
    }
}
