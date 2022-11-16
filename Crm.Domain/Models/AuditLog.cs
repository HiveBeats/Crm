namespace Crm.Domain.Models;
public class AuditLog
{
    public long Id { get; set; }
    public long AuditTypeId { get; set; }
    public string Message { get; set; }
}
