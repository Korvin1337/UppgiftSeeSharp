using Busniess.Helpers;
using Busniess.Models;
using System.Diagnostics;

namespace Busniess.Factories;

public class UserFactory
{
    /* CHAT GPT4 help me move the logic of the generation of the Id to follow the SRP. */
    private readonly UniqueIdGenerator _uniqueIdGenerator;

    public UserFactory(UniqueIdGenerator uniqueIdGenerator)
    {
        _uniqueIdGenerator = uniqueIdGenerator;
    }

    public UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }

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
