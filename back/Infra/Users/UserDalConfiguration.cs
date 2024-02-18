using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Users;

internal sealed class UserDalConfiguration : IEntityTypeConfiguration<UserDal>
{
    public void Configure(EntityTypeBuilder<UserDal> builder)
    {
        builder.ToTable("Users", ProjectSchema.Users);

        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Players)
               .WithOne()
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
