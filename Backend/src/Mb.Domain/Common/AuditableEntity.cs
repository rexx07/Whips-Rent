﻿using System.ComponentModel.DataAnnotations;

namespace Mb.Domain.Common;

public class AuditableEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedOn { get; set; }
    public string DeletedBy { get; set; }
}