namespace Mb.Application.Dto;

public record ApplicationUserDto
{
    public string Id { get; init; }

    public string UserName { get; init; }

    public string Email { get; init; }
}