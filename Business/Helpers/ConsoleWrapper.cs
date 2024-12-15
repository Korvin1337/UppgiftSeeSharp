using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

/* Making a helper class ConsoleWrapper to simplify my tests in the message handler
 * Here im going to only clear the console instead and call it from my messagehandler 
   Im moving the console logic from my other tests here to be able to test the other code more easily */
/* Uses the "built in" Console methods to help run the program / methods in program and make code more easily testable */
public class ConsoleWrapper
{
    public virtual void Clear()
    {
        Console.Clear();
    }

    public virtual void ReadKey()
    {
        Console.ReadKey();
    }

    public virtual void Write(string message)
    {
        Console.Write(message);
    }

    public virtual string ReadLine() => Console.ReadLine();


}
