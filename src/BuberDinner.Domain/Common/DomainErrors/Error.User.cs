using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        #region Public classes declaration

        public static class User
        {
            #region Public properties declaration

            public static Error DuplicateEmail =>
                Error.Conflict("User.Conflict", "User with given email already exist.");

            #endregion
        }

        #endregion
    }
}