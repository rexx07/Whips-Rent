using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Category : AuditableEntity
{
    public Category()
    {
    }

    public Category(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; set; }
    public string Description { get; set; }
}