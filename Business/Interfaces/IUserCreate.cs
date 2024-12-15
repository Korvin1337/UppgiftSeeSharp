using Busniess.Models;

namespace Business.Interfaces;

/* Creates a user based on the UserRegistrationForm passed to it */
public interface IUserCreate
{
    bool Create(UserRegistrationForm form);
}
