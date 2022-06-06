using Memory;

namespace KHEngine.Modules;

public class FasterDialogModule: BaseModule
{
    private int lastProg = 0;
    private bool textSpeedup = false;
    private bool turbo = false;
        
    public override string Author => "Denhonator";
    
    public override string Name => "Faster Dialog";

    public override string Description => "Show the text box dialog faster";

    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        var textProg = KhEngine.ReadShort(0x232A5F4 - 0x3A0606);

        KhEngine.WriteFloat(0x22E8744 - 0x3A0606, 0); // finishes box transitions;

        if (textProg > lastProg && lastProg > 0 && textSpeedup ) // 1 frame turbo
        {
            KhEngine.WriteFloat(0x233C25C - 0x3A0606, (float)100.0);
            turbo = true;
        }
        else if (turbo)
        {
            KhEngine.WriteFloat(0x233c25c - 0x3A0606, (float)1.0);
        }
        lastProg = textProg;
    }
}