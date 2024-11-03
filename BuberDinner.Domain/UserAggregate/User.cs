using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;

public sealed class ApplicationUser : AggregateRoot<UserId>
{
    #region Private constructors declaration

    private ApplicationUser(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(userId)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public DateTime CreatedDateTime { get; private set; }

    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    #endregion

    #region Public methods declaration

    public static ApplicationUser Create(
        string email,
        string firstName,
        string lastName,
        string password)
    {
        return new ApplicationUser(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    #endregion
}

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}