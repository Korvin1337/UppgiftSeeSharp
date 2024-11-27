﻿using UppgiftSeeSharp.Helpers;
using UppgiftSeeSharp.Models;

namespace UppgiftSeeSharp.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    public static UserEntity Create(UserRegistrationForm form)
    {
        return new UserEntity()
        {
            Id = UniqueIdGenerator.GenerateUniqueId(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.Email,
            Address = form.Address,
            Postal = form.Postal,
            City = form.City
        };
    }

    public static User Create(UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.Email,
            Address = entity.Address,
            Postal = entity.Postal,
            City = entity.City,
        };
    }
}
