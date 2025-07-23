using BreadHeartsLauncher.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BreadHeartsLauncher.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindowViewModel>();
    }
}