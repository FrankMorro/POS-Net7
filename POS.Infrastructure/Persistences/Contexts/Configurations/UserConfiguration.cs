using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Domain.Entities;

namespace POS.Infrastructure.Persistences.Contexts.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CF070A35E");

        builder.Property(e => e.Email).IsUnicode(false);
        builder.Property(e => e.Image).IsUnicode(false);
        builder.Property(e => e.Password).IsUnicode(false);
        builder.Property(e => e.UserName)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
