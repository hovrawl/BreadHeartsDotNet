using BreadFramework.Flags;
using BreadFramework.Game;
using PluginBase;

namespace BreadRuntime.Modules;

public class FasterDialogPlugin: BasePlugin
{
    private int lastProg = 0;
    private bool textSpeedup = false;
    private bool turbo = false;
    
    private GameFlag TextBoxProgression;
    private GameFlag TextBoxTransition;
    private GameFlag TextBoxSpeed;
    
    public override KHGame Game => KHGame.KHFM;

    public override string Author => "Denhonator";
    
    public override string Name => "Faster Dialog";

    public override string Description => "Show the text box dialog faster";

    public override bool Initialise(EngineApi.EngineApi khEngine)
    {
        var success = true;

        KhEngine = khEngine;

        TextBoxProgression = KhEngine.GameFlagsRepo.GetFlag(GameFlags.TextBoxProgression);
        TextBoxTransition = KhEngine.GameFlagsRepo.GetFlag(GameFlags.TextBoxTransition);
        TextBoxSpeed = KhEngine.GameFlagsRepo.GetFlag(GameFlags.TextBoxSpeed);
        
        textSpeedup = true;
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        TextBoxProgression.ReadMemory(KhEngine, Priority);
        
        //var textProg = KhEngine.ReadShort(0x232A5F4);
        var textProg = TextBoxProgression.ValueAsInt;

        TextBoxTransition.WriteMemory(KhEngine, Priority, (float)0);
        //KhEngine.WriteFloat(0x22E8744, 0); // finishes box transitions;

        if (textProg > lastProg && lastProg > 0 && textSpeedup ) // 1 frame turbo
        {
            TextBoxSpeed.WriteMemory(KhEngine, Priority, (float)100.0);
            //KhEngine.WriteFloat(0x233C25C, (float)100.0);
            turbo = true;
        }
        else if (turbo)
        {
            TextBoxSpeed.WriteMemory(KhEngine, Priority, (float)0);
            //KhEngine.WriteFloat(0x233c25c, (float)1.0);
        }
        lastProg = textProg;
    }
}