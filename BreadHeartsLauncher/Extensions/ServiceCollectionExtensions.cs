using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace BreadHeartsLauncher.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<ConsoleViewModel>();
        collection.AddTransient<ModConfigViewModel>();
        collection.AddTransient<LauncherConfigViewModel>();
    }
    
    public static void AddKhEngine(this IServiceCollection collection)
    {
        collection.AddSingleton<KHEngine>();
    }
}