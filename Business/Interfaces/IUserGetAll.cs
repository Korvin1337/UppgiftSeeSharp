using Busniess.Models;

namespace Business.Interfaces;

/* Gets all user data as a IEnumerable */
public interface IUserGetAll
{
    IEnumerable<User> GetAll();
}