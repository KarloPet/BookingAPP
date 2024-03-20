using BookingAPP.Data;
using BookingAPP.Models;
using Microsoft.EntityFrameworkCore;


public class UserService
{
    private readonly BookingContext _context;

    public UserService(BookingContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUser(string email, string password, string firstName, string lastName)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (existingUser != null)
        {
            // Korisnik s ovim emailom već postoji
            return false;
        }

        var passwordHash = HashPassword(password);

        var user = new User
        {
            Email = email,
            PasswordHash = passwordHash,
            FirstName = firstName,
            LastName = lastName,
            PermissionLevel = "user" // Pretpostavimo osnovnu razinu permisija
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<User> LoginUser(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null && VerifyPasswordHash(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}
