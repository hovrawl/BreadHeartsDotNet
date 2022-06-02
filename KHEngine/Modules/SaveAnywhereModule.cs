using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class SaveAnywhereModule: BaseModule
{
    private GameFlag DeathCheck;
    private GameFlag DeathSafetyMeasure;
    private GameFlag ButtonPress;
    private GameFlag SaveMenuOpen;

    public override string Name => "Save Anywhere";

    public override string Description => "Open the save menu anywhere via pressing Both Bumpers + Left Trigger + Select .";
    private bool ExtraSafety = true;
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;
        
        DeathCheck = new GameFlag
        {
            FlagName = "Death Check",
            Address = GameFlags.DeathCheck.GetAddress()
        };
        DeathSafetyMeasure = new GameFlag
        {
            FlagName = "Death Safety Measure",
            Address = GameFlags.DeathSafetyMeasure.GetAddress()
        };
        ButtonPress = new GameFlag
        {
            FlagName = "Button Pressed",
            Address = GameFlags.ButtonPress.GetAddress()
        };
        SaveMenuOpen = new GameFlag
        {
            FlagName = "Save Menu Open",
            Address = GameFlags.SaveMenuOpen.GetAddress()
        };
        
        ExtraSafety = true;
        
        var deathCheck = khEngine.ReadInt(DeathCheck.Address);
        if (deathCheck != 0x2E74)
        {
            deathCheck = khEngine.ReadInt(DeathCheck.Address - 0x1C0);
        }
        
        if (deathCheck == 0x2E74)
        {
            DeathCheck.Address = DeathCheck.Address - 0x1C0;
            DeathSafetyMeasure.Address = DeathSafetyMeasure.Address - 0x1C0;
            ExtraSafety = false;
        }
       
        return success;
    }

    private int LastInput = 0;
    
    public override void OnFrame()
    {

        var input = KhEngine.ReadInt(ButtonPress.Address);
        var savemenuopen = KhEngine.ReadInt(SaveMenuOpen.Address);
        var extra = KhEngine.ReadInt(0x2350CD4);

        if (input == 1793 && LastInput != 1793 && savemenuopen != 4 && extra == 0)
        {
            
        }



        LastInput = input;
    }
}