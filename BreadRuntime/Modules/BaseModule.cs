using BreadRuntime.Enums;
using BreadRuntime.Settings;
using Memory;

namespace BreadRuntime.Modules;

public abstract class BaseModule
{
    protected Engine.KHEngine KhEngine;

    public Guid Id { get; } = Guid.NewGuid();
    
    public abstract string Author { get; }
    
    public abstract string Name { get; }
    
    public abstract string Description { get; }

    public abstract bool Initialise(Engine.KHEngine khEngine);

    public abstract void OnFrame();

    public bool Initialised { get; set; } = false;
    
    public bool Enabled => true;
    
    public ModulePriority Priority => ModulePriority.Medium;

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