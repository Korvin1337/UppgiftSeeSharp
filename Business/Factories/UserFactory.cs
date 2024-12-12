using Busniess.Helpers;
using Busniess.Models;
using System.Diagnostics;

namespace Busniess.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    public static UserEntity Create(UserRegistrationForm form)
    {
        try
        {
            return new UserEntity()
            {
                Id = UniqueIdGenerator.GenerateUniqueId(),
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                Address = form.Address,
                PostalNumber = form.PostalNumber,
                City = form.City
            };
        } catch (Exception ex)
        {
            Debug.WriteLine($"Error creating UserEntity: {ex.Message}");
            return null!;
        }
    }

    public static User Create(UserEntity entity)
    {
        try
        {
            return new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                PostalNumber = entity.PostalNumber,
                City = entity.City,
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating UserEntity: {ex.Message}");
            return null!;
        }
    }
}
