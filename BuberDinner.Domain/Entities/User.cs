namespace BuberDinner.Domain.Entities;

public class User
{
    #region Public properties declaration

    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;

    #endregion
}