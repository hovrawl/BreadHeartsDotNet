using System.ComponentModel.Composition;
using BreadFramework.Game;
using BreadRuntime.Enums;
using PluginBase.Settings;

namespace PluginBase;

[InheritedExport(typeof(BasePlugin))]
public abstract class BasePlugin
{
    protected EngineApi.EngineApi KhEngine;
    
    public Guid Id { get; } = Guid.NewGuid();
    
    public virtual KHGame Game { get; init; }
    
    public virtual string Author { get; init; }

    public virtual string Name { get;  init; }
    
    public virtual string Description { get;  init; }

    public abstract bool Initialise(EngineApi.EngineApi engine);
    
    public abstract void OnFrame(PluginState state);

    public bool Initialised { get; set; } = false;
    
    public virtual ModulePriority Priority => ModulePriority.Medium;

    public virtual PluginSettings GetSettings()
    {
        // Base settings
        var settings = new PluginSettings();

        return settings;
    }
    
}