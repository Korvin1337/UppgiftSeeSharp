using Busniess.Models;

namespace Business.Interfaces;

public interface IUserGetAll
{
    IEnumerable<User> GetAll();
}