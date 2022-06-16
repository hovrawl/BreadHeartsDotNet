using System.ComponentModel;
using KHData.Enums;

namespace KHData.Flags;


public enum GameFlags
{
    [Description("Game Process Offset")]
    [Address(0x3A0606)]
    Offset,
    
    [Description("Game State")]
    [Address(0x2863958)]
    GameState,
    
    [Description("Camera Acceleration Flag")]
    [Address(0x3E7F58)]
    CameraAcceleration,
    
    [Description("Camera Deceleration Flag")]
    [Address(0x3E7F5C)]
    CameraDeceleration,
    
    [Description("Current Vertical Camera Speed")]
    [Address(0x25344C0)]
    CameraCurrentSpeedV,
    
    [Description("Current Horizontal Camera Speed")]
    [Address(0x25344C4)]
    CameraCurrentSpeedH,
    
    [Description("Camera Input Horizontal")]
    [Address(0x233D060)]
    CameraInputH,
    
    [Description("Camera Input Vertical")]
    [Address(0x233D064)]
    CameraInputV,
    
    [Description("Camera Center")]
    [Address(0x2534724)]
    CameraCenter,
    
    [Description("Camera Snap")]
    [Address(0x1DD299)]
    CameraSnap,
    
    [Description("Camera Acceleration Hack")]
    [Address(0x1E2924)]
    CameraAccelerationHack,
    
    [Description("Camera Deceleration Hack")]
    [Address(0x1E291B)]
    CameraDecelerationHack,
    
    [Description("Camera Speed")]
    [Address(0x503A1C)]
    CameraSpeed,
    
    [Description("Is the Menu Open")]
    [Address(0x232A600)]
    MenuOpen,
    
    [Description("Sora HUD on screen")]
    [Address(0x280EB1C)]
    SoraHud,
    
    [Description("World Id")]
    [Address(0x233CADC)]
    WorldId,
    
    [Description("Room Id")]
    [Address(0x233CB44)]
    RoomId,
    
    [Description("Event Id")]
    [Address(0x233CB48)]
    EventId,
    
    [Description("Buttons Pressed Value")]
    [Address(0x233D034)]
    ButtonPress,
    
    [Description("Shoulder Buttons Pressed Value")]
    [Address(0x233D035)]
    ShoulderPress,
    
    [Description("Warp Requirement 1")]
    [Address(0x22E86E0)]
    WarpRequirement1,
    
    [Description("Warp Requirement 2")]
    [Address(0x233C240)]
    WarpRequirement2,
    
    [Description("Last Used Overworld Map")]
    [Address(0x233CB68)]
    LastUsedOverworldMap,
    
    [Description("Warp Trigger")]
    [Address(0x22E86DC)]
    WarpTrigger,
    
    [Description("Death Check")]
    [Address(0x2978E0)]
    DeathCheck,
    
    [Description("Death Check Alternate(JP)")]
    [Address(0x2978E0 - 0x1C0)]
    DeathCheckAlternate,
    
    [Description("Death Pointer")]
    [Address(0x23944B8)]
    DeathPointer,
    
    [Description("Death Safety Measure")]
    [Address(0x297746)]
    DeathSafetyMeasure,
    
    [Description("Death Safety Measure Alternate(JP)")]
    [Address(0x297746- 0x1C0)]
    DeathSafetyMeasureAlternate,
    
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
    
    [Description("Sora's HP")]
    [Address(0x2D592CC)]
    SoraHp,
    
    [Description("World Warp Base")]
    [Address(0x50B940)]
    WorldWarpBase,
    
    [Description("Cutscene Falg Base")]
    [Address(0x2DE65D0-0x200)]
    CutsceneFlagBase,
    
    [Description("Deep Jungle Progress Flag")]
    [Address(0x2DE79D0+0x6C+0x40)]
    DjProgressFlag,
    
    [Description("Neverlan Progress Flag")]
    [Address(0x2DE79D0+0x6C+0xED)]
    NeverlandProgressFlag,
    
    [Description("Gravity Break Hack")]
    [Address(0x3EA148)]
    GravityBreakHack,
    
    [Description("Zantetsuken Hack")]
    [Address(0x2A2804)]
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
    
    [Description("Is Cutscene Skippable")]
    [Address(0x23944E4)]
    CutsceneSkippable,
}