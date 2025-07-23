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
using BreadFramework.Patches;
using BreadHeartsLauncher.Classes;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using BreadRuntime.Tools;
using Material.Icons;
using Material.Icons.Avalonia;
using PluginBase;
using Splat;

namespace BreadHeartsLauncher.Views;

public partial class OpenKhPatchView : UserControl
{
    private ModConfigViewModel ViewModel => (ModConfigViewModel)DataContext!;
    private KHEngine _khEngine => ViewModel.KhEngine;
    
    public OpenKhPatchView()
    {
        InitializeComponent();
    }

    private void Initalize()
    {
        // Setup initial patches, whether default of saved directories
        _khEngine.ClearPatches();
        DetectPatches();
    }
    
    private void RefreshGrid()
    {
        var configGrid = this.Find<DataGrid>("OpenKhPatchGrid");
        if (configGrid == null) return;
        if (DataContext is not ModConfigViewModel viewModel) return;
        
        // Add modules to grid
        var openKhPatches = _khEngine.Patches;
        viewModel.OpenKhPatches = openKhPatches;
        configGrid.ItemsSource = viewModel.OpenKhPatches;
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
        _khEngine.PatchFiles(patchFiles, patchType, bgWorker,  backupPkg, extractPkg);
    }

    private DirectoryInfo GetPatchesDirectoryInfo()
    {
        // If directory info already set
        if (_khEngine.PatchesDirectoryInfo != null &&
            _khEngine.PatchesDirectoryInfo.Exists)
            return _khEngine.PatchesDirectoryInfo;
        
        // Else setup
        var config = Locator.Current.GetService<IConfig>();

        // Check saved patch
        var savedPath = config?.Paths.Patches ?? string.Empty;

        var patchesDirectory = !string.IsNullOrEmpty(savedPath) ? new DirectoryInfo(savedPath) :
            // Else default to local patches directory
            new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Patches"));

        return patchesDirectory;
    }
    
    private void DetectPatches()
    {
        var patchesDirectory = GetPatchesDirectoryInfo();

        if (!patchesDirectory.Exists) return;
        
        // Set directory
        _khEngine.SetPatchesDirectory(patchesDirectory);
        
        // Add patches
        foreach (var patchFile in patchesDirectory.EnumerateFiles())
        {
            var patchModule = new OpenKhPatch
            {
                PatchFilePath = patchFile.FullName,
                Name = patchFile.Name,
                Enabled = true,
            };
            _khEngine.AddPatch(patchModule);
        }
    }

    private void UpdatePatchDirectoryUi()
    {
        var patchDirectory = _khEngine.PatchesDirectoryInfo;

        var directoryTextBlock = this.Find<TextBlock>("DirectoryPathTxt");
        var directoryIcon = this.Find<MaterialIcon>("DirectoryStatusIcon");

        if (directoryTextBlock == null) return;
        if (directoryIcon == null) return;
        
        if (patchDirectory == null || !patchDirectory.Exists)
        {
            directoryTextBlock.Text = "";
            directoryIcon.Kind = MaterialIconKind.CloseCircle; 
            return;
        }
        

        directoryTextBlock.Text = $"{patchDirectory.FullName}";
        directoryIcon.Kind = MaterialIconKind.CheckCircle; 

    }
    
    private async void SelectPatchDirectory()
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;
        
        var directories = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = "Select Patch Directory",
            AllowMultiple = false,
            //SuggestedStartLocation = new IStorageFolder()
            
        });

        if (directories.Count < 1) return;
        
        var directory = directories[0];

        var directoryInfo = new DirectoryInfo(directory.Path.LocalPath);

        // set ui components
        _khEngine.SetPatchesDirectory(directoryInfo);
        UpdatePatchDirectoryUi();
    }

    #region Events

    private void OpenKhPatchView_Initialized(object? sender, EventArgs e)
    {
        Initalize();
    }

    
    
    private void PatchBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        PatchGame();
    }

    private void UnPatchBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void SelectDirectoryBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        SelectPatchDirectory();
    }

    private void OpenKhPatchGrid_OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        
    }

    #endregion
}