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
    private string _warningMessage = string.Empty;

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
    public bool ValidateUserForm()
    {
        if (string.IsNullOrWhiteSpace(User.FirstName))
        {
            WarningMessage = "First Name is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(User.LastName))
        {
            WarningMessage = "Last Name is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(User.Email))
        {
            WarningMessage = "Enail is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(User.PhoneNumber))
        {
            WarningMessage = "PhoneNumber is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(User.Address))
        {
            WarningMessage = "Address is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(User.PostalNumber))
        {
            WarningMessage = "Postal Number is required.";
            return false;
        }

        WarningMessage = string.Empty;
        return true;
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
