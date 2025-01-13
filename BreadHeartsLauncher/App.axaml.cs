using System.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.ViewModels;
using BreadHeartsLauncher.Views;
using Config.Net;
using Splat;

namespace BreadHeartsLauncher;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
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
    } }