namespace CampusAIS.Client.Security.Auth;

public interface ITokenProvider
{
    string? GetToken();
}

public class AuthService : ITokenProvider
{
    public string? GetToken()
    {
        // Заглушка: в реальности тут будет логика получения токена
        return "fake-jwt-token-12345";
    }
}