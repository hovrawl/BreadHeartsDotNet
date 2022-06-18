using System.ComponentModel;
using KHData.Enums;

namespace KHData.Flags;


public enum GameFlags
{
    [Description("Game Process Offset")]
    [Address(0x3A0606)]
    Offset,
    
    [FlagType(FlagType.Int)]
    [Description("Game State")]
    [Address(0x2863958)]
    GameState,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Acceleration Flag")]
    [Address(0x3E7F58)]
    CameraAcceleration,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Deceleration Flag")]
    [Address(0x3E7F5C)]
    CameraDeceleration,
    
    [FlagType(FlagType.Float)]
    [Description("Current Vertical Camera Speed")]
    [Address(0x25344C0)]
    CameraCurrentSpeedV,
    
    [FlagType(FlagType.Float)]
    [Description("Current Horizontal Camera Speed")]
    [Address(0x25344C4)]
    CameraCurrentSpeedH,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Input Horizontal")]
    [Address(0x233D060)]
    CameraInputH,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Input Vertical")]
    [Address(0x233D064)]
    CameraInputV,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Center")]
    [Address(0x2534724)]
    CameraCenter,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Snap")]
    [Address(0x1DD299)]
    CameraSnap,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Acceleration Hack")]
    [Address(0x1E2924)]
    CameraAccelerationHack,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Deceleration Hack")]
    [Address(0x1E291B)]
    CameraDecelerationHack,
    
    [FlagType(FlagType.Float)]
    [Description("Camera Speed")]
    [Address(0x503A1C)]
    CameraSpeed,
    
    [FlagType(FlagType.Bool)]
    [Description("Is the Menu Open")]
    [Address(0x232A600)]
    MenuOpen,
    
    [FlagType(FlagType.Bool)]
    [Description("Sora HUD on screen")]
    [Address(0x280EB1C)]
    SoraHud,
    
    [FlagType(FlagType.Int)]
    [Description("World Id")]
    [Address(0x233CADC)]
    WorldId,
    
    [FlagType(FlagType.Int)]
    [Description("Room Id")]
    [Address(0x233CB44)]
    RoomId,
    
    [FlagType(FlagType.Int)]
    [Description("Event Id")]
    [Address(0x233CB48)]
    EventId,
    
    [FlagType(FlagType.Int)]
    [Description("Buttons Pressed Value")]
    [Address(0x233D034)]
    ButtonPress,
    
    [FlagType(FlagType.Int)]
    [Description("Shoulder Buttons Pressed Value")]
    [Address(0x233D035)]
    ShoulderPress,
    
    [FlagType(FlagType.Int)]
    [Description("Warp Requirement 1")]
    [Address(0x22E86E0)]
    WarpRequirement1,
    
    [FlagType(FlagType.Int)]
    [Description("Warp Requirement 2")]
    [Address(0x233C240)]
    WarpRequirement2,
    
    [FlagType(FlagType.Int)]
    [Description("Last Used Overworld Map")]
    [Address(0x233CB68)]
    LastUsedOverworldMap,
    
    [FlagType(FlagType.Int)]
    [Description("Warp Trigger")]
    [Address(0x22E86DC)]
    WarpTrigger,
    
    [FlagType(FlagType.Int)]
    [Description("Death Check")]
    [Address(0x2978E0)]
    DeathCheck,
    
    [FlagType(FlagType.Int)]
    [Description("Death Check Alternate(JP)")]
    [Address(0x2978E0 - 0x1C0)]
    DeathCheckAlternate,
    
    [FlagType(FlagType.Int)]
    [Description("Death Pointer")]
    [Address(0x23944B8)]
    DeathPointer,
    
    [FlagType(FlagType.Int)]
    [Description("Death Safety Measure")]
    [Address(0x297746)]
    DeathSafetyMeasure,
    
    [FlagType(FlagType.Int)]
    [Description("Death Safety Measure Alternate(JP)")]
    [Address(0x297746- 0x1C0)]
    DeathSafetyMeasureAlternate,
    
    [FlagType(FlagType.Bool)]
    [Description("Is the Save Menu Open")]
    [Address(0x232A604)]
    SaveMenuOpen,
    
    [Description("Close Menu")]
    [Address(0x2E90820)]
    CloseMenu,
    
    [Description("Continue Flag")]
    [Address(0x2DFC5D0)]
    Continue,
    
    [Description("Camera Base")]
    [Address(0x503A18)]
    CameraBase,
    
    [Description("Config Menu")]
    [Address(0x2DFBDD0)]
    Config,
    
    [Description("Title Screen")]
    [Address(0x233CAB8)]
    Title,
    
    [Description("White Fade")]
    [Address(0x233C49C)]
    WhiteFade,
    
    [Description("Black Fade")]
    [Address(0x4D93B8)]
    BlackFade,
    
    [FlagType(FlagType.Int)]
    [Description("Sora's HP")]
    [Address(0x2D592CC)]
    SoraHp,
    
    [FlagType(FlagType.Int)]
    [Description("World Selection")]
    [Address(0x503CEC)]
    WorldSelection,
    
    [FlagType(FlagType.Int)]
    [Description("World Warp Base")]
    [Address(0x50B940)]
    WorldWarpBase,
    
    [FlagType(FlagType.Int)]
    [Description("Cutscene Falg Base")]
    [Address(0x2DE65D0-0x200)]
    CutsceneFlagBase,
    
    [FlagType(FlagType.Int)]
    [Description("Deep Jungle Progress Flag")]
    [Address(0x2DE79D0+0x6C+0x40)]
    DjProgressFlag,
    
    [FlagType(FlagType.Int)]
    [Description("Neverlan Progress Flag")]
    [Address(0x2DE79D0+0x6C+0xED)]
    NeverlandProgressFlag,
    
    [FlagType(FlagType.Float)]
    [Description("Gravity Break Hack")]
    [Address(0x3EA148)]
    GravityBreakHack,
    
    [FlagType(FlagType.Byte)]
    [Description("Zantetsuken Hack")]
    [Address(0x2A2804 + 4)]
    ZantetsukenHack,
    
    [Description("Open Menu in Combat")]
    [Address(0x17A81A)]
    OpenMenuInCombat,
    
    [Description("Can Talk Requirement")]
    [Address(0x2903F9)]
    TalkRequirement,
    
    [Description("Open Chest Requirement")]
    [Address(0x2B12C4)]
    ChestOpenRequirement,
    
    [Description("Activate Trinity Requirement")]
    [Address(0x1A06CF)]
    TrinityRequirement,
    
    [Description("Can Examine Requirement")]
    [Address(0x2903B9)]
    ExamineRequirement,
    
    [Description("World Map Messages")]
    [Address(0x2DE78E9)]
    OverworldMessageFlag,
    
    [FlagType(FlagType.Int)]
    [Description("Is Cutscene Skippable")]
    [Address(0x23944E4)]
    CutsceneSkippable,
    
    [FlagType(FlagType.Int)]
    [Description("In Cutscene")]
    [Address(0x2378B60)]
    InCutscene,
    
    [FlagType(FlagType.Float)]
    [Description("Framerate Hack")]
    [Address(0x233C24C)]
    FramerateHack,
    
    [FlagType(FlagType.Int)]
    [Description("Summoning")]
    [Address(0x2D5D62C)]
    Summoning,
    
    [FlagType(FlagType.Int)]
    [Description("Text Box Progression")]
    [Address(0x232A5F4)]
    TextBoxProgression,
    
    [FlagType(FlagType.Float)]
    [Description("Text Box Transition")]
    [Address(0x232A5F4)]
    TextBoxTransition,
    
    [FlagType(FlagType.Float)]
    [Description("Text Box Speed")]
    [Address(0x233C25C)]
    TextBoxSpeed,
    
    
}