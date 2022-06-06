using KHData.Enums;
using KHData.Flags;

namespace KHEngine.Modules;

public class UnskippableModule : BaseModule
{
    private int lastCutscene = 0;
    private int lastSkippable = 0;
    private int lastInput = 0;
    private int lastFade = 0;
    
    // private GameFlag SoraHud;
    // private GameFlag BlackFade;
    private GameFlag CutsceneSkippable;

    public bool EarlySkip;
    
    public override string Author => "Denhonator/TopazTK";
    
    public override string Name => "Unskippable";

    public override string Description => "Makes unskippable cutscenes skippable + allows cutscenes to be skipped earlier";
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        // SoraHud = new GameFlag
        // {
        //     FlagName = "Sora Hud Visible",
        //     Address = GameFlags.SoraHud.GetAddress()
        // };
        // BlackFade = new GameFlag
        // {
        //     FlagName = "Black fade on screen",
        //     Address = GameFlags.BlackFade.GetAddress()
        // };
        var check1 = KhEngine.ReadInt(-0x22A5AA);
        if (check1 == 0xC3C0940F)
        {
            KhEngine.WriteBytes(-0x22A5AA,  new List<int>{
                0x0F, 0x9E, 0xC0, 0xC3
            });
            KhEngine.WriteBytes(-0x225763,  new List<int> {0x7E, 0x10, 0x85, 0xDB});
        }
        else if (KhEngine.ReadInt(-0x22A75A) == 0xC3C0940F)
        {
            KhEngine.WriteBytes(-0x22A75A,  new List<int>{
                0x0F, 0x9E, 0xC0, 0xC3
            });
            KhEngine.WriteBytes(-0x225913, new List<int> {
                0x7E, 0x10, 0x85, 0xDB
            });
        }
        
        CutsceneSkippable = new GameFlag
        {
            FlagName = "Can the cutscene be skipped",
            Address = GameFlags.CutsceneSkippable.GetAddress()
        };
        EarlySkip = true;
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        var cutsceneNow = KhEngine.ReadInt(0x233AE74);
        var skippableStatus = KhEngine.ReadByte(CutsceneSkippable.Address);
        var summoning = KhEngine.ReadInt(0x2D5D62C);
        // var HUD = KhEngine.ReadFloat(SoraHud.Address);
        // var blackFade = KhEngine.ReadByte(BlackFade.Address);
        var worldId = KhEngine.CurrentWorld.Address;
        
        if (cutsceneNow > 0 && (worldId == 4 || worldId >= 0xF) && summoning == 0)
        {
            KhEngine.WriteByte(CutsceneSkippable.Address, 1); // make skippable
        }

        lastSkippable = skippableStatus;
        lastCutscene = cutsceneNow;
    }
}