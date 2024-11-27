using Busniess.Models;
using Busniess.Factories;
using Busniess.Helpers;
using System.Diagnostics;
using System.IO.Enumeration;

namespace Busniess.Services;

public class UserService
{
    private List<UserEntity> _users = [];
    private readonly FileService _fileService = new FileService(fileName: "users.json");

    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);

            _users.Add(userEntity);
            _fileService.SaveListToFile<UserEntity>(_users);
            return true;
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        _users = _fileService.LoadListFromFile();
        return _users.Select(UserFactory.Create);
    }

    public void ClearList()
    {
        _users.Clear();
    }
}
