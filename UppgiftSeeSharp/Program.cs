using Business.Interfaces;
using Busniess.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UppgiftSeeSharp.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IFileService>(new FileService(fileName: "users.json"));
        services.AddSingleton<UserService>();

        services.AddSingleton<MenuDialogs>();
    })
    .Build();

Menu menu = host.Services.GetRequiredService<MenuDialogs>();
menu.RunMenu();