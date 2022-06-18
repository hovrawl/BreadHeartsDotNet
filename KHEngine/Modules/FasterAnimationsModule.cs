using KHData.Enums;
using KHData.Flags;
using KHEngine.Extensions;
using Memory;

namespace KHEngine.Modules;

public class FasterAnimationsModule : BaseModule
{
    private bool summonSpeedup = true;
    private double speedMult = 2.0;
    private GameFlag SoraHud;
    private GameFlag Summoning;
    private GameFlag FramerateHack;
    private GameFlag InCutscene;
    private GameFlag CutsceneSkippable;
    
    public override string Author => "Denhonator";
    
    public override string Name => "Faster Animations";

    public override string Description => "Faster animations for opening chests etc.";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        SoraHud = KhEngine.GameFlagsRepo.GetFlag(GameFlags.SoraHud);
        Summoning = KhEngine.GameFlagsRepo.GetFlag(GameFlags.Summoning);
        FramerateHack = KhEngine.GameFlagsRepo.GetFlag(GameFlags.FramerateHack);
        InCutscene = KhEngine.GameFlagsRepo.GetFlag(GameFlags.InCutscene);
        CutsceneSkippable = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CutsceneSkippable);

        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        SoraHud.ReadMemory(KhEngine);
        Summoning.ReadMemory(KhEngine);
        InCutscene.ReadMemory(KhEngine);
        CutsceneSkippable.ReadMemory(KhEngine);
        
        var cutscene = InCutscene.ValueAsInt;
        var skippable = CutsceneSkippable.ValueAsInt;
        var summoning = Summoning.ValueAsInt;
        var soraHud = SoraHud.ValueAsBool;

        if (!soraHud && cutscene > 0 && cutscene != 8
        && skippable != 1025 && (summoning == 0 || summonSpeedup))
        {
            FramerateHack.WriteMemory(KhEngine, (float)speedMult);
            //KhEngine.WriteFloat(0x233C24C, (float)speedMult);
        }
        else
        {
            FramerateHack.WriteMemory(KhEngine, (float)1.0);
            //KhEngine. WriteFloat(0x233C24C, (float)1.0);
        }
    }
}