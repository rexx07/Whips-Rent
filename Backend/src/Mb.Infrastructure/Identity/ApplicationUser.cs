using Microsoft.AspNetCore.Identity;

namespace Mb.Infrastructure.Identity;

public class ApplicationUser: IdentityUser
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}