using Busniess.Models;

namespace Business.Interfaces;

public interface IUserCreate
{
    bool Create(UserRegistrationForm form);
}
