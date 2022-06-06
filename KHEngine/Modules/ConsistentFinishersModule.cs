using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class ConsistentFinishersModule: BaseModule
{
    private GameFlag GravityBreak;
    private GameFlag Zantetsuken;
    public override string Author => "Denhonator";
    
    public override string Name => "Consistent Finishers";

    public override string Description =>
        "30% chance finishers are now 100%";

    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        GravityBreak = new GameFlag
        {
            FlagName = "Gravity Break Hack",
            Address = GameFlags.GravityBreakHack.GetAddress()
        };
        Zantetsuken = new GameFlag
        {
            FlagName = "Zantetsuken Hack",
            Address = GameFlags.ZantetsukenHack.GetAddress()
        };
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        var zanteCheck = KhEngine.ReadByte(Zantetsuken.Address + 4);
        KhEngine.WriteFloat(GravityBreak.Address, (float)-1.0);
        if (zanteCheck == 0x6C)
        {
            KhEngine.WriteByte(Zantetsuken.Address + 4, 0xC4);
        }
        
    }
}