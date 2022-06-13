using KHData.Enums;
using KHData.Flags;
using KHData.Helpers;

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
        
        var processAddress = KhEngine.Memory.mProc.MainModule.BaseAddress.ToInt64();
        var offset = GameFlags.Offset.GetAddress();
        
        var writeAddress1 = processAddress + offset -0x22A5AA;
        var writeAddress2 = processAddress + offset -0x225763;
        
        // var check1 = BitConverter.ToUInt32(KhEngine.ManualReader.ReadMemory(-0x22A5AA, 4));
        // var check2 = BitConverter.ToUInt32(KhEngine.ManualReader.ReadMemory(-0x22A75A, 4));
        var check1 = KhEngine.ReadUIntAbsolute(writeAddress1);
        var check2 = KhEngine.ReadUIntAbsolute(writeAddress2);
        if (check1 == 0xC3C0940F)
        {
            KhEngine.WriteBytesAbsolute(writeAddress1,  new List<int>{
                0x0F, 0x9E, 0xC0, 0xC3
            });
            KhEngine.WriteBytesAbsolute(writeAddress2,  new List<int> {0x7E, 0x10, 0x85, 0xDB});
        }
        else if (check2 == 0xC3C0940F)
        {
            KhEngine.WriteBytesAbsolute(writeAddress1,  new List<int>{
                0x0F, 0x9E, 0xC0, 0xC3
            });
            KhEngine.WriteBytesAbsolute(writeAddress2, new List<int> {
                0x7E, 0x10, 0x85, 0xDB
            });
        }
        
        CutsceneSkippable = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CutsceneSkippable);
        
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