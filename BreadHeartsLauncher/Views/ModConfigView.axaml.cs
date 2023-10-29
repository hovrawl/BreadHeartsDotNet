using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}