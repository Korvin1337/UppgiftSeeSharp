using Busniess.Models;

namespace Business.Interfaces;

/* Loading a specific type of list from file */
public interface IFileReader
{
    List<T> LoadListFromFile<T>();
}
