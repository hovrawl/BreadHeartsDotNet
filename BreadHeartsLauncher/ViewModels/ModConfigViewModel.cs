using System.Collections.ObjectModel;
using BreadFramework.Patches;
using BreadRuntime.Engine;
using PluginBase;

namespace BreadHeartsLauncher.ViewModels;

public class ModConfigViewModel : ViewModelBase
{
    public ModConfigViewModel(KHEngine khEngine) : base(khEngine)
    {
    }

    public ObservableCollection<PluginState> PluginStates { get; set; } = new ();
    
    public ObservableCollection<OpenKhPatch> OpenKhPatches { get; set; } = new ();

    
}