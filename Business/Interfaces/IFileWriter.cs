namespace Business.Interfaces;

public interface IFileWriter
{
    void SaveListToFile<T>(List<T> list);
}