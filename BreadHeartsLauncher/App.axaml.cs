using System.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.Config.Builders;
using BreadHeartsLauncher.Config.Models;
using BreadHeartsLauncher.Extensions;
using BreadHeartsLauncher.Helpers;
using BreadHeartsLauncher.ViewModels;
using BreadHeartsLauncher.Views;
using Config.Net;
using Microsoft.Extensions.DependencyInjection;
using Splat;

namespace BreadHeartsLauncher;

public partial class App : Application
{
    public static ServiceProvider Services { get; set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // If you use CommunityToolkit, line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);
        
        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        // Add Common Services
        collection.AddCommonServices();
        
        // Add KhEngine
        collection.AddKhEngine();

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        var services = collection.BuildServiceProvider();
        Services = services;
        
        // Get mainViewModel 
        var mainViewModel = services.GetRequiredService<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            BooleanControlBuilder.Shared.Register();
            DirectoryPickerControlBuilder.Shared.Register();
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel,
            };
            
            BrowserDialog.StorageProvider = desktop.MainWindow.StorageProvider;
        }
        
        var configFile = new ConfigurationBuilder<IConfig>()
            .UseJsonFile("appsettings.json")
            .Build();
        
        var pluginConfig = new ConfigurationBuilder<IPluginConfig>()
            .UseJsonFile("modsettings.json")
            .Build();

        Locator.CurrentMutable.Register<IConfig>(() => configFile);
        Locator.CurrentMutable.Register<IPluginConfig>(() => pluginConfig);

        base.OnFrameworkInitializationCompleted();
    }

}