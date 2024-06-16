using BreadFramework.Game;
using BreadRuntime.Enums;
using BreadRuntime.Settings;
using Memory;

namespace BreadRuntime.Modules;

public abstract class BaseModule
{
    protected Engine.KHEngine KhEngine;

    public Guid Id { get; } = Guid.NewGuid();
    
    public virtual KHGame Game { get; init; }
    
    public virtual string Author { get; init; }

    public virtual string Name { get;  init; }
    
    public virtual string Description { get;  init; }

    public abstract bool Initialise(Engine.KHEngine khEngine);

    public abstract void OnFrame();

    public bool Initialised { get; set; } = false;
    
    public bool Enabled => true;
    
    public virtual ModulePriority Priority => ModulePriority.Medium;

    public virtual List<ModuleSetting> GetSettings()
    {
        // Base settings
        var settings = new List<ModuleSetting>();
        settings.Add(new ModuleSetting()
        {
            Name = "Enabled",
            ValueAsString = "true"
        });

        return settings;
    }
    
}