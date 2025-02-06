using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Username)
            .HasColumnType($"varchar({User.MaxUsernameLength})");
        builder.Property(u => u.Password)
            .HasColumnType($"varchar({User.MaxPasswordLength})");

        builder.HasIndex(u => u.Username)
            .IsUnique();
    }
}