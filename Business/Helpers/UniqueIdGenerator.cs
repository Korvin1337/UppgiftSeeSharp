using System.Diagnostics;

namespace Busniess.Helpers;

/* Creates and returns a unique GuId for each and every user that gets created */
public class UniqueIdGenerator
{
    public string GenerateUniqueId()
    {
        try
        {
            return Guid.NewGuid().ToString();
        } catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}
