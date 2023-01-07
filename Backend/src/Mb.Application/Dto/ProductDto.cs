namespace Mb.Application.Dto;

public record ProductDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Year { get; init; }
    public decimal Rating { get; init; }
    public Guid ImageId { get; init; }
    public ImageDto Image { get; init; }
    public double ListPrice { get; init; }
    public double Price { get; init; }
    public double Price50 { get; init; }
    public double Price100 { get; init; }
    public Guid CategoryId { get; init; }
    public CategoryDto Category { get; init; }
}