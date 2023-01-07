using Mapster;
using Mb.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Mb.Application.Common.Mapping;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);
    }

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable,
        TypeAdapterConfig configuration, CancellationToken cancellationToken)
    {
        return queryable.ProjectToType<TDestination>(configuration).ToListAsync(cancellationToken);
    }
}