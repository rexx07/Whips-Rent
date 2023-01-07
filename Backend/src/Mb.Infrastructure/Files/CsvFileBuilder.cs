using System.Globalization;
using System.Text;
using CsvHelper;
using Mb.Application.Common.Interfaces;
using Mb.Application.Dto;
using Mb.Infrastructure.Files.Maps;

namespace Mb.Infrastructure.Files;

public class CsvFileBuilder: ICsvFileBuilder
{
    public byte[] BuildMovieFile(IEnumerable<MovieDto> movies)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<MovieMap>();
            csvWriter.WriteRecord(movies);
        }

        return memoryStream.ToArray();
    }

    public byte[] BuildSeriesFile(IEnumerable<SeriesDto> series)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<SeriesMap>();
            csvWriter.WriteRecord(series);
        }

        return memoryStream.ToArray();
    }
}