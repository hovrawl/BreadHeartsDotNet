using System.Collections.ObjectModel;
using BreadFramework.Patches;
using PluginBase;

namespace BreadHeartsLauncher.ViewModels;

public class ModConfigViewModel : ViewModelBase
{
    public ObservableCollection<PluginState> PluginStates { get; set; } = new ();
    
    public ObservableCollection<OpenKhPatch> OpenKhPatches { get; set; } = new ();

    
}