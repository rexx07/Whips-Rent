using Mb.Domain.Common;

namespace Mb.Domain.Entities;

public class Image : AuditableEntity
{
    public Image()
    {
    }

    public Image(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; set; }
    public string Url { get; set; }
}