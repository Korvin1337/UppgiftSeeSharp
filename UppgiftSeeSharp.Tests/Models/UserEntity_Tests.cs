using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Models;

namespace UppgiftSeeSharp.Tests.Models;

/* UserEntity Test made with the help of chatgpt 4o */
public class UserEntity_Tests
{

    /* Creates a UserEntity and uses assert to compare the userEntity with the expected result */
    [Fact]
    public void User_ShouldCreateUserEntity()
    {

        // act
        var result = new UserEntity()
        {
            Id = "1337",
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson@Email.Com",
            PhoneNumber = "0760493045",
            Address = "TestVagen 24A",
            PostalNumber = "493 52",
            City = "TestStaden"
        };

        // assert
        Assert.IsType<UserEntity>(result);
        Assert.Equal("1337", result.Id);
        Assert.Equal("Test", result.FirstName);
        Assert.Equal("Testsson", result.LastName);
        Assert.Equal("Test@Testsson@Email.Com", result.Email);
        Assert.Equal("0760493045", result.PhoneNumber);
        Assert.Equal("TestVagen 24A", result.Address);
        Assert.Equal("493 52", result.PostalNumber);
        Assert.Equal("TestStaden", result.City);
    }

}
