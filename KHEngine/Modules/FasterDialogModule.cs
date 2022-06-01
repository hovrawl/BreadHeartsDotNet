using Memory;

namespace KHEngine.Modules;

public class FasterDialogModule: BaseModule
{
    public override string Name => "Faster Dialog";

    public override string Description => "Show the text box dialog faster";

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