using Busniess.Models;
using Busniess.Factories;
using Busniess.Helpers;
using System.Diagnostics;
using System.IO.Enumeration;
using Business.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Busniess.Services;

public class UserService : IUserService
{
    private readonly IFileService _fileService;
    private readonly List<UserEntity> _users;

    public UserService(IFileService fileservice)
    {
        _fileService = fileservice;
        _users = LoadUsersFromFile();
    }

    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);

            if (userEntity != null)
            {
                _users.Add(userEntity);
                SaveUsersToFile();
                return true;
            }
            return false;
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
            SaveUsersToFile();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    /* ChatGPT 4o Help me make UserService follow the S in the SOLID design pattern
     * Correct use of the fileservice to follow the SRP ,
       By making 2 seperate methods handling the saving and the loading part of the Service */

    /* Moving the logic of the loading part of my UserService to follow the SRP */
    public List<UserEntity> LoadUsersFromFile()
    {
        try
        {
            return _fileService.LoadListFromFile<UserEntity>();
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }

    /* Moving the logic of the saving part of my UserService to follow the SRP */
    public void SaveUsersToFile()
    {
        try
        {
            _fileService.SaveListToFile(_users);
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
