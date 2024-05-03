using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using pokemon_review_api.Services;

public class AuthService 
{
    private readonly IAuthService _userRepository;

    public AuthService(IAuthService userRepository)
    {
        _userRepository = userRepository;
    }



    private bool VerifyPassword(string password, string hashedPassword)
    {
        // In a real-world scenario, you would compare the provided password hash with the stored hash
        // using a secure password hashing algorithm like bcrypt.
        // For simplicity, we'll compare the plain-text password with the hashed password here.
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(password)) == hashedPassword;
    }
}

