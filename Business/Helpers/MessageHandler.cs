using Busniess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

/* By suggestion of ChatGpt4 im moving my logic of handling messages
 * This is to adhere to the SRP */
public class MessageHandler
{
    /* General showMessage method instead by suggestion of ChatGPT 4 */ 
    public void ShowMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }

    public void ShowUser(User user)
    {
        Console.WriteLine($"Id: {user.Id}\n" +
                $"Name: {user.FirstName} {user.LastName}\n" +
                $"Email: {user.Email}\n" +
                $"PhoneNumber: {user.PhoneNumber}\n" +
                $"Address: {user.Address} {user.PostalNumber} {user.City}\n" +
                "");
    }
}
