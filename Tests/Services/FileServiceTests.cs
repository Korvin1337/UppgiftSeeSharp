using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using UppgiftSeeSharp.Models;
using UppgiftSeeSharp.Services;
using Xunit;

namespace Tests.Services;

public class FileServiceTests
{
    private readonly string _testDirectoryPath = "Data";
    private readonly string _testFileName = "user.json";

    [fact]

    public void SaveListToFile<T>(List<T> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

        }

    }
}
