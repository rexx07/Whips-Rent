using Mb.Domain.Common;
using Mb.Domain.Entities;

namespace Mb.Domain.Event;

public class MovieReleasedEvent : DomainEvent
{
    public MovieReleasedEvent(Movie movie)
    {
        Movie = movie;
    }

    public Movie Movie { get; set; }
}