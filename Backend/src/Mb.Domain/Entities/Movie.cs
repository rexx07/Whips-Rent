using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Movie : AuditableEntity, IHasDomainEvent
{
    public Movie()
    {
    }

    public Movie(string title, string description, int year, decimal rating, Guid imageId, Guid categoryId)
    {
        DomainEvents = new List<DomainEvent>();
        Title = title;
        Description = description;
        Year = year;
        Rating = rating;
        CreatedOn = DateTime.Now;
        ImageId = imageId;
        CategoryId = categoryId;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public decimal Rating { get; set; }
    public Guid ImageId { get; set; }
    public Image Image { get; set; }
    public Guid? CategoryId { get; set; }
    public Category Category { get; set; }
    public List<DomainEvent> DomainEvents { get; set; }
}