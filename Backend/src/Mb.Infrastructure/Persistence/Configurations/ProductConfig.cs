using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mb.Infrastructure.Persistence.Configurations;

public class ProductConfig: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(p => p.Title)
            .HasColumnName("Product Title")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("Product Description")
            .IsRequired();

        builder.Property(p => p.Year)
            .HasColumnName("Product Year")
            .IsRequired();

        builder.Property(p => p.Rating)
            .HasColumnName("Product Rating")
            .IsRequired();

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
    }
}