using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using BreadFramework.Game;
using BreadFramework.Helpers;
using BreadHeartsLauncher.Classes;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using BreadRuntime.Modules;
using BreadRuntime.Tools;
using Material.Icons;
using Material.Icons.Avalonia;
using PluginBase;

namespace BreadHeartsLauncher.Views;

public partial class OpenKhPatchView : UserControl
{
    public OpenKhPatchView()
    {
        InitializeComponent();
    }

    private void OpenKhPatchGrid_OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        RefreshGrid();
        AutoDetectDirectory();
    }
    
    private void RefreshGrid()
    {
        var configGrid = this.Find<DataGrid>("OpenKhPatchGrid");
        if (configGrid == null) return;
        if (DataContext is not ModConfigViewModel viewModel) return;
        
        // Add modules to grid
        var modules = KHEngine.Instance.GetModules();
        var openKhPatches = modules.Where(i => i is OpenKhPatchPlugin);
        viewModel.Modules = new ObservableCollection<BasePlugin>(openKhPatches);
        configGrid.ItemsSource = viewModel.Modules;
    }

    private void AutoDetectDirectory()
    {

        var directory = DirectoryHelper.AutoDetectGameDirectory();
        if (string.IsNullOrEmpty(directory.Path)) return;
        
        KHEngine.Instance.SetGameDirectory(directory);
        
        UpdateGameDirectoryUi();
    }

    private void PatchBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        PatchGame();
    }

    private void UnPatchBtn_OnClick(object? sender, RoutedEventArgs e)
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
        KHEngine.Instance.SetGameDirectory(gameDirectory);

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
    
    

    public void PatchGame()
    {
        var patchType = KHGame.KHFM;
        var backupPkg = false;
        var extractPkg = false;
        var patchFiles = new List<string>();
        var patchDirectory = Path.Combine(Environment.CurrentDirectory, "mods");
        if (Directory.Exists(patchDirectory))
        {
            foreach (var patchFile in Directory.EnumerateFiles(patchDirectory))
            {
                patchFiles.Add(patchFile);
            }
        }

        if (patchFiles.Count < 1)
        {
            ConsoleManager.WriteLine("No patches found.");
            return;
        }
        
        var bgWorker = new PatchBackgroundWorker();
        bgWorker.ProgressChanged += (s, e) =>
        {
            if (e.UserState != null) ConsoleManager.WriteLine((string)e.UserState);
            //if (GUI_Displayed) status.Text = (string)e.UserState;
        };
        KHEngine.Instance.PatchFiles(patchFiles, patchType, bgWorker,  backupPkg, extractPkg);
    }

    
}