using Busniess.Models;

namespace Business.Interfaces;

public interface IUserService
{
    void ClearList();
    bool Create(UserRegistrationForm form);
    IEnumerable<User> GetAll();
}