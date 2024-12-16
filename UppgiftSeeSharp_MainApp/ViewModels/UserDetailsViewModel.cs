﻿using Business.Interfaces;
using Busniess.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Busniess.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftSeeSharp_MainApp.ViewModels;

public partial class UserDetailsViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    [ObservableProperty]
    private User _user = new();

    [RelayCommand]
    private void GoToEditView()
    {
        var userEditViewModel = _serviceProvider.GetRequiredService<UserEditViewModel>();
        userEditViewModel.User = User;

         var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = userEditViewModel;
    }

    [RelayCommand]
    private void Cancel()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }
}