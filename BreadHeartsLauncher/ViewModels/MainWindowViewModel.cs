namespace BreadHeartsLauncher.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ModConfigViewModel ModConfigViewModel { get; set; } = new ();
    
    public ModConfigViewModel OpenKhPatchesViewModel { get; set; } = new ();
}