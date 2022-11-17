using Crm.Domain.Models;
using Crm.Domain.Services.Password;
using Crm.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using ResultMonad;

namespace Crm.Client.Application.Authentication;
public class AuthDto
{
    public string Id { get; set; } = string.Empty;
}
public interface IAuthService
{
    Task<Result<User>> IsAuthenticated();
    Task<Result<User>> Login(string username, string password);
}

public class AuthService : IAuthService
{
    private readonly CrmDbContext _db;
    private const string FileName = "auth.json";
    public AuthService(CrmDbContext db)
    {
        _db = db;
    }


    public async Task<Result<User>> IsAuthenticated()
    {
        if (File.Exists(FileName))
        {
            var fileText = File.ReadAllText(FileName);
            var auth = System.Text.Json.JsonSerializer.Deserialize<AuthDto>(fileText);
            if (auth != null)
            {
                var userId = Guid.Parse(auth.Id);
                var user = await _db.Users
                    .Include(x => x.Employee)
                    .FirstOrDefaultAsync(x => x.Id == userId);
                if (user != null)
                {
                    return Result.Ok<User>(user);
                }
            }
            return Result.Fail<User>();
        }

        return Result.Fail<User>();
    }

    public async Task<Result<User>> Login(string username, string password)
    {
        var user = await _db.Users
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Email == username);

        if (user != null && PasswordHasher.VerifyPassword(password, user.HashedPassword, user.Salt))
        {
            var authDto = new AuthDto() { Id = user.Id.ToString() };
            await File.WriteAllTextAsync(FileName, System.Text.Json.JsonSerializer.Serialize<AuthDto>(authDto));

            return Result.Ok<User>(user);
        }

        return Result.Fail<User>();
    }
}
