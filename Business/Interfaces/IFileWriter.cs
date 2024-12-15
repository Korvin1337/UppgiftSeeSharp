namespace Business.Interfaces;

/* Save specific type of list to file */
public interface IFileWriter
{
    void SaveListToFile<T>(List<T> list);
}