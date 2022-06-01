using KHData.Enums;

namespace KHData.Flags;


public enum GameFlags
{
    [Address(0x3A0606)]
    Offset,
    
    [Address(0x246E516)]
    HudOpen = 1,
    
    [Address(0x1F9C4D6)]
    WorldId = 2,
    
    [Address(0x1F9C53E)]
    RoomId = 3,
    
    [Address(0x1F9C542)]
    EventId = 4,
    
    [Address(0x1F9CA2E)]
    ButtonPress = 5,
    
    [Address(0x1F9CA2F)]
    ShoulderPress = 6,
    
    [Address(0x1F480DA)]
    WarpRequirement1 = 7,
    
    [Address(0x1F9BC3A)]
    WarpRequirement2 = 8,
    
    [Address(0x1F9C562)]
    LastUsedOverworldMap = 9,
    
    [Address(0x1F480D6)]
    Warp = 10,
}