﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    #region Private constructors declaration

    private Dinner(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        MenuId menuId,
        HostId hostId,
        Uri imageUrl,
        Location location)
        : base(DinnerId.CreateUnique())
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        MenuId = menuId;
        HostId = hostId;
        ImageUrl = imageUrl;
        Location = location;
        Status = DinnerStatus.Upcoming;
    }

    #endregion

    private readonly List<Reservation> m_Reservations = [];

    #region Public properties declaration

    public string Description { get; private set; }
    public DateTime EndDateTime { get; private set; }
    public HostId HostId { get; private set; }
    public Uri ImageUrl { get; private set; }
    public bool IsPublic { get; private set; }
    public Location Location { get; private set; }
    public int MaxGuests { get; private set; }
    public MenuId MenuId { get; private set; }
    public string Name { get; private set; }
    public Price Price { get; private set; }
    public IReadOnlyList<Reservation> Reservations => m_Reservations.AsReadOnly();
    public DateTime? StartDateTime { get; private set; }
    public DinnerStatus Status { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public DateTime? StartedDateTime { get; private set; }
    public DateTime? EndedDateTime { get; private set; }

    #endregion

    #region Public methods declaration

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location
    )
    {
        return new Dinner(
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            menuId,
            hostId,
            imageUrl,
            location
        );
    }

    #endregion
}