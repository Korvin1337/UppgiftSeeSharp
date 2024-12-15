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


    /* Run the MainMenu */
    public void RunMenu()
    {
        while (true)
        {
            MainMenu();
        }
    }

    /* A simple menu with a switch case
     * Logs the options in the console and waits for the userinput with InputHandler passing it to the switch
     * Runs the method for the choice made or a message with MessageHandler to ask for valid option */
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

    /* Creates a user with the help of UserRegistrationForm
     * UserInputService to collect all the information about the user
     * Finally using the UserService to create the user
     * MessageHandler handles showing messages */
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

    /* using UserService to fetch all users
     * using MessageHandler to "return" and correctly format the user in the console */
    public void ViewUsers()
    {
        var users = _userService.GetAll();

        foreach (var user in users)
        {
            _messageHandler.ShowUser(user);
        }

        Console.ReadKey();
    }

    /* Made the GetQuitOption method to move the input logic to a method to adhere to the SRP
     * Returns the input with the help of InputHandler */
    public string GetQuitOption()
    {
        return _inputHandler.GetInput("Do you want to exit? (y/n): ").ToLower();
    }

    /* Updating my Quit method to adhere to the SRP
     * With the help of CHATGPT4o,
     * Finallydeciding to use a switch case for simpler code SRP
     * Using MessageHandler to show messages and the GetQuitOption to get the user input */
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
