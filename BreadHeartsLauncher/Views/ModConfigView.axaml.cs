using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BreadHeartsLauncher.ViewModels;
using BreadRuntime.Engine;
using BreadRuntime.Modules;
using PluginBase;

namespace BreadHeartsLauncher.Views;

public partial class ModConfigView : UserControl
{
    public ModConfigView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ModConfigGrid_OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        RefreshGrid();
    }

    public void RefreshGrid()
    {
        var configGrid = this.Find<DataGrid>("ModConfigGrid");
        if (configGrid == null) return;
        if (DataContext is not ModConfigViewModel viewModel) return;
        
        // Add modules to grid
        var modules = KHEngine.Instance.GetModules();
            
        viewModel.Modules = new ObservableCollection<BasePlugin>(modules);
        configGrid.ItemsSource = viewModel.Modules;
    }
}