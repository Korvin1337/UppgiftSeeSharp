using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Busniess.Models;

namespace UppgiftSeeSharp.Tests.Models;

/* UserRegistrationForm Test made with the help of chatgpt4o */
public class UserRegistrationForm_Tests
{

    /* Creats a UserRegistrationForm and uses assert to compare the userRegistrationForm with the expected result */
    [Fact]
    public void User_ShouldCreateUserRegistrationForm()
    {
        // act
        var result = new UserRegistrationForm()
        {
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson@Email.Com",
            PhoneNumber = "0760493045",
            Address = "TestVagen 24A",
            PostalNumber = "493 52",
            City = "TestStaden"
        };

        // assert
        Assert.IsType<UserRegistrationForm>(result);
        Assert.Equal("Test", result.FirstName);
        Assert.Equal("Testsson", result.LastName);
        Assert.Equal("Test@Testsson@Email.Com", result.Email);
        Assert.Equal("0760493045", result.PhoneNumber);
        Assert.Equal("TestVagen 24A", result.Address);
        Assert.Equal("493 52", result.PostalNumber);
        Assert.Equal("TestStaden", result.City);
    }

}
