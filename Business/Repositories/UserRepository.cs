using Business.Interfaces;
using Busniess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Repositories;

public class UserRepository
{
    private readonly IFileService _fileService;

    public UserRepository(IFileService fileService)
    {
        _fileService = fileService;
    }

    public bool SaveToFile<T>(List<T> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            _fileService.SaveListToFile(list);
            return true;
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
