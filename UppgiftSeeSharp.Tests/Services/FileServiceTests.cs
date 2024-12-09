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

        // act

        // assert
    }

    [Fact]
    public void LoadListFromFile_ShouldReturnList()
    {
        // arrange

        // act

        // assert
    }
}
