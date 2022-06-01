using Memory;

namespace KHEngine.Modules;

public class OpenInCombatModule: BaseModule
{
    public override string Name => "Open in Combat";

    public override string Description =>
        "Allows certain actions to be performed in combat.";

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