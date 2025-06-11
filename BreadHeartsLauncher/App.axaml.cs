using System.Configuration;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.Config.Builders;
using BreadHeartsLauncher.Config.Models;
using BreadHeartsLauncher.Helpers;
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
            BooleanControlBuilder.Shared.Register();
            DirectoryPickerControlBuilder.Shared.Register();
            
            var mainViewModel = new MainWindowViewModel();
            
            var gameDirectory = new LauncherConfig
            {
                Key = "GameDirectory",
                Header = "Game Directory",
                Description = "Kingdom Hearts Final Mix 1.5 & 2.5 Directory",
                ConfigModel = new DirectoryPickerConfigModel()
                {
                    BrowserMode = BrowserMode.OpenFolder,
                }
            };
        

            gameDirectory.BuildControl();
        
            mainViewModel.LauncherConfigViewModel.ConfigItems.Add(gameDirectory);
            
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
    } }