using Memory;

namespace KHEngine.Modules;

public class ConsistentFinishersModule: BaseModule
{
    public override string Name => "Consistent Finishers";

    public override string Description =>
        "Warp to Gummi Ship at any time by pressing both bumpers and both analog sticks.";

    
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