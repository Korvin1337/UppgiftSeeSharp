using Busniess.Models;
using Busniess.Factories;
using Busniess.Helpers;
using System.Diagnostics;
using System.IO.Enumeration;
using Business.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Busniess.Services;

public class UserService(IFileService fileService) : IUserService
{
    private readonly IFileService _fileService = fileService;
    private List<UserEntity> _users = [];

    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);

            _users.Add(userEntity);
            _fileService.SaveListToFile<UserEntity>(_users);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        try
        {
            _users = _fileService.LoadListFromFile<UserEntity>();
            return _users.Select(UserFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    public void ClearList()
    {
        try
        {
            _users.Clear();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
