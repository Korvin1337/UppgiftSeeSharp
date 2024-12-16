using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UppgiftSeeSharp_MainApp.ViewModels;
using UppgiftSeeSharp_MainApp.Views;
using Business.Interfaces;
using Busniess.Services;
using Business.Services;
using Busniess.Factories;
using Business.Helpers;
using Busniess.Helpers;

namespace UppgiftSeeSharp_MainApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient<IFileService, FileService>();
                services.AddTransient<IUserService, UserService>();
                /* Settomg up the UserFactory, logger and uniqueIdService with the help of chatgpt4 */
                services.AddTransient<ErrorLogger>();
                services.AddTransient<UniqueIdGenerator>();
                services.AddTransient<InputHandler>();
                services.AddTransient<MessageHandler>();
                services.AddTransient<ConsoleWrapper>();
                services.AddTransient<UserInputService>();
                services.AddTransient<UserFactory>();

                services.AddTransient<UserListViewModel>();
                services.AddTransient<UserAddViewModel>();
                services.AddTransient<UserDetailsViewModel>();
                services.AddTransient<UserEditViewModel>();


                services.AddTransient<UserListView>();
                services.AddTransient<UserAddView>();
                services.AddTransient<UserDetailsView>();
                services.AddTransient<UserEditView>();


                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<UserListViewModel>();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.Dispose();
        base.OnExit(e);
    }
}
