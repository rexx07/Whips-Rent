using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mb.Infrastructure.Persistence.Configurations;

public class MovieConfig: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.Property(m => m.Title)
            .HasColumnName("Movie Title")
            .IsRequired();

        builder.Property(m => m.Description)
            .HasColumnName("Movie Description")
            .IsRequired();

        builder.Property(m => m.Year)
            .HasColumnName("Movie Year")
            .IsRequired();

        builder.Property(m => m.Rating)
            .HasColumnName("Movie Rating")
            .IsRequired();

        builder.Property(m => m.Image)
            .HasColumnName("Movie Image Cover")
            .IsRequired();

        builder.HasOne(m => m.Category)
            .WithMany()
            .HasForeignKey(m => m.CategoryId);
    }
}