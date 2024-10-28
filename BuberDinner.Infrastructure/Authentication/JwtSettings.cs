namespace BuberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string c_JwtSettings = "JwtSettings";
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public int ExpiryMinutes { get; set; }
}