using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

/* Making a helper class ConsoleWrapper to simplify my tests in the message handler
 * Here im going to only clear the console instead and call it from my messagehandler */
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
}
