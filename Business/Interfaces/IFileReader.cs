using Busniess.Models;

namespace Business.Interfaces;

public interface IFileReader
{
    List<T> LoadListFromFile<T>();
}
