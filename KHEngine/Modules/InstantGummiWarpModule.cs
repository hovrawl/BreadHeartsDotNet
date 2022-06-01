using Memory;

namespace KHEngine.Modules;

public class InstantGummiWarpModule: BaseModule
{
    public override string Name => "Instant Gummi Ship Warp";

    public override string Description => "Instantly warp the Gummi Ship when selecting a world";
    
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