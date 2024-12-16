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
    /* ChatGPT 4o help me with the saving and loading logic of my UserService
     * Putting the List and file in the constructor below,
     * The main differnece being the _users list executing the LoadUsersFromFile Method */
    private readonly IFileService _fileService;
    private readonly UserFactory _userFactory;
    private readonly List<UserEntity> _users;
    private readonly ErrorLogger _errorLogger;

    public UserService(IFileService fileservice, UserFactory userFactory, ErrorLogger errorLogger)
    {
        _fileService = fileservice;
        _userFactory = userFactory;
        _users = LoadUsersFromFile();
        _errorLogger = errorLogger;
    }

    /* Creates a UserEntity with the help of injected dependecies, adds to _users collection and calls on SavesUsersToFile */ 
    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = _userFactory.Create(form);

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
            _errorLogger.ErrorMessage($"Error creating the user: {ex.Message}");
            return false;
        }
    }

    /* Returns all users with the help of the userFactory, error with ErrorLogger */
    public IEnumerable<User> GetAll()
    {
        try
        {
            return _users.Select(user => _userFactory.Create(user));
        }
        catch (Exception ex)
        {
            _errorLogger.ErrorMessage($"Error fetching the list of users: {ex.Message}");
            return [];
        }
    }

    /* Clears the list of users */
    public void ClearList()
    {
        try
        {
            _users.Clear();
            SaveUsersToFile();
        }
        catch (Exception ex)
        {
            _errorLogger.ErrorMessage($"Error clearing the list of users: {ex.Message}");
        }
    }

    /* ChatGPT 4o Help me make UserService follow the S in the SOLID design pattern
     * Correct use of the fileservice to follow the SRP ,
       By making 2 seperate methods handling the saving and the loading part of the Service */

    /* Moving the logic of the loading part of my UserService to follow the SRP */
    /* Loads list of UserEntities with FileService, error with ErrorLogger */
    public List<UserEntity> LoadUsersFromFile()
    {
        try
        {
            return _fileService.LoadListFromFile<UserEntity>();
        } catch (Exception ex)
        {
            _errorLogger.ErrorMessage($"Error loading the file of users: {ex.Message}");
            return [];
        }
    }

    /* Moving the logic of the saving part of my UserService to follow the SRP */
    /* Saves the users to file with the help of FileService */
    public void SaveUsersToFile()
    {
        try
        {
            _fileService.SaveListToFile(_users);
        } catch (Exception ex)
        {
            _errorLogger.ErrorMessage($"Error saving the users to file: {ex.Message}");
        }
    }

    /* Created with help of chatgpt 4o
     * Finding the user with the help of their Id and then updates the data and saves to the file */
    public bool Update(User user)
    {
        try
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Address = user.Address;
                existingUser.PostalNumber = user.PostalNumber;
                existingUser.City = user.City;
            }

            SaveUsersToFile();
            return true;
        } catch (Exception ex)
        {
            _errorLogger.ErrorMessage($"Error updating the user: {ex.Message}");
            return false;
        } 
    }
}
