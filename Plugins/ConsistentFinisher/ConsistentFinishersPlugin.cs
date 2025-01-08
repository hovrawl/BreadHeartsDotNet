using BreadFramework.Flags;
using BreadFramework.Game;
using PluginBase;

public class ConsistentFinishersPlugin: BasePlugin
{
    private GameFlag GravityBreak;
    private GameFlag Zantetsuken;

    public override KHGame Game => KHGame.KHFM;

    public override string Author => "Denhonator";
    
    public override string Name => "Consistent Finishers";

    public override string Description =>
        "30% chance finishers are now 100%";

    
    public override bool Initialise(EngineApi.EngineApi engine)
    {
        var success = true;

        KhEngine = engine;
        GravityBreak = KhEngine.GameFlagsRepo.GetFlag(GameFlags.GravityBreakHack);
        Zantetsuken = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ZantetsukenHack);
        
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        //var zanteCheck = KhEngine.ReadByte(Zantetsuken.Address);
        // KhEngine.WriteFloat(GravityBreak.Address, (float)-1.0);

        Zantetsuken.ReadMemory(KhEngine, Priority);
        GravityBreak.WriteMemory(KhEngine, Priority, (float)-1.0);
        if (Zantetsuken.ValueAsInt == 0x6C)
        {
            Zantetsuken.WriteMemory(KhEngine, Priority, 0xC4);
            //KhEngine.WriteByte(Zantetsuken.Address, 0xC4);
        }
        
    }
}