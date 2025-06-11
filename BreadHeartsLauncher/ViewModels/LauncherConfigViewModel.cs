using System.Collections.ObjectModel;
using BreadHeartsLauncher.Config;

namespace BreadHeartsLauncher.ViewModels;

public class LauncherConfigViewModel : ViewModelBase
{
    public ObservableCollection<LauncherConfig> ConfigItems { get; set; } = new();
}