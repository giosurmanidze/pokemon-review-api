namespace pokemon_review_api.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string userId, string username);
    }
}