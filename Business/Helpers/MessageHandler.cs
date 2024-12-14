using Busniess.Models;
using Busniess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

/* By suggestion of ChatGpt4 im moving my logic of handling messages
 * This is to adhere to the SRP */
public class MessageHandler(ConsoleWrapper consoleWrapper)
{
    private readonly ConsoleWrapper _consoleWrapper = consoleWrapper;

    /* General showMessage method instead by suggestion of ChatGPT 4 */
    public void ShowMessage(string message)
    {
        _consoleWrapper.Clear();
        Console.WriteLine(message);
        _consoleWrapper.ReadKey();
    }

    /* By suggestion of CHATGPT 4o i need to format the user details in a seperate method,
     * This is to keep in line with the SRP so i move my formatting to this method and just calls
     * the formatting method from my showuser method instead */
    public string FormatUserDetails(User user)
    {
        return ($"Id: {user.Id}\n" +
                $"Name: {user.FirstName} {user.LastName}\n" +
                $"Email: {user.Email}\n" +
                $"PhoneNumber: {user.PhoneNumber}\n" +
                $"Address: {user.Address} {user.PostalNumber} {user.City}\n" +
                "");
    }

    public void ShowUser(User user)
    {
        Console.WriteLine(FormatUserDetails(user));
    }
}
