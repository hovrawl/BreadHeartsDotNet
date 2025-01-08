using BreadFramework.Common;
using BreadFramework.Enums;
using BreadFramework.Flags;
using BreadFramework.Game;
using BreadRuntime.Settings;
using PluginBase;

namespace BreadRuntime.Modules;

public class SaveAnywherePlugin: BasePlugin
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
    
    public override KHGame Game => KHGame.KHFM;

    public override string Author => "Denhonator";
    
    public override string Name => "Save Anywhere";

    public override string Description => "Open the save menu anywhere via pressing Both Bumpers + Left Trigger + Select .";
    
    public override bool Initialise(EngineApi.EngineApi khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        GameState = KhEngine.GameFlagsRepo.GetFlag(GameFlags.GameState);
        DeathCheck = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DeathCheck);
        DeathSafetyMeasure = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DeathSafetyMeasure);
        ButtonPress = KhEngine.GameFlagsRepo.GetFlag(GameFlags.ButtonPress);
        SaveMenuOpen = KhEngine.GameFlagsRepo.GetFlag(GameFlags.SaveMenuOpen);
        CloseMenu = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CloseMenu);
        Continue = KhEngine.GameFlagsRepo.GetFlag(GameFlags.Continue);
        CameraBase = KhEngine.GameFlagsRepo.GetFlag(GameFlags.CameraBase);
        Config = KhEngine.GameFlagsRepo.GetFlag(GameFlags.Config);
        WarpTrigger = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpTrigger);
        WarpRequirement1 = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpRequirement1);
        WarpRequirement2 = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WarpRequirement2);
        Title = KhEngine.GameFlagsRepo.GetFlag(GameFlags.Title);
        WhiteFade = KhEngine.GameFlagsRepo.GetFlag(GameFlags.WhiteFade);
        SoraHud = KhEngine.GameFlagsRepo.GetFlag(GameFlags.SoraHud);
        SoraHp = KhEngine.GameFlagsRepo.GetFlag(GameFlags.SoraHp);
        BlackFade = KhEngine.GameFlagsRepo.GetFlag(GameFlags.BlackFade);
        DeathPointer = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DeathPointer);

       
        
        ExtraSafety = true;
        
        var deathCheck = khEngine.ReadShort(DeathCheck.Address);
        if (deathCheck != 0x2E74)
        {
            // Run jp checks
            deathCheck = khEngine.ReadShort(GameFlags.DeathCheckAlternate.GetAddress());
            if (deathCheck == 0x2E74)
            {
                DeathCheck = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DeathCheckAlternate);
                DeathSafetyMeasure = KhEngine.GameFlagsRepo.GetFlag(GameFlags.DeathSafetyMeasureAlternate);
                ExtraSafety = false;
            }
        }
        
        
        Initialised = success;

        
        
        return success;
    }

    public override List<ModuleSetting> GetSettings()
    {
        var settings = base.GetSettings();

        // Combinations enabled
        settings.Add(new ModuleSetting
        {
            Name = "Save Anywhere Enabled", 
            ValueAsString = "true"
        });
        settings.Add(new ModuleSetting
        {
            Name = "Soft Reset Enabled", 
            ValueAsString = "true"
        });
        settings.Add(new ModuleSetting
        {
            Name = "Reload AutoSave Enabled", 
            ValueAsString = "true"
        });
        settings.Add(new ModuleSetting
        {
            Name = "Instant Death Enabled", 
            ValueAsString = "true"
        });
        
        return settings;
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
        
        // if(input > 0) Console.WriteLine($"Controller input: {input}");
        var saveAnyWhereCombination = InputHelper.CombineInputs(ControllerInput.LeftBumper, ControllerInput.LeftTrigger,
            ControllerInput.RightTrigger, ControllerInput.SelectButton);
        var instantDeathContinueCombination = 3968;
        var reloadSaveCombination = 3872;
        var softResetCombination = InputHelper.CombineInputs(ControllerInput.LeftBumper, ControllerInput.RightBumper,
            ControllerInput.LeftTrigger, ControllerInput.RightTrigger, ControllerInput.StartButton);

        if (input == saveAnyWhereCombination && LastInput != saveAnyWhereCombination && saveMenuOpen != 4 && extra == 0)
        {
            KhEngine.WriteByte(0x2350CD4, 0x1);
            AddGummi = 5;
        }
        else if (input == saveAnyWhereCombination && LastInput != saveAnyWhereCombination)
        {
            KhEngine.WriteLong(CloseMenu.Address, 0);
        }

        if (input == instantDeathContinueCombination && LastInput != instantDeathContinueCombination && menuClose == 0)
        {
            // Instant death + continue
            InstantContinue();
        }
        
        if (input == reloadSaveCombination && LastInput != reloadSaveCombination && menuClose == 0)
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
        
        if (input == softResetCombination && LastInput != softResetCombination)
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