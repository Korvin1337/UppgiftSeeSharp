using Business.Interfaces;
using Busniess.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftSeeSharp_MainApp.ViewModels;

public partial class UserListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;

    [ObservableProperty]
    private ObservableCollection<User> _users = [];
    private string _title = "Users";

    public UserListViewModel(IServiceProvider serviceProvider, IUserService userService)
    {
        _serviceProvider = serviceProvider;
        _userService = userService;

        _users = new ObservableCollection<User>(_userService.GetAll());
    }

    [RelayCommand]
    private void GoToAddUser()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserAddViewModel>();
    }

    [RelayCommand]
    private void GoToDetailsView(User user)
    {
        var userDetailsViewModel = _serviceProvider.GetRequiredService<UserDetailsViewModel>();
        userDetailsViewModel.User = user;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = userDetailsViewModel;
    }

}
