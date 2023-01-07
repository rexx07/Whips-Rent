using Mb.Application.Dto;

namespace Mb.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildMovieFile(IEnumerable<MovieDto> movies);
    byte[] BuildSeriesFile(IEnumerable<SeriesDto> series);
}