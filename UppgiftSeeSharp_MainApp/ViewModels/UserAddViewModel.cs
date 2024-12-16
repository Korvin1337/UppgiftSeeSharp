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

    [RelayCommand]
    private void Save()
    {
        var result = _userService.Create(User);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
        }
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
