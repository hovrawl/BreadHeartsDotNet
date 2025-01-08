using System.Collections.ObjectModel;
using PluginBase;

namespace BreadHeartsLauncher.ViewModels;

public class ModConfigViewModel : ViewModelBase
{
    public ObservableCollection<BasePlugin> Modules { get; set; } = new ObservableCollection<BasePlugin>();

    
}