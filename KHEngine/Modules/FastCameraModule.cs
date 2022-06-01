using Memory;

namespace KHEngine.Modules;

public class FastCameraModule : BaseModule
{
    public override string Name => "Fast Camera";

    public override string Description => "Allows for faster camera control.";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;
        
        return success;
    }

    public override void OnFrame()
    {
        
    }
}