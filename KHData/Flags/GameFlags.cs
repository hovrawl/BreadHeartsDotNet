using KHData.Enums;

namespace KHData.Flags;


public enum GameFlags
{
    [Address(0x3A0606)]
    Offset,
    
    [Address(0x280EB1C)]
    HudOpen = 1,
    
    [Address(0x233CADC)]
    WorldId = 2,
    
    [Address(0x233CB44)]
    RoomId = 3,
    
    [Address(0x233CB48)]
    EventId = 4,
    
    [Address(0x233D034)]
    ButtonPress = 5,
    
    [Address(0x233D035)]
    ShoulderPress = 6,
    
    [Address(0x22E86E0)]
    WarpRequirement1 = 7,
    
    [Address(0x233C240)]
    WarpRequirement2 = 8,
    
    [Address(0x233CB68)]
    LastUsedOverworldMap = 9,
    
    [Address(0x22E86DC)]
    Warp = 10,
}