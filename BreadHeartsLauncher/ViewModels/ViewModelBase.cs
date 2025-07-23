using BreadRuntime.Engine;
using ReactiveUI;

namespace BreadHeartsLauncher.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public KHEngine KhEngine { get; init; }
    public ViewModelBase(KHEngine khEngine)
    {
        KhEngine = khEngine;
    }
}