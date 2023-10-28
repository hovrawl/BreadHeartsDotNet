using BreadFramework.Enums;
using BreadFramework.Flags;
using Memory;

namespace BreadRuntime.Modules;

public class QuickOverworldWarpModule: BaseModule
{
    private GameFlag WarpRequirement1;
    private GameFlag WarpRequirement2;
    private GameFlag LastUsedOverworldMap;
    private GameFlag Warp;
    private GameFlag ButtonPress;
    private GameFlag ShoulderPress;
    private WorldInfo CurrentWorld;


    public override string Author => "KSX";
    public override string Name => "Quick Warp to Gummi Ship";

    public override string Description =>
        "Warp to Gummi Ship at any time by pressing both bumpers and both analog sticks.";

    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;

        WarpRequirement1 = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpRequirement1);
        WarpRequirement2 = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpRequirement2);
        LastUsedOverworldMap = KhEngine.GameFlagsRepo.GetFlag(GameFlags.LastUsedOverworldMap);
        ButtonPress = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ButtonPress);
        ShoulderPress = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ShoulderPress);
        Warp = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpTrigger);

        Initialised = success;

        return success;
    }

    public override void OnFrame()
    {
        var buttonPress = KhEngine.ReadInt(ButtonPress.Address);
        var shoulderPress = KhEngine.ReadInt(ShoulderPress.Address);
        CurrentWorld = KhEngine.CurrentWorld;
        if (buttonPress == 0x06)
        {
            //
        }
        if (shoulderPress == 0x03)
        {
            //
        }

        // if (buttonPress > 0)
        // {
        //     Console.WriteLine($"Button Press: {buttonPress}");
        // }
        // if (shoulderPress > 0)
        // {
        //     Console.WriteLine($"Shoulder Press: {shoulderPress}");
        // }
        // If both shoulder buttons are pressed and both analog sticks are pressed, warp out
        if(buttonPress == 0x06 && shoulderPress == 0x03 || buttonPress == 774 && shoulderPress == 0x03)
        {
            // Set warp flag
            KhEngine.WriteInt(Warp.Address, 10);
            // Set last overworld map to the world we just left
            KhEngine.WriteInt(LastUsedOverworldMap.Address, CurrentWorld.WorldId);
            
            var currentWarpFlag = KhEngine.ReadInt(Warp.Address);
            if (currentWarpFlag == 10)
            {
                KhEngine.WriteInt(WarpRequirement1.Address, 6);
                KhEngine.WriteInt(WarpRequirement2.Address, 7);
            }

        }
    }
}