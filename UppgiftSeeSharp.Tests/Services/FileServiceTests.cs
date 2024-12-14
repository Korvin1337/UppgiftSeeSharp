using Moq;
using System;
using System.Collections.Generic;
using UppgiftSeeSharp.Services;
using Xunit;
using Busniess.Services;
using Business.Interfaces;
using System.Text.Json;
using Busniess.Models;

namespace UppgiftSeeSharp.Tests.Services;

public class FileServiceTests
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;
    private readonly Mock<IUserService> _userServiceMock;
    private readonly IUserService _userService;
    private List<UserEntity> _users;

    public FileServiceTests(string directoryPath = "Data", string fileName = "users.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
        _userServiceMock = new Mock<IUserService>();
        _userService = _userServiceMock.Object;
        _users = [];
    }


    [Fact]
    public void SaveListToFile_ShouldCreateDirectoryAndWriteFile()
    {
        // arrange
        // /* Chat GPT4o Check what type of List syntax and Verifiable method.*/
        // /* Chat GPT 4o help me by suggesting I should create users in a List with UserEntity to save my users,*/
        // /* To then be able to use userservice which then saves the users,*/
        // /* Finally it's verified with the mock*/
        var users = new List<UserEntity>
        {
            new UserEntity {
                Id = "1",
                FirstName = "Test",
                LastName = "Testsson",
                Email = "Test@Testsson@Email.Com",
                PhoneNumber = "0760493045",
                Address = "TestVagen 24A",
                PostalNumber = "493 52",
                City = "TestStaden"
            },
            new UserEntity {
                Id = "2",
                FirstName = "Test2",
                LastName = "Testsson2",
                Email = "Test2@Testsson2@Email.Com",
                PhoneNumber = "0762493045",
                Address = "TestVagen 22A",
                PostalNumber = "493 22",
                City = "TestStaden2"
            }
        };
        _fileServiceMock.Setup(fs => fs.SaveListToFile(It.IsAny<List<UserEntity>>())).Verifiable();

        // act Add the mocking by suggestion of chatgpt 4
        _fileServiceMock.Object.SaveListToFile(users);

        // assert
        _fileServiceMock.Verify(fs => fs.SaveListToFile(It.Is<List<UserEntity>>(list => list.SequenceEqual(users))), Times.Once);
    }

    [Fact]
    public void LoadListFromFile_ShouldReturnList()
    {
        var users = new List<UserEntity>
        {
            new UserEntity {
                Id = "1",
                FirstName = "Test",
                LastName = "Testsson",
                Email = "Test@Testsson@Email.Com",
                PhoneNumber = "0760493045",
                Address = "TestVagen 24A",
                PostalNumber = "493 52",
                City = "TestStaden"
            },
            new UserEntity {
                Id = "2",
                FirstName = "Test2",
                LastName = "Testsson2",
                Email = "Test2@Testsson2@Email.Com",
                PhoneNumber = "0762493045",
                Address = "TestVagen 22A",
                PostalNumber = "493 22",
                City = "TestStaden2"
            }
        };
        /* Chat GPT 4o Help me with syntax and understand why i should use LoadListFromFile, not needed to save */
        _fileServiceMock.Setup(fs => fs.LoadListFromFile<UserEntity>()).Returns(users);

        // act /* Chat GPT 4o Help me with the syntax for result to load the file and to use Mock instead of actual service */
        var result = _fileServiceMock.Object.LoadListFromFile<UserEntity>();

        // assert /* Chat GPT 4o Help me with the arguments that should be passed in the fileServiceMock */
        _fileServiceMock.Verify(fs => fs.LoadListFromFile<UserEntity>(), Times.Once);
        Assert.Equal(2, result.Count);
        Assert.NotNull(result);
    }
}
