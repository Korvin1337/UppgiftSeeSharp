using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

/* By suggestion of ChatGpt4 im moving my logic of handling inputs
 * This is to adhere to the SRP */
public class InputHandler(ConsoleWrapper consoleWrapper)
{
    /* Adding the consolewrapper for my console logic */
    private readonly ConsoleWrapper _consoleWrapper = consoleWrapper;

    /* Suggestion of CHATGPT 4o to make my prompts check for null or whitespace,
   and be able to loop until a desired input is made */
    public string GetInput(string prompt)
    {
        string input;
        do
        {
            _consoleWrapper.Write(prompt);
            input = _consoleWrapper.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}
