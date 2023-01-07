using Mb.Domain.Common;
using Mb.Domain.Entities;

namespace Mb.Domain.Event;

public class ProductReleasedEvent : DomainEvent
{
    public ProductReleasedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; set; }
}