using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mb.Infrastructure.Persistence.Configurations;

public class SeriesConfig: IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");

        builder.HasOne(s => s.Category)
            .WithMany()
            .HasForeignKey(s => s.CategoryId);
        
        builder.Property(s => s.Title)
            .HasColumnName("Movie Title")
            .IsRequired();
        
        builder.Property(s => s.Description)
            .HasColumnName("Movie Description")
            .IsRequired();
        
        builder.Property(s => s.Year)
            .HasColumnName("Movie Year")
            .IsRequired();
        
        builder.Property(s => s.Rating)
            .HasColumnName("Movie Rating")
            .IsRequired();
    }
}