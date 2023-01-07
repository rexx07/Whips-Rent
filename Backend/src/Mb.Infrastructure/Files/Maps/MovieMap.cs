using System.Globalization;
using CsvHelper.Configuration;
using Mb.Application.Dto;

namespace Mb.Infrastructure.Files.Maps;

public sealed class MovieMap: ClassMap<MovieDto>
{
    public MovieMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
    }
}