using Mb.Domain.Common;
using Mb.Domain.Entities;

namespace Mb.Domain.Event;

public class SeriesReleasedEvent : DomainEvent
{
    public SeriesReleasedEvent(Series series)
    {
        Series = series;
    }

    public Series Series { get; set; }
}