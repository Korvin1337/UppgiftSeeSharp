using Business.Interfaces;
using Busniess.Factories;
using Busniess.Models;
using Busniess.Services;
using Busniess.Helpers;
using UppgiftSeeSharp.Interfaces;
using Business.Helpers;
using Business.Services;

namespace UppgiftSeeSharp.Services;

public class MenuDialogs(IUserService userService, InputHandler inputHandler, MessageHandler messageHandler, UserInputService userInputService) : IMenuDialogs
{
    private readonly IUserService _userService = userService;
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
            _messageHandler.ShowUser(user);
        }

        Console.ReadKey();
    }

    /* Made the GetQuitOption method to move the input logic to a method to adhere to the SRP */
    public string GetQuitOption()
    {
        return _inputHandler.GetInput("Do you want to exit? (y/n): ").ToLower();
    }

    /* Updating my Quit method to adhere to the SRP
     * With the help of CHATGPT4o,
     * Basically im making it focus on only quitting instead of running the menu instead as before 
       To accomplis this I instead use a bool method that can return true, false or rerun the quit method if invalid input */
    public void Quit()
    {
        Console.Clear();
        var option = GetQuitOption();

        switch (option)
        {
            case "y":
                Environment.Exit(0);
                break;
            case "n":
                break;
            default:
                _messageHandler.ShowMessage($"Invalid input, please enter 'y' to quit or 'n' to keep running the program");
                Quit();
                break;
        }
    }

}
