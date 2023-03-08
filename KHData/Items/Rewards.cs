using KHData.Enums;
using KHData.Flags;
using KHData.Worlds;

namespace KHData.Items;

public enum Rewards
{
    [Address(0x00)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Defeat Leon")]
    [CheckRequirements("Missable")]
    [CheckName("Elixir")]
    Elixir = 0x00,
    
    [Address(0x01)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("End of Traverse Town")]
    [CheckRequirements("Missable")]
    [CheckName("Dodge Roll")]
    DodgeRoll = 0x01,
}