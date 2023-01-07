namespace Mb.Application.Dto;

public record MovieDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int Year { get; init; }
    public decimal Rating { get; init; }
    public Guid ImageId { get; init; }
    public ImageDto Image { get; init; }
    public Guid? CategoryId { get; init; }
    public CategoryDto Category { get; init; }
}