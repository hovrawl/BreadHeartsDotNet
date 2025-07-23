using System.Collections.ObjectModel;
using BreadHeartsLauncher.Config;
using BreadRuntime.Engine;

namespace BreadHeartsLauncher.ViewModels;

public class LauncherConfigViewModel : ViewModelBase
{
    public LauncherConfigViewModel(KHEngine khEngine) : base(khEngine)
    {
    }

    public ObservableCollection<LauncherConfig> ConfigItems { get; set; } = new();
}