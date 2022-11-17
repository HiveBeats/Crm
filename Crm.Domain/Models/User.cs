using Crm.Domain.Services.Password;
using System;

namespace Crm.Domain.Models;
public class User
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }

    public Employee Employee { get; set; }

    public static (User, string) CreateForEmployee(Employee employee, string email)
    {
        var password = PasswordGenerator.GeneratePassword();
        var hashedPassword = PasswordHasher.GenerateSaltedHash(64, password);
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = email,
            Employee = employee,
            HashedPassword = hashedPassword.Hash,
            Salt = hashedPassword.Salt,
        };
        return (user, password);
    }
}
