using System;
using System.Collections.Generic;

namespace Crm.Domain.Models;
public class AuditType
{
    public AuditType(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; }
}
