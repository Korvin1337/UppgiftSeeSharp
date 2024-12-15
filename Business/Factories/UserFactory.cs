using Busniess.Helpers;
using Busniess.Models;
using System.Diagnostics;

namespace Busniess.Factories;

/* UserFactory responsible for creating all the users
 * Achieved by UserRegistrationForm, UserEntity and User class Respectivly */
public class UserFactory
{
    /* CHAT GPT4 help me move the logic of the generation of the Id to follow the SRP. */
    private readonly UniqueIdGenerator _uniqueIdGenerator;

    public UserFactory(UniqueIdGenerator uniqueIdGenerator)
    {
        _uniqueIdGenerator = uniqueIdGenerator;
    }

    /* Returns a registration form which is filled with User Data */
    public UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

    /* Returns a UserEntity with the data provided */
    public UserEntity Create(UserRegistrationForm form)
    {
        /* Check if form is null and throw exception. by suggestion of chatgpt 4 */
        if (form == null) throw new ArgumentException(nameof(form));

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
    }

    /* Returns a User with the data provided */
    public User Create(UserEntity entity)
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
    
}
