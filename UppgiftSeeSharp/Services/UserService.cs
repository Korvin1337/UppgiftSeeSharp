using UppgiftSeeSharp.Models;
using UppgiftSeeSharp.Factories;
using UppgiftSeeSharp.Helpers;
using System.Diagnostics;

namespace UppgiftSeeSharp.Services;

public class UserService
{
    private readonly List<UserEntity> _users = [];

    public bool Create(UserRegistrationForm form)
    {
        try
        {
            UserEntity userEntity = UserFactory.Create(form);

            _users.Add(userEntity);
            return true;
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<User> GetAll()
    {
        return _users.Select(UserFactory.Create);
    }

    public void ClearList()
    {
        _users.Clear();
    }
}
