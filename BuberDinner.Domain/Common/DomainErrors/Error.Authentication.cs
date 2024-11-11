using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    #region Public classes declaration

    public static class Authentication
    {
        #region Public properties declaration

        public static Error InvalidCredentials =>
            Error.Validation("Auth.InvalidCred", "Invalid credentials.");

        #endregion
    }

    #endregion
}