using Busniess.Models;

namespace Business.Interfaces;

public interface IFileService
{
    List<UserEntity> LoadListFromFile();
    void SaveListToFile<T>(List<T> list);
}