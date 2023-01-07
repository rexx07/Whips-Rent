namespace Mb.Application.Dto;

public record CategoryDto
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public string Description { get; init; }
}