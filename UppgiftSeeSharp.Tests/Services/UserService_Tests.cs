using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Busniess.Models;
using Moq;
using Busniess.Services;
using Busniess.Factories;
using Busniess.Helpers;

namespace UppgiftSeeSharp.Tests.Services;

/* Tests for UserService made with the help of ChatGpt4o and the school test lecture */
public class UserService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly IUserService _userService;
    private List<UserEntity> _users;

    public UserService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
        _userServiceMock = new Mock<IUserService>();
        _userService = _userServiceMock.Object;
        _users = [];
    }

    [Fact]
    public void Create_ShouldCreateUser()
    {
        // arrange
        var uniqueIdGenerator = new UniqueIdGenerator();
        var userFactory = new UserFactory(uniqueIdGenerator);

        UserRegistrationForm form = new()
        {
            FirstName = "Test",
            LastName = "Testsson",
            Email = "Test@Testsson@Email.Com",
            PhoneNumber = "0760493045",
            Address = "TestVagen 24A",
            PostalNumber = "493 52",
            City = "TestStaden"
        };
        UserEntity userEntity = userFactory.Create(form);

        // act
        _users.Add(userEntity);
        _fileService.SaveListToFile<UserEntity>(_users);

        // assert
        // Chat GPT 4o Syntax for "Asserts to check if the intended object is saved correctly, list not empty or null"
        Assert.IsType<List<UserEntity>>(_users);
        Assert.Single(_users);
        Assert.NotNull(_users);
        Assert.NotEmpty(_users);
    }

    [Fact]
    public void GetAll_ShouldReturnAllUsers()
    {
        // arrange
        var users = new List<User>()
        {
            new User() {
                Id = "1",
                FirstName = "Test",
                LastName = "Testsson",
                Email = "Test@Testsson@Email.Com",
                PhoneNumber = "0760493045",
                Address = "TestVagen 24A",
                PostalNumber = "493 52",
                City = "TestStaden"
            },
             new User() {
                Id = "2",
                FirstName = "Test2",
                LastName = "Testsson2",
                Email = "Test2@Testsson2@Email.Com",
                PhoneNumber = "0762493045",
                Address = "TestVagen 22A",
                PostalNumber = "493 22",
                City = "TestStaden2"
            },
        };

        _userServiceMock.Setup(us => us.GetAll()).Returns(users);

        // act
        var result = _userService.GetAll();

        // assert
        Assert.IsType<List<User>>(result);
        Assert.Equal(2, result.Count());
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public void ClearList_ShouldEmptyListOfUsers()
    {
        // arrange
        var users = new List<User>()
        {
            new User() {
                Id = "1",
                FirstName = "Test",
                LastName = "Testsson",
                Email = "Test@Testsson@Email.Com",
                PhoneNumber = "0760493045",
                Address = "TestVagen 24A",
                PostalNumber = "493 52",
                City = "TestStaden"
            },
             new User() {
                Id = "2",
                FirstName = "Test2",
                LastName = "Testsson2",
                Email = "Test2@Testsson2@Email.Com",
                PhoneNumber = "0762493045",
                Address = "TestVagen 22A",
                PostalNumber = "493 22",
                City = "TestStaden2"
            },
        };

        _userServiceMock.Setup(us => us.GetAll()).Returns(users);
        /* Chat GPT 4o help syntax on how to clear the list with the userServiceMock, Callback => users.Clear())" */
        _userServiceMock.Setup(us => us.ClearList()).Callback(() => users.Clear());

        // act
        _userService.ClearList();
        var result = _userService.GetAll();

        // assert
        Assert.IsType<List<User>>(result);
        Assert.Empty(result);
    }

}
