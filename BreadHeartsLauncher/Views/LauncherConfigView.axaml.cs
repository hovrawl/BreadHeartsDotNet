using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using BreadFramework.Helpers;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;

namespace BreadHeartsLauncher.Views;

public partial class LauncherConfigView : UserControl
{
    private LauncherConfigViewModel ViewModel => (LauncherConfigViewModel)DataContext!;
    private KHEngine _khEngine => ViewModel.KhEngine;
    
    public LauncherConfigView()
    {
        InitializeComponent();
    }

    private void LauncherConfigView_Initialized(object? sender, EventArgs e)
    {
        
    }
    
    private async void SelectDirectoryBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;
        
        var directories = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Game Directory",
            AllowMultiple = false,
            //SuggestedStartLocation = new IStorageFolder()
            
        });

        if (directories.Count < 1) return;
        
        var directory = directories[0];

        var directoryInfo = new DirectoryInfo(directory.Path.LocalPath);
        
        // find base KH directory and determine if STEAM or EPIC
        
        var gameDirectory = DirectoryHelper.VerifyGameDirectory(directoryInfo);

        directory.Dispose();

        // set ui components
        _khEngine.SetGameDirectory(gameDirectory);
    }
}