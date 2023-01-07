using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Product : AuditableEntity, IHasDomainEvent
{
    public Product()
    {
    }

    public Product(string title, string description, string year, decimal rating, double price, double price50,
        double price100, double listPrice, Guid categoryId)
    {
        DomainEvents = new List<DomainEvent>();
        Title = title;
        Description = description;
        Year = year;
        Rating = rating;
        Price = price;
        Price50 = price50;
        Price100 = price100;
        ListPrice = listPrice;
        CategoryId = categoryId;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }
    public decimal Rating { get; set; }
    public Guid ImageId { get; set; }
    public Image Image { get; set; }
    public double ListPrice { get; set; }
    public double Price { get; set; }
    public double Price50 { get; set; }
    public double Price100 { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public List<DomainEvent> DomainEvents { get; set; }
}