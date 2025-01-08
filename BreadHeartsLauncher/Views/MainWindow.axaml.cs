using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using BreadHeartsLauncher.Classes;
using BreadRuntime.Engine;
using BreadRuntime.Modules;

namespace BreadHeartsLauncher.Views;

public partial class MainWindow : Window
{
    public static KHEngine Engine;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ConsoleAttached(object? sender, VisualTreeAttachmentEventArgs e)
    {
        // console tab is attached
        if (ConsoleTab.Content is not ConsoleView consoleView) return;
        
        var console = consoleView.Find<TextBlock>("ConsoleTextBlock");
        ConsoleManager.Initialize(console);

        ConsoleManager.Write("Console Initialized...");

        
        InitializeRuntime();
    }


    private void AutoAttach()
    {
        ConsoleManager.WriteLine("Checking for running game...");

        Engine.Attach();

    }

    private void InitializeRuntime()
    {
        ConsoleManager.WriteLine("Initializing runtime...");
        
        // Initialise and cache engine
        KHEngine.Instance.Initialise();

        Engine = KHEngine.Instance;
        
        // Detect file patches
        DetectMods();

        // Auto-attach to running game
        AutoAttach();
    }

    private void LauncherTab_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        // interrogate selected tab and refresh views if needed
        
        if(sender is not TabControl tabControl) return;

        if (tabControl.SelectedItem is not TabItem selectedTab) return;
        
        if (selectedTab.Name.Equals("ConfigTab"))
        {
            // Changing to the view will re-attach grid to ui
            // var configView = selectedTab.Content as ModConfigView;
            // configView.RefreshGrid();
        }
    }

    private void DetectMods()
    {
        var modDirectory = Path.Combine(Environment.CurrentDirectory, "Mods");

        if (!Directory.Exists(modDirectory)) return;
        foreach (var patchFile in Directory.EnumerateFiles(modDirectory))
        {
            var fileName = Path.GetFileName(patchFile);
            var patchModule = new OpenKhPatchPlugin
            {
                PatchFilePath = patchFile,
                Name = fileName,
                Description = "OpenKH Format file patch"
            };
            Engine.AddModule(patchModule);
        }
        
        
    }
}