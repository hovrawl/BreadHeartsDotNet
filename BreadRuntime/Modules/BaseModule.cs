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

    public bool Initialised = false;
}