using Mb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Image> Images { get; set; }
    DbSet<Movie> Movies { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Series> Series { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}