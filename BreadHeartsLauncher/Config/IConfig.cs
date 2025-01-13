using System.ComponentModel;

namespace BreadHeartsLauncher.Config;

public interface IConfig: INotifyPropertyChanged
{
    IPaths Paths { get; set; }
}