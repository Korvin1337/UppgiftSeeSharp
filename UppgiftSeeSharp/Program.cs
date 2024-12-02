using Business.Interfaces;
using Busniess.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UppgiftSeeSharp.Interfaces;
using UppgiftSeeSharp.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IMenuDialogs, MenuDialogs>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var mainMenu = scope.ServiceProvider.GetRequiredService<IMenuDialogs>();

mainMenu.RunMenu();
