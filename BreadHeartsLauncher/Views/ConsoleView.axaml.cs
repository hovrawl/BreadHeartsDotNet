using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using BreadHeartsLauncher.Classes;
using BreadRuntime.Engine;

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
}