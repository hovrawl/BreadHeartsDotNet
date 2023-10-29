using System.Collections.ObjectModel;
using BreadRuntime.Modules;

namespace BreadHeartsLauncher.ViewModels;

public class ModConfigViewModel : ViewModelBase
{
    public ObservableCollection<BaseModule> Modules { get; set; } = new ObservableCollection<BaseModule>();

    
}