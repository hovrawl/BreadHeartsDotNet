using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using BreadFramework.Patches;
using BreadHeartsLauncher.Classes;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.Config.Builders;
using BreadHeartsLauncher.Config.Models;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;

namespace BreadHeartsLauncher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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

    private void SetupModel()
    {
        // Setup main window model
        if (DataContext is not MainWindowViewModel viewModel) return;

        
    }

    private void MainWindow_Initialized(object? sender, EventArgs e)
    {
        SetupModel();
    }
}