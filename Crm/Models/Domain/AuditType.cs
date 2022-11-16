using System.Collections.Generic;

namespace Crm.Models.Domain;
public class AuditType
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; }
}
