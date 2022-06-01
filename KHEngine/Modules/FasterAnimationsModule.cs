using Memory;

namespace KHEngine.Modules;

public class FasterAnimationsModule : BaseModule
{
    public override string Name => "Faster Animations";

    public override string Description => "Faster animations for opening chests etc.";
    
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