using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    #region Private constructors declaration

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        Status status,
        bool isPublic,
        int maxGuest,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        Reservation reservation,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuest = maxGuest;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        Reservation = reservation;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public DateTime CreatedDateTime { get; private set; }
    public string Description { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }
    public HostId HostId { get; private set; }
    public string ImageUrl { get; private set; }
    public bool IsPublic { get; private set; }
    public Location Location { get; private set; }
    public int MaxGuest { get; private set; }
    public MenuId MenuId { get; private set; }
    public string Name { get; private set; }
    public Price Price { get; private set; }
    public Reservation Reservation { get; private set; }
    public DateTime StartDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public Status Status { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    #endregion

    #region Public methods declaration

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        Status status,
        bool isPublic,
        int maxGuest,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        Reservation reservation)
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            startedDateTime,
            endedDateTime,
            status,
            isPublic,
            maxGuest,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            reservation,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

    #endregion
}