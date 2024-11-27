using System.Diagnostics;

namespace UppgiftSeeSharp.Helpers;

public class UniqueIdGenerator
{
    public static string GenerateUniqueId()
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
