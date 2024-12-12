using Business.Interfaces;
using Busniess.Factories;
using Busniess.Models;
using Busniess.Services;
using UppgiftSeeSharp.Interfaces;

namespace UppgiftSeeSharp.Services;

public class MenuDialogs(IUserService userService) : IMenuDialogs
{
    private readonly IUserService _userService = userService;

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
        Console.WriteLine($"{"1. ",-5} Create User");
        Console.WriteLine($"{"2. ",-5} View User");
        Console.WriteLine($"{"q. ",-5} Quit Program");
        Console.WriteLine("--------------------------------");
        Console.Write("Choose option: ");
        var option = Console.ReadLine()!;

        switch (option.ToString().ToLower())
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

        // Get First Name
        userRegistrationForm.FirstName = GetInput("Enter your first name: ");

        // Get Last Name
        userRegistrationForm.LastName = GetInput("Enter your last name: ");

        // Get Email
        userRegistrationForm.Email = GetInput("Enter your email: ");

        // Get Phone Number
        userRegistrationForm.PhoneNumber = GetInput("Enter your phonenumber: ");

        // Get Street Address
        userRegistrationForm.Address = GetInput("Enter your street address: ");

        // Get Postal Number
        userRegistrationForm.PostalNumber = GetInput("Enter your postal number: ");

        // Get City
        userRegistrationForm.City = GetInput("Enter your city: ");

        /* Bool Result,  Adding try and catch by suggestion of CHATGPT 4o*/
        try
        {
            bool result = _userService.Create(userRegistrationForm);
            if (result)
            {
                OutPutDialog("User was successfully created.");
            }
            else
            {
                OutPutDialog("User was not created. Please enter valid details.");
            }
        }
        catch (Exception ex)
        {
            OutPutDialog($"An error occured when trying to create the user: {ex.Message}");
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
        var option = GetInput("Do you want to exit? (y/n): ");

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }

    public void Invalid()
    {
        Console.Clear();
        Console.WriteLine("Please make a valid option...");
        Console.ReadKey();
    }

    public void OutPutDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }

    /* Suggestion of CHATGPT 4o to make my prompts check for null or whitespace,
       and be able to loop until a desired input is made */
    public static string GetInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()!;
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

}
