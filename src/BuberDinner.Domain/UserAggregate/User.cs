using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        #region Private constructors declaration

        private User(
            string firstName,
            string lastName,
            string email,
            string password)
            : base(UserId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        // ReSharper disable once UnusedMember.Local
        private User() { }

        #endregion

        #region Public properties declaration

        public DateTime CreatedDateTime { get; }
        public string Email { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Password { get; private set; } = null!;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public DateTime UpdatedDateTime { get; private set; }

        #endregion

        #region Public methods declaration

        public static User Create(
            string email,
            string firstName,
            string lastName,
            string password)
        {
            return new User(
                firstName,
                lastName,
                email,
                password);
        }

        #endregion
    }
}