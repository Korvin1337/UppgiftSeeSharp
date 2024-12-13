using System.Diagnostics;

namespace Busniess.Factories;

public class ErrorLogger
{
    /* Chat GPT4 help me make the UserFactory follow the SRP by moving the logic of the
     * generation of the Id to a seperate class and method aswell as moving the error handling
     * to a class and method of it's own aswell */
    public void ErrorMessage(string message)
    {
        Debug.WriteLine(message);
    }
    
}
