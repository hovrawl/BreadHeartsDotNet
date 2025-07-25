using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BreadFramework.Helpers;
using BreadFramework.Patches;
using BreadHeartsLauncher.Classes;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using BreadRuntime.Tools.Logging;
using Castle.Core.Configuration;
using Material.Icons;
using Material.Icons.Avalonia;
using Splat;

namespace BreadHeartsLauncher.Views;

public partial class ConsoleView : UserControl
{
    private ConsoleViewModel ViewModel => (ConsoleViewModel)DataContext!;
    private KHEngine _khEngine => ViewModel.KhEngine;
    
    public ConsoleView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void StartEngineBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        // Start engine
        ConsoleManager.WriteLine("Starting engine...");
        _khEngine.Start();
        _khEngine.OnLogMessage += OnLogMessage;

    }

    private void OnLogMessage(object? sender, LogEventArgs args)
    {
        var entry = args.LogEntry;
        var color = entry.Level switch
        {
            BreadRuntime.Tools.Logging.LogLevel.Error => ConsoleColor.Red,
            BreadRuntime.Tools.Logging.LogLevel.Warning => ConsoleColor.Yellow,
            BreadRuntime.Tools.Logging.LogLevel.Info => ConsoleColor.White,
            BreadRuntime.Tools.Logging.LogLevel.Debug => ConsoleColor.Gray,
            _ => ConsoleColor.White
        };

        Console.ForegroundColor = color;
        Console.WriteLine(entry.ToString());
        Console.ResetColor();
    }

    private void StopEngineBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        // Stop engine
        ConsoleManager.WriteLine("Stopping engine...");
        _khEngine.OnLogMessage -= OnLogMessage;
        _khEngine.Stop();
    }

    private void ConsoleViewInitialized(object? sender, EventArgs e)
    {
        // console tab is attached
        var console = this.Find<TextBlock>("ConsoleTextBlock");
        
        if (console is null) return;
        
        ConsoleManager.Initialize(console);

        ConsoleManager.Write("Console Initialized...");
        
        InitializeRuntime();
    }

    private void InitializeRuntime()
    {
        ConsoleManager.WriteLine("Initializing runtime...");
        
        // Initialise and cache engine
        _khEngine.Initialise();

        // Auto-detect Game Directory
        AutoDetectDirectory();
    }
    
    private void AutoAttach()
    {
        ConsoleManager.WriteLine("Checking for running game...");

        _khEngine.Attach();
    }
    
    
    private void AutoDetectDirectory()
    {

        var directory = DirectoryHelper.AutoDetectGameDirectory();
        if (string.IsNullOrEmpty(directory.Path)) return;
        
        _khEngine.SetGameDirectory(directory);
        
        UpdateGameDirectoryUi();
    }
    
    private void UpdateGameDirectoryUi()
    {
        var gameDirectory = _khEngine.GameDirectoryInfo;

        var directoryTextBlock = this.Find<TextBlock>("DirectoryPathTxt");
        var gameDirectoryIcon = this.Find<MaterialIcon>("GameDirectoryStatusIcon");

        if (directoryTextBlock == null) return;
        if (gameDirectoryIcon == null) return;
        
        if (string.IsNullOrEmpty(gameDirectory.Path))
        {
            directoryTextBlock.Text = "";
            gameDirectoryIcon.Kind = MaterialIconKind.CloseCircle; 
            return;
        }
        

        directoryTextBlock.Text = $"{gameDirectory.Platform:G}";
        gameDirectoryIcon.Kind = MaterialIconKind.CheckCircle; 

    }

}