using Business.Interfaces;
using Busniess.Factories;
using Busniess.Models;
using Busniess.Services;
using Busniess.Helpers;
using UppgiftSeeSharp.Interfaces;
using Business.Helpers;
using Business.Services;

namespace UppgiftSeeSharp.Services;

public class MenuDialogs(IUserService userService, UserFactory userFactory, ErrorLogger errorLogger, InputHandler inputHandler, MessageHandler messageHandler, UserInputService userInputService) : IMenuDialogs
{
    private readonly IUserService _userService = userService;
    private readonly UserFactory _userFactory = userFactory;
    private readonly ErrorLogger _errorLogger = errorLogger;
    private readonly InputHandler _inputHandler = inputHandler;
    private readonly MessageHandler _messageHandler = messageHandler;
    private readonly UserInputService _userInputService = userInputService;


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
        var option = _inputHandler.GetInput("Choose option: ");

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
                _messageHandler.ShowMessage("Please enter a valid option: ");
                break;
        }
    }

    public void CreateUser()
    {

        /*
          förnamn, efternamn, e-postadress, telefonnummer, gatuadress, postnummer och ort 
        */

        /* UserRegistrationForm */
        var userRegistrationForm = _userInputService.CollectUserData();


        /* Bool Result,  Adding try and catch by suggestion of CHATGPT 4o*/
        try
        {
            bool result = _userService.Create(userRegistrationForm);
            if (result)
            {
                _messageHandler.ShowMessage("User was successfully created.");
            }
            else
            {
                _messageHandler.ShowMessage("User was not created. Please enter valid details.");
            }
        }
        catch (Exception ex)
        {
            _messageHandler.ShowMessage($"An error occured when trying to create the user: {ex.Message}");
        }

        Console.ReadKey();
    }

    public void ViewUsers()
    {
        var users = _userService.GetAll();

        foreach (var user in users)
        {
            _messageHandler.ShowUser(
                $"Id: {user.Id}\n" +
                $"Name: {user.FirstName} {user.LastName}\n" +
                $"Email: {user.Email}\n" +
                $"PhoneNumber: {user.PhoneNumber}\n" +
                $"Address: {user.Address} {user.PostalNumber} {user.City}\n" +
                "");
        }

        Console.ReadKey();
    }

    public void Quit()
    {
        Console.Clear();
        var option = _inputHandler.GetInput("Do you want to exit? (y/n): ");

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        } else if (option.Equals("n", StringComparison.CurrentCultureIgnoreCase))
        {
            MainMenu();
        } else
        {
            Quit();
        }
    }

}
