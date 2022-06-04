using System.Reflection;
using System.Xml.Schema;
using KHData.Enums;
using KHData.Flags;
using Memory;

namespace KHEngine.Modules;

public class SaveAnywhereModule: BaseModule
{
    private GameFlag GameState;
    private GameFlag DeathCheck;
    private GameFlag DeathSafetyMeasure;
    private GameFlag ButtonPress;
    private GameFlag SaveMenuOpen;
    private GameFlag CloseMenu;
    private GameFlag Continue;
    private GameFlag CameraBase;
    private GameFlag Config;
    private GameFlag WarpTrigger;
    private GameFlag WarpRequirement1;
    private GameFlag WarpRequirement2;
    private GameFlag Title;
    private GameFlag WhiteFade;
    private GameFlag SoraHud;
    private GameFlag SoraHp;
    private GameFlag BlackFade;
    private GameFlag DeathPointer;

    private string AutoSaveFileName = "autosave.dat";
    
    private int AddGummi = 0;
    private int WhiteScreen = 0;
    private bool RevertCode = false;
    private bool ExtraSafety = true;
    private int LastInput = 0;
    private int LastDeathPointer = 0;
    private float PrevHud = 0;
    
    public override string Name => "Save Anywhere";

    public override string Description => "Open the save menu anywhere via pressing Both Bumpers + Left Trigger + Select .";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;
        
        GameState = new GameFlag
        {
            FlagName = "Game State",
            Address = GameFlags.GameState.GetAddress()
        };
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
        CloseMenu = new GameFlag
        {
            FlagName = "Close Menu",
            Address = GameFlags.CloseMenu.GetAddress()
        };
        Continue = new GameFlag
        {
            FlagName = "Continue",
            Address = GameFlags.Continue.GetAddress()
        };
        CameraBase = new GameFlag
        {
            FlagName = "Camera Base",
            Address = GameFlags.CameraBase.GetAddress()
        };
        Config = new GameFlag
        {
            FlagName = "Config",
            Address = GameFlags.Config.GetAddress()
        };
        WarpTrigger = new GameFlag
        {
            FlagName = "Warp Trigger",
            Address = GameFlags.WarpTrigger.GetAddress()
        };
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
        Title = new GameFlag
        {
            FlagName = "Title",
            Address = GameFlags.Title.GetAddress()
        };
        WhiteFade = new GameFlag
        {
            FlagName = "White Fade",
            Address = GameFlags.WhiteFade.GetAddress()
        };
        SoraHud = new GameFlag
        {
            FlagName = "Sora Hud Visible",
            Address = GameFlags.SoraHud.GetAddress()
        };
        SoraHp = new GameFlag
        {
            FlagName = "Sora Hp",
            Address = GameFlags.SoraHp.GetAddress()
        };
        BlackFade = new GameFlag
        {
            FlagName = "Black Fade",
            Address = GameFlags.BlackFade.GetAddress()
        };
        DeathPointer = new GameFlag
        {
            FlagName = "Death Pointer",
            Address = GameFlags.DeathPointer.GetAddress()
        };
        ExtraSafety = true;
        
        var deathCheck = khEngine.ReadShort(DeathCheck.Address);
        if (deathCheck != 0x2E74)
        {
            // Run jp checks
            deathCheck = khEngine.ReadShort(DeathCheck.Address - 0x1C0);
            if (deathCheck == 0x2E74)
            {
                DeathCheck.Address = DeathCheck.Address - 0x1C0;
                DeathSafetyMeasure.Address = DeathSafetyMeasure.Address - 0x1C0;
                ExtraSafety = false;
            }
        }
        
        
        Initialised = true;

        
        
        return success;
    }

    
    
    public override void OnFrame()
    {

        var input = KhEngine.ReadInt(ButtonPress.Address);
        var saveMenuOpen = KhEngine.ReadInt(SaveMenuOpen.Address);
        var menuClose = KhEngine.ReadLong(CloseMenu.Address);
        var extra = KhEngine.ReadInt(0x2350CD4);
        var soraHud = KhEngine.ReadFloat(SoraHud.Address);
        var soraHp = KhEngine.ReadInt(SoraHp.Address);
        var blackFade = KhEngine.ReadByte(BlackFade.Address);
        var deathCheck = KhEngine.ReadShort(DeathCheck.Address);
        var deathPointer = KhEngine.ReadInt(DeathPointer.Address);
        
        
        if (input == 1793 && LastInput != 1793 && saveMenuOpen != 4 && extra == 0)
        {
            KhEngine.WriteByte(0x2350CD4, 0x1);
            AddGummi = 5;

        }else if (input == 1793 && LastInput != 1793)
        {
            KhEngine.WriteLong(CloseMenu.Address, 0);
        }

        if (input == 3968 && LastInput != 3968 && menuClose == 0)
        {
            // Instant death + continue
            InstantContinue();
        }
        
        if (input == 3872 && LastInput != 3872 && menuClose == 0)
        {
            // Read autosave
            var autosave = KhEngine.ReadFileText(AutoSaveFileName);
            if (!string.IsNullOrEmpty(autosave))
            { 
                // Set continue flag
                KhEngine.WriteString(Continue.Address, autosave);
                // Autosave should be loaded
                
                KhEngine.WriteLong(CloseMenu.Address, 1);
                InstantContinue();
                
                var config1 = KhEngine.ReadByte(Config.Address + 0x14);
                var config2 = KhEngine.ReadByte(Config.Address + 0x18);
                
                KhEngine.WriteFloat(CameraBase.Address, (float)(-1.0 + config1 * 2));
                KhEngine.WriteFloat(CameraBase.Address + 4, (float)(1.0 - config2 * 2));
            }
        }
        
        if (input == 3848 && LastInput != 3848)
        {
            // Soft Reset
            SoftReset();
        }
        
        // Remove white screen on death (it bugs out this way normally)
        if (WhiteScreen > 0)
        {
            WhiteScreen = 0;
            var whiteFade = KhEngine.ReadInt(WhiteFade.Address);
            if (whiteFade == 128)
            {
                KhEngine.WriteInt(WhiteFade.Address, 0);
            }
        }
        // // Reverts disabling death condition check (or it crashes)
        // if (RevertCode && deathPointer != LastDeathPointer)
        // {
        //     KhEngine.WriteShort(DeathCheck.Address, 0x2E74);
        //     if (ExtraSafety)
        //     {
        //         KhEngine.WriteLong(DeathSafetyMeasure.Address, 0x8902AB8973058948);
        //     }
        //
        //     WhiteScreen = 1000;
        //     RevertCode = false;
        // }
        
        // R1 R2 L2 Select
        // Sora HP to 0 (not necessary)
        // State to combat
        // Death condition check disable
        // if (input == 2817 && soraHud > 0 && soraHp > 0 && blackFade > 0 && deathCheck == 0x2E74)
        // {
        //     KhEngine.WriteInt(SoraHp.Address, 0);
        //     KhEngine.WriteInt(GameState.Address, 1);
        //     KhEngine.WriteShort(DeathCheck.Address, 0x9090);
        //     if (ExtraSafety)
        //     {
        //         KhEngine.WriteLong(DeathSafetyMeasure.Address, 0x89020B958735894C);
        //     }
        //     RevertCode = true;
        // }

        if (saveMenuOpen == 4 && AddGummi == 1)
        {
            KhEngine.WriteInt(0x2E1CC28, 3); // Unlock gummi
            KhEngine.WriteInt(0x2E1CB9C, 5); // Set 5 buttons to save menu
            KhEngine.WriteInt(0x2E8F450, 5); // Set 5 buttons to save menu
            KhEngine.WriteInt(0x2E8F452, 5); // Set 5 buttons to save menu
            for (int i = 0; i <= 4; i++)
            {
                KhEngine.WriteInt(0x2E1CBA0+i*4, i); // Set button types
            }
        }

        AddGummi = AddGummi > 0 ? AddGummi -= 1 : AddGummi;
        
        if (AddGummi > 0)
        {
            AddGummi -= 1;
        }

        LastDeathPointer = deathPointer;
        LastInput = input;

        if (soraHud == 1 && PrevHud < 1)
        {
            // If menu is open after not opening, run autosave
            var continueState = KhEngine.ReadString(Continue.Address, 0x16C00);
            KhEngine.WriteTextToFile(AutoSaveFileName, continueState);
        }

        PrevHud = soraHud;
    }

    private void InstantContinue()
    {
        var warpTrigger = KhEngine.ReadInt(WarpTrigger.Address);
        if (warpTrigger == 0)
        {
            KhEngine.WriteInt(WarpRequirement1.Address, 12);
            KhEngine.WriteInt(WarpRequirement2.Address, 5);
            KhEngine.WriteInt(WarpTrigger.Address, 2);
        }
    }

    private void SoftReset()
    {
        var title = KhEngine.ReadInt(Title.Address);
        KhEngine.WriteInt(WarpRequirement1.Address, 1);
        KhEngine.WriteInt(WarpRequirement2.Address, 3);

        if (title == 0)
        {
            KhEngine.WriteInt(Title.Address, 1);
        }
        
        KhEngine.WriteInt(WarpTrigger.Address, 2);
    }
}