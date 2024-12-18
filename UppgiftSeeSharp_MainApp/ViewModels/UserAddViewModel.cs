using Business.Interfaces;
using Busniess.Models;
using Busniess.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftSeeSharp_MainApp.ViewModels;

public partial class UserAddViewModel(IUserService userService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IUserService _userService = userService;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private UserRegistrationForm _user = new();

    [ObservableProperty]
    private string _title = "Add New User";

    [ObservableProperty]
    private string _firstNameWarning = string.Empty;

    [ObservableProperty]
    private string _lastNameWarning = string.Empty;

    [ObservableProperty]
    private string _emailWarning = string.Empty;

    [ObservableProperty]
    private string _phoneNumberWarning = string.Empty;

    [ObservableProperty]
    private string _addressWarning = string.Empty;

    [ObservableProperty]
    private string _postalNumberWarning = string.Empty;


    [RelayCommand]
    private void Save()
    {
        if(!ValidateUserForm())
        {
            return;
        }

        var result = _userService.Create(User);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
        }
    }

    /* Validate Adding User, With help and suggested by CHATGPT 4o */
    /* If something fails the isValid is flagged as false, 
     * A message is set below the input field by assigning a value to their warning 
     * It gets displayed if its not empty */
    public bool ValidateUserForm()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(User.FirstName))
        {
            FirstNameWarning = "First Name is required.";
            isValid = false;
        } else
        {
            FirstNameWarning = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(User.LastName))
        {
            LastNameWarning = "Last Name is required.";
            isValid = false;
        } else
        {
            LastNameWarning = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(User.Email))
        {
            EmailWarning = "Enail is required.";
            isValid = false;
        } else
        {
            EmailWarning = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(User.PhoneNumber))
        {
            PhoneNumberWarning = "PhoneNumber is required.";
            isValid = false;
        } else
        {
            PhoneNumberWarning = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(User.Address))
        {
            AddressWarning = "Address is required.";
            isValid = false;
        } else
        {
            AddressWarning = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(User.PostalNumber))
        {
            PostalNumberWarning = "Postal Number is required.";
            isValid = false;
        } else
        {
            PostalNumberWarning = string.Empty;
        }

        return isValid;
    }

    [RelayCommand]
    private void Cancel()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }

    [RelayCommand]
    private void GoToUsersView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }

}
