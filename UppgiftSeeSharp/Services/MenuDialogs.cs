using UppgiftSeeSharp.Factories;
using UppgiftSeeSharp.Models;

namespace UppgiftSeeSharp.Services;

public class MenuDialogs : Menu
{
    private readonly UserService _userService = new UserService();

    public void RunMenu()
    {
        while (true)
        {
            MainMenu();
        }
    }

    public void MainMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"{"1. ", -5} Create User");
        Console.WriteLine($"{"2. ", -5} View User");
        Console.WriteLine($"{"q. ", -5} Quit Program");
        Console.WriteLine("--------------------------------");
        Console.Write("Choose option: ");
        var option = Console.ReadLine()!;

        switch(option.ToString().ToLower())
        {
            case "1":
                CreateUser();
                break;
            case "2":
                ViewUsers();
                break;
            case "q":
                Quit();
                break;
            default:
                Invalid();
                break;
        }
    }

    public void CreateUser()
    {

        /*
          förnamn, efternamn, e-postadress, telefonnummer, gatuadress, postnummer och ort 
        */

        /* UserRegistrationForm */
        UserRegistrationForm userRegistrationForm = UserFactory.Create();
        Console.Clear();

        Console.Write("Enter your first name: ");
        userRegistrationForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        userRegistrationForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        userRegistrationForm.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        userRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your street address: ");
        userRegistrationForm.Address = Console.ReadLine()!;

        Console.Write("Enter your postal number: ");
        userRegistrationForm.PostalNumber = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        userRegistrationForm.City = Console.ReadLine()!;

        /* Bool Result */
        bool result = _userService.Create(userRegistrationForm);

        if (result)
        {
            OutPutDialog("User was successfully created.");
        } else
        {
            OutPutDialog("User was not created. Please enter valid details.");
        }

        Console.ReadKey();
    }

    public void ViewUsers()
    {
        var users = _userService.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine($"{"Id: ",-5} {user.Id}");
            Console.WriteLine($"{"Name: ",-5} {user.FirstName} {user.LastName}");
            Console.WriteLine($"{"Email: ",-5} {user.Email}");
            Console.WriteLine($"{"PhoneNumber: ",-5} {user.PhoneNumber}");
            Console.WriteLine($"{"Address: ",-5} {user.Address} {user.PostalNumber} {user.City}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    public void Quit()
    {
        Console.Clear();
        Console.WriteLine("Do you want to exit? (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
        Console.ReadKey();
    }

    public void Invalid()
    {
        Console.Clear();
        Console.WriteLine("Please make a valid option..." );
        Console.ReadKey();
    }

    public void OutPutDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }


}
