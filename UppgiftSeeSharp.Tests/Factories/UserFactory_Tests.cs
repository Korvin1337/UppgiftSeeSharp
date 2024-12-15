using Busniess.Models;
using Busniess.Factories;
using Busniess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftSeeSharp.Tests.Factories;

/* UserFactory Tests made with the help of ChatGpt 4o */
public class UserFactory_Tests
{
    /* Creates the userFactory and uses it to create a UserRegistrationForm and asserts the result type */
    [Fact]
    public void Create_ShouldReturnUserRegistraionForm()
    {
        // arrange
        var uniqueIdGenerator = new UniqueIdGenerator();
        var userFactory = new UserFactory(uniqueIdGenerator);

        // act
        UserRegistrationForm result = userFactory.Create();

        // assert
        Assert.IsType<UserRegistrationForm>(result);
    }

    /* Creates a userFactory and fills a UserRegistrationForm with userData to create a UserEntity and asserts the result type */
    [Fact]
    public void Create_ShouldReturnUserEntity()
    {
        // arrange
        var uniqueIdGenerator = new UniqueIdGenerator();
        var userFactory = new UserFactory(uniqueIdGenerator);

        UserRegistrationForm userRegistrationForm = new()
        {
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson@Email.Com",
            PhoneNumber = "0760493045",
            Address = "TestVagen 24A",
            PostalNumber = "493 52",
            City = "TestStaden"
        };


        // act
        UserEntity result = userFactory.Create(userRegistrationForm);


        // assert
        Assert.IsType<UserEntity>(result);
    }

    /* Creates a userFactory and fills a UserRegistrationForm with userData,
     * then create a UserEntity based on the data
     * finally creates a User based on the data
     * Asserts that all the information in the user is as expected and checks the type */
    [Fact]
    public void Create_ShouldReturnUser()
    {
        // arrange
        var uniqueIdGenerator = new UniqueIdGenerator();
        var userFactory = new UserFactory(uniqueIdGenerator);

        UserRegistrationForm userRegistrationForm = new()
        {
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson@Email.Com",
            PhoneNumber = "0760493045",
            Address = "TestVagen 24A",
            PostalNumber = "493 52",
            City = "TestStaden"
        };
        UserEntity userEntity = userFactory.Create(userRegistrationForm);
        
        
        // act
        User result = userFactory.Create(userEntity);


        // assert
        Assert.IsType<User>(result);
        Assert.Equal(userRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(userRegistrationForm.LastName, result.LastName);
        Assert.Equal(userRegistrationForm.Email, result.Email);
        Assert.Equal(userRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(userRegistrationForm.Address, result.Address);
        Assert.Equal(userRegistrationForm.PostalNumber, result.PostalNumber);
        Assert.Equal(userRegistrationForm.City, result.City);
    }
}

