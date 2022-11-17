using System;

namespace Crm.Domain.Models;
public class AuditLog
{
    public AuditLog(AuditType type, string message)
    {
        Id = Guid.NewGuid();
        Type = type;
        Message = message;
    }

    public Guid Id { get; set; }
    public Guid AuditTypeId { get; set; }
    public string Message { get; set; }

    public AuditType Type { get; set; }
}
