using System.Globalization;
using CsvHelper.Configuration;
using Mb.Application.Dto;

namespace Mb.Infrastructure.Files.Maps;

public sealed class SeriesMap: ClassMap<SeriesDto>
{
    public SeriesMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
    }
}