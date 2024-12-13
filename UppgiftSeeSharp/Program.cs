using Business.Helpers;
using Business.Interfaces;
using Business.Services;
using Busniess.Factories;
using Busniess.Helpers;
using Busniess.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UppgiftSeeSharp.Interfaces;
using UppgiftSeeSharp.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<IUserService, UserService>();
        /* Settomg up the UserFactory, logger and uniqueIdService with the help of chatgpt4 */
        services.AddTransient<ErrorLogger>();
        services.AddTransient<UniqueIdGenerator>();
        services.AddTransient<InputHandler>();
        services.AddTransient<MessageHandler>();
        services.AddTransient<UserInputService>();
        services.AddTransient<UserFactory, UserFactory>();
        services.AddTransient<IMenuDialogs, MenuDialogs>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetRequiredService<IMenuDialogs>();

mainMenu.RunMenu();
