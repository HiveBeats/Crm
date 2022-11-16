﻿using Crm.Models.Infrastructure.Password;

namespace Crm.Models.Domain;
public class User
{
    public long Id { get; set; }
    public long EmployeeId { get; set; }
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
            Email = email,
            Employee = employee,
            HashedPassword = hashedPassword.Hash,
            Salt = hashedPassword.Salt,
        };
        return (user, password);
    }
}
