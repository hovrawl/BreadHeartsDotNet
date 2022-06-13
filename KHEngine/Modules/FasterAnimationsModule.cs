using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class FasterAnimationsModule : BaseModule
{
    private bool summonSpeedup = true;
    private double speedMult = 2.0;
    private GameFlag SoraHud;
    
    public override string Author => "Denhonator";
    
    public override string Name => "Faster Animations";

    public override string Description => "Faster animations for opening chests etc.";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        SoraHud = KhEngine.GameFlagsRepo.GetFlag(GameFlags.SoraHud);

        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        var cutscene = KhEngine.ReadInt(0x2378B60);
        var skippable = KhEngine.ReadInt(0x23944E4);
        var summoning = KhEngine.ReadInt(0x2D5D62C);
        var soraHud = KhEngine.ReadInt(SoraHud.Address);

        if (soraHud < 1 && cutscene > 0 && cutscene != 8
        && skippable != 1025 && (summoning == 0 || summonSpeedup))
        {
            KhEngine.WriteFloat(0x233C24C, (float)speedMult);
        }
        else
        {
            KhEngine. WriteFloat(0x233C24C, (float)1.0);
        }
    }
}