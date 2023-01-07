namespace Mb.Application.Dto;

public record ImageDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Url { get; init; }
}