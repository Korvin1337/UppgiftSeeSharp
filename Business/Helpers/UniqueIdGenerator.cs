using System.Diagnostics;

namespace Busniess.Helpers;

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

/*
 *     public class UniqueIdService
    {
        public string GenerateUniqueId()
        {
            try
            {
                return UniqueIdGenerator.GenerateUniqueId();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "Error generating id";
            }
        }
    }
*/
