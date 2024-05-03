using pokemon_review_api.Entities;

namespace pokemon_review_api.Services
{
    public interface IAuthService
    {
    bool IsUsernameTaken(string username);
    void Register(User user);
    User Authenticate(string username, string password);
}

}