using Memory;

namespace KHEngine.Modules;

public abstract class BaseModule
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public abstract string Author { get; }
    
    public abstract string Name { get; }
    
    public abstract string Description { get; }


    public Engine.KHEngine KhEngine;
    
    public abstract bool Initialise(Engine.KHEngine khEngine);

    public abstract void OnFrame();

    public bool Initialised = false;
}