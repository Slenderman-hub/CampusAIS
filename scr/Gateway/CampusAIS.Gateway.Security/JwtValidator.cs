namespace CampusAIS.Gateway.Security;

public class JwtValidator
{
    // Заглушка для проверки токена
    public bool ValidateToken(string token) => !string.IsNullOrEmpty(token);
}