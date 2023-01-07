using Mb.Application.Dto;

namespace Mb.Application.ApplicationUser;

public class LoginResponse
{
    public ApplicationUserDto User { get; set; }
    public string Token { get; set; }
}