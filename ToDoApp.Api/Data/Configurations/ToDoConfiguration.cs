using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Api.Models;

namespace ToDoApp.Api.Data.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder
            .HasMany(t => t.Items)
            .WithOne();

        builder
            .HasOne(t => t.CreatedBy)
            .WithMany();

        builder.Property(t => t.Title)
            .HasColumnType("varchar(50)");
    }
}