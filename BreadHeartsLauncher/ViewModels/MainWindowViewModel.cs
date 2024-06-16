namespace BreadHeartsLauncher.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ModConfigViewModel ModConfigViewModel { get; set; } = new ModConfigViewModel();
    
    public ModConfigViewModel OpenKhPatchesViewModel { get; set; } = new ModConfigViewModel();
}