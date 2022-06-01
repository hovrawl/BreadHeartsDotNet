using Memory;

namespace KHEngine.Modules;

public class SaveAnywhereModule: BaseModule
{
    public override string Name => "Save Anywhere";

    public override string Description => "Open the save menu anywhere via pressing Both Bumpers + Left Trigger + Select .";
    
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