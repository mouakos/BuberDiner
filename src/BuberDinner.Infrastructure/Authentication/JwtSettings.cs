namespace BuberDinner.Infrastructure.Authentication
{
    public class JwtSettings
    {
        #region Public constants declaration

        public const string c_SectionName = "JwtSettings";

        #endregion

        #region Public properties declaration

        public string? Audience { get; set; }
        public int ExpiryMinutes { get; set; }
        public string? Issuer { get; set; }
        public string? SecretKey { get; set; }

        #endregion
    }
}