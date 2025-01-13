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
using BreadRuntime.Engine;
using Castle.Core.Configuration;
using Material.Icons;
using Material.Icons.Avalonia;
using Splat;

namespace BreadHeartsLauncher.Views;

public partial class ConsoleView : UserControl
{
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
        KHEngine.Instance.Start();
    }

    private void StopEngineBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        // Stop engine
        ConsoleManager.WriteLine("Stopping engine...");
        KHEngine.Instance.Stop();
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
        KHEngine.Instance.Initialise();

        // Auto-detect Game Directory
        AutoDetectDirectory();
    }
    
    private void AutoAttach()
    {
        ConsoleManager.WriteLine("Checking for running game...");

        KHEngine.Instance.Attach();
    }
    
    
    private void AutoDetectDirectory()
    {

        var directory = DirectoryHelper.AutoDetectGameDirectory();
        if (string.IsNullOrEmpty(directory.Path)) return;
        
        KHEngine.Instance.SetGameDirectory(directory);
        
        UpdateGameDirectoryUi();
    }
    
    private void UpdateGameDirectoryUi()
    {
        var gameDirectory = KHEngine.Instance.GameDirectoryInfo;

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