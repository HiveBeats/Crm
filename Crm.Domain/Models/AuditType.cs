using System.Collections.Generic;

namespace Crm.Domain.Models;
public class AuditType
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; }
}
