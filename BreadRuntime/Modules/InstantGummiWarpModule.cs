using BreadFramework.Enums;
using BreadFramework.Flags;
using BreadFramework.Game;
using BreadRuntime.Extensions;
using Memory;

namespace BreadRuntime.Modules;

public class InstantGummiWarpModule: BaseModule
{
    private GameFlag WorldWarpBase;
    private GameFlag CutsceneFlagBase;
    private GameFlag DjProgressFlag;
    private GameFlag NeverlandProgressFlag;
    private GameFlag WorldSelection;
    
    public override KHGame Game => KHGame.KHFM;

    public override string Author => "Denhonator";
    
    public override string Name => "Instant Gummi Ship Warp";

    public override string Description => "Instantly warp the Gummi Ship when selecting a world";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        // Get Flags
        WorldWarpBase = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WorldWarpBase);
        CutsceneFlagBase = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CutsceneFlagBase);
        DjProgressFlag = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DjProgressFlag);
        NeverlandProgressFlag = KhEngine.GameFlagsRepo.GetFlag(GameFlags.NeverlandProgressFlag);
        WorldSelection = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WorldSelection);

        Initialised = success;

        return success;
    }

    public override void OnFrame()
    {
        var currentWorld = KhEngine.CurrentWorld;
        WorldSelection.ReadMemory(KhEngine, Priority);
        var selection = WorldSelection.ValueAsInt;
        // var selection = KhEngine.ReadInt(0x503CEC);
        // var realWorld = KhEngine.ReadInt(0x503C04);
        // var soraWorld = KhEngine.ReadInt(0x233CADC);
        
        var room = KhEngine.ReadInt(0x25346D0);
        var monstroInt = KhEngine.ReadByte(0x2DE78CA);
        var neverlandInt = KhEngine.ReadByte(CutsceneFlagBase.Address + 0xB0D);
        var deepJungleInt = KhEngine.ReadByte(CutsceneFlagBase.Address + 0xB05);
        
        var monstroOpen = monstroInt > 1;
        var neverlandState = neverlandInt < 0x14;
        var deepJungleState = deepJungleInt < 0x10;
        
        var realSelection = selection;

        KhEngine.WriteInt(WorldWarpBase.Address + 0x2A , deepJungleState ? 0 : 0xE);
        KhEngine.WriteInt(WorldWarpBase.Address + 0x2C , deepJungleState ? 0 : 0x2D);
        KhEngine.WriteInt(WorldWarpBase.Address + 0x9A , neverlandState ? 6 : 0x7);
        KhEngine.WriteInt(WorldWarpBase.Address + 0x9C , neverlandState ? 0x18 : 0x25);
        
        
        if (room > 0 && currentWorld.WorldId != selection)
        {
            WorldSelection.WriteMemory(KhEngine, Priority, currentWorld.WorldId);
            //KhEngine.WriteInt(0x503CEC, soraWorld);
        }
        
        // Replace HT and Atlantica with Monstro at first
        if (!monstroOpen )
        {
            switch (selection)
            {
                case 10:
                {
                    selection = 17;
                    break;
                }
                case 9:
                {
                    selection = 18;
                    break;
                }
            }
        }
        
        // Change warp to Hollow Bastion
        if (selection == 25)
        {
            selection = 15;
            WorldSelection.WriteMemory(KhEngine, Priority, selection);
            //KhEngine.WriteInt(0x503CEC, selection);
        }
        
        // Change warp to Agrabah
        if (selection == 21)
        {
            selection = 8;
            WorldSelection.WriteMemory(KhEngine, Priority, selection);
            //KhEngine.WriteInt(0x503CEC, selection);

        }
	
        // Go directly to location
        var curDest = KhEngine.ReadInt(0x5041F0);
        if (curDest < 40)
        {
            selection = selection > 20 ? 0 : selection;
            KhEngine.WriteInt(0x5041F0, selection);
            KhEngine.WriteInt(0x503C00, selection);
            KhEngine.WriteInt(0x2685EEC, 0);
        }

        else
        {
            KhEngine.WriteInt(0x503C00, realSelection);
        }
        
    }
}