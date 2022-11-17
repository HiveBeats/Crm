using Crm.Domain.Models;

namespace Crm.Client.Application.Authentication;
public interface IAuthConfiguration
{
    User AuthenticatedUser { get; }
    bool IsAuthenticated { get; }
}
public class AuthConfiguration : IAuthConfiguration
{
    public User AuthenticatedUser { get; set; }
    public bool IsAuthenticated { get; set; }
}
