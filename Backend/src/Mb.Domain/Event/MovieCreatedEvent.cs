using Mb.Domain.Common;
using Mb.Domain.Entities;

namespace Mb.Domain.Event;

public class MovieCreatedEvent: DomainEvent
{
    public MovieCreatedEvent(Movie movie)
    {
        Movie = movie;
    }
    
    public Movie Movie { get; }
}