using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Busniess.Models;

namespace Busniess.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "users.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

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


    /* I used CHATGPT 4o to ask about if my code follow the SOLID Design pattern or not,
     * Instead of only using UserEntity List like before,
     * It gave me examples of using List<T> syntax instead which i updated my code with,
     * This should make my code more reusable aswell for other "loads" in the future */
    public List<T> LoadListFromFile<T>()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return [];
            }

            var json = File.ReadAllText(_filePath);
            var list = JsonSerializer.Deserialize<List<T>>(json, _jsonSerializerOptions);
            return list ?? [];

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}
