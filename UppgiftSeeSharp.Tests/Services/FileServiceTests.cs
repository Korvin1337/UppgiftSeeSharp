using Moq;
using System;
using System.Collections.Generic;
using UppgiftSeeSharp.Services;
using Xunit;
using Busniess.Services;
using Business.Interfaces;
using System.Text.Json;

namespace UppgiftSeeSharp.Tests.Services;

public class FileServiceTests
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;


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
