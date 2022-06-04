using KHData.Enums;

namespace KHData.Flags;


public enum GameFlags
{
    [Address(0x3A0606)]
    Offset,
    
    [Address(0x2863958)]
    GameState,
    
    [Address(0x3E7F58)]
    CameraAcceleration,
    
    [Address(0x3E7F5C)]
    CameraDeceleration,
    
    [Address(0x25344C0)]
    CameraCurrentSpeedV,
    
    [Address(0x25344C4)]
    CameraCurrentSpeedH,
    
    [Address(0x233D060)]
    CameraInputH,
    
    [Address(0x233D064)]
    CameraInputV,
    
    [Address(0x2534724)]
    CameraCenter,
    
    [Address(0x1DD299)]
    CameraSnap,
    [Address(0x1E2924)]
    CameraAccellerationHack,
    [Address(0x1E291B)]
    CameraDecellertaionHack,
    [Address(0x503A1C)]
    CameraSpeed,
    [Address(0x232A600)]
    MenuOpen,
    
    [Address(0x280EB1C)]
    SoraHud,
    
    [Address(0x233CADC)]
    WorldId,
    
    [Address(0x233CB44)]
    RoomId,
    
    [Address(0x233CB48)]
    EventId,
    
    [Address(0x233D034)]
    ButtonPress,
    
    [Address(0x233D035)]
    ShoulderPress,
    
    [Address(0x22E86E0)]
    WarpRequirement1,
    
    [Address(0x233C240)]
    WarpRequirement2,
    
    [Address(0x233CB68)]
    LastUsedOverworldMap,
    
    [Address(0x22E86DC)]
    WarpTrigger,
    
    [Address(0x2978E0)]
    DeathCheck,
    
    [Address(0x23944B8)]
    DeathPointer,
    
    [Address(0x297746)]
    DeathSafetyMeasure,
    
    [Address(0x232A604)]
    SaveMenuOpen,
    
    [Address(0x2E90820)]
    CloseMenu,
    
    [Address(0x2DFC5D0)]
    Continue,
    
    [Address(0x503A18)]
    CameraBase,
    
    [Address(0x2DFBDD0)]
    Config,
    
    [Address(0x233CAB8)]
    Title,
    
    [Address(0x233C49C)]
    WhiteFade,
    
    [Address(0x4D93B8)]
    BlackFade,
    
    [Address(0x2D592CC)]
    SoraHp,
    
    [Address(0x50B940)]
    WorldWarpBase,
    
    [Address(0x2DE65D0-0x200)]
    CutsceneFlagBase,
    
    [Address(0x2DE79D0+0x6C+0x40)]
    DJProgressFlag,
    
    [Address(0x2DE79D0+0x6C+0xED)]
    NeverlandProgressFlag,
}