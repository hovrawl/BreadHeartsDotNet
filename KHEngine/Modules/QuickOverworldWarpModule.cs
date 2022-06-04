using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class QuickOverworldWarpModule: BaseModule
{
    private GameFlag WarpRequirement1;
    private GameFlag WarpRequirement2;
    private GameFlag LastUsedOverworldMap;
    private GameFlag Warp;
    private GameFlag ButtonPress;
    private GameFlag ShoulderPress;
    private WorldFlag CurrentWorld;

    private Engine.KHEngine Engine;

    public override string Name => "Quick Warp to Gummi Ship";

    public override string Description =>
        "Warp to Gummi Ship at any time by pressing both bumpers and both analog sticks.";

    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;

        WarpRequirement1 = new GameFlag
        {
            FlagName = "Warp Requirement 1",
            Address = GameFlags.WarpRequirement1.GetAddress()
        };
        WarpRequirement2 = new GameFlag
        {
            FlagName = "Warp Requirement 2",
            Address = GameFlags.WarpRequirement2.GetAddress()
        };
        LastUsedOverworldMap = new GameFlag
        {
            FlagName = "Last Used Overworld Map",
            Address = GameFlags.LastUsedOverworldMap.GetAddress()
        };
        ButtonPress = new GameFlag
        {
            FlagName = "Button Pressed",
            Address = GameFlags.ButtonPress.GetAddress()
        };
        ShoulderPress = new GameFlag
        {
            FlagName = "Shoulder Pressed",
            Address = GameFlags.ShoulderPress.GetAddress()
        };
        Warp = new GameFlag
        {
            FlagName = "Warp",
            Address = GameFlags.WarpTrigger.GetAddress()
        };

        Engine = KhEngine;
        // Get current world
        
        return success;
    }

    public override void OnFrame()
    {
        var buttonPress = Engine.ReadInt(ButtonPress.Address);
        var shoulderPress = Engine.ReadInt(ShoulderPress.Address);
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
            Engine.WriteInt(Warp.Address, 10);
            // Set last overworld map to the world we just left
            Engine.WriteInt(LastUsedOverworldMap.Address, CurrentWorld.Address);
            
            var currentWarpFlag = Engine.ReadInt(Warp.Address);
            if (currentWarpFlag == 10)
            {
                Engine.WriteInt(WarpRequirement1.Address, 6);
                Engine.WriteInt(WarpRequirement2.Address, 7);
            }

        }
    }
}