using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using Avalonia.VisualTree;
using BreadHeartsLauncher.Config;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using Material.Icons;
using Material.Icons.Avalonia;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PluginBase;
using Splat;

namespace BreadHeartsLauncher.Views;

public partial class ModConfigView : UserControl
{
    private ModConfigViewModel ViewModel => (ModConfigViewModel)DataContext!;
    private KHEngine _khEngine => ViewModel.KhEngine;
    
    public ModConfigView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Initialize()
    {
        var directoryInfo = GetModsDirectoryInfo();
                
        // set ui components
        _khEngine.SetModsDirectory(directoryInfo, UiDispatchMethod);
        UpdateModsDirectoryUi();
    }

    private DirectoryInfo GetModsDirectoryInfo()
    {
        // If directory info already set
        if (_khEngine.ModsDirectoryInfo != null &&
            _khEngine.ModsDirectoryInfo.Exists)
            return _khEngine.ModsDirectoryInfo;
        
        // Else setup
        var config = Locator.Current.GetService<IConfig>();

        // Check saved patch
        var savedPath = config?.Paths.Patches ?? string.Empty;

        var modsDirectory = !string.IsNullOrEmpty(savedPath) ? new DirectoryInfo(savedPath) :
            // Else default to local patches directory
            new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Mods"));

        // Set directory
        return modsDirectory;
    }
    
    public void SetupGrid()
    {
        var modConfigDataGrid = this.Find<DataGrid>("ModConfigGrid");
        if (modConfigDataGrid == null) return;
        if (DataContext is not ModConfigViewModel viewModel) return;
        
        // Set view model modules reference to engine
        viewModel.PluginStates = _khEngine.PluginStates;
        modConfigDataGrid.ItemsSource = viewModel.PluginStates;
        
    }

    public void UiDispatchMethod(Action actionToDispatch)
    {
        if (!this.IsAttachedToVisualTree()) return;
        Dispatcher.UIThread.InvokeAsync(actionToDispatch);
    }
    
    private void UpdateModsDirectoryUi()
    {
        var modsDirectory = _khEngine.ModsDirectoryInfo;

        var directoryTextBlock = this.Find<TextBlock>("DirectoryPathTxt");
        var gameDirectoryIcon = this.Find<MaterialIcon>("ModsDirectoryStatusIcon");

        if (directoryTextBlock == null) return;
        if (gameDirectoryIcon == null) return;
        
        if (string.IsNullOrEmpty(modsDirectory.FullName))
        {
            directoryTextBlock.Text = "";
            gameDirectoryIcon.Kind = MaterialIconKind.CloseCircle; 
            return;
        }

        directoryTextBlock.Text = $"{modsDirectory.FullName}";
        gameDirectoryIcon.Kind = MaterialIconKind.CheckCircle; 

    }

    #region Events

    private void ModConfigView_Initialized(object? sender, EventArgs e)
    {
        Initialize();
    }

    private void ModConfigGrid_OnInitialized(object? sender, EventArgs e)
    {
        SetupGrid();
    }
    
    private void ResetBtn_OnClickBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private async void SelectModDirectoryBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        // Get top level from the current control. Alternatively, you can use Window reference instead.
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;
        
        var folderPickerOptions = new FolderPickerOpenOptions
        {
            Title = "Select Mods Directory",
            AllowMultiple = false,
            //SuggestedStartLocation = new IStorageFolder()
        };
        
        var directories = 
            await topLevel.StorageProvider.OpenFolderPickerAsync(folderPickerOptions);

        if (directories.Count < 1) return;
        
        var directory = directories[0];

        var directoryInfo = new DirectoryInfo(directory.Path.LocalPath);
        
        // find base KH directory and determine if STEAM or EPIC

        // set ui components
        _khEngine.SetModsDirectory(directoryInfo, UiDispatchMethod);
        
        directory.Dispose();

        UpdateModsDirectoryUi();

        var config = Locator.Current.GetService<IConfig>();

        //config?.Paths.SetPaths("Mods", directoryInfo.FullName);
        config?.Paths.SetModsPath(directoryInfo.FullName);
    }

    private void ModConfigBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if(sender is not Button button) return;
        
        if (button.DataContext is not PluginState pluginState) return;
        
        var settings = pluginState.PluginSettings;
        
        var pluginStateJson = JsonConvert.SerializeObject(pluginState);

        var pluginId = pluginState.Id.ToString();
        var config = Locator.Current.GetService<IPluginConfig>();
        config?.SetState(pluginId, pluginStateJson);
        
        var readState = config?.GetState(pluginId);
        if (readState == null) return;
        var stateConverted = JsonConvert.DeserializeObject<PluginState>(readState);
    }

    #endregion
   
}