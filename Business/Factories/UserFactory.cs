using Busniess.Helpers;
using Busniess.Models;
using System.Diagnostics;

namespace Busniess.Factories;

public class UserFactory
{
    /* CHAT GPT4 help me move the logic of the generation of the Id and error messages,
     * to follow the SRP. */
    private readonly UniqueIdGenerator _uniqueIdGenerator;
    private readonly ErrorLogger _errorLogger;

    public UserFactory(UniqueIdGenerator uniqueIdGenerator, ErrorLogger errorLogger)
    {
        _uniqueIdGenerator = uniqueIdGenerator;
        _errorLogger = errorLogger;
    }

    public UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    public UserEntity Create(UserRegistrationForm form)
    {
        try
        {
             var uniqueId = _uniqueIdGenerator.GenerateUniqueId();
            return new UserEntity()
            {
                Id = uniqueId,
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
            _errorLogger.ErrorMessage($"Error creating UserEntity: {ex.Message}");
            return null!;
        }
    }

    public User Create(UserEntity entity)
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
            _errorLogger.ErrorMessage($"Error creating UserEntity: {ex.Message}");
            return null!;
        }
    }
    
}
