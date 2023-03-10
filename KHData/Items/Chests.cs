
using KHData.Enums;
using KHData.Worlds;

namespace KHData.Items;

public enum Chests 
{        

    [Address(0x0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 66")]
    Reward66 = 0x0,

    [Address(0x1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion = 0x1,

    [Address(0x2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether = 0x2,

    [Address(0x3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether3 = 0x3,

    [Address(0x4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4 = 0x4,

    [Address(0x5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion5 = 0x5,

    [Address(0x6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether6 = 0x6,

    [Address(0x7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether7 = 0x7,

    [Address(0x8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion8 = 0x8,

    [Address(0x9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9 = 0x9,

    [Address(0xA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    EtherA = 0xA,

    [Address(0xB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    EtherB = 0xB,

    [Address(0xC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC = 0xC,

    [Address(0xD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionD = 0xD,

    [Address(0xE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    EtherE = 0xE,

    [Address(0xF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    EtherF = 0xF,

    [Address(0x10)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10 = 0x10,

    [Address(0x11)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11 = 0x11,

    [Address(0x12)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion12 = 0x12,

    [Address(0x13)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion13 = 0x13,

    [Address(0x14)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("1st District")]
    [CheckRequirements(" Blizzard Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 3f")]
    Reward3f = 0x14,

    [Address(0x15)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("1st District")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Postcard)]
    [CheckName("Postcard")]
    Postcard = 0x15,

    [Address(0x16)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("2nd District")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Postcard)]
    [CheckName("Postcard")]
    Postcard16 = 0x16,

    [Address(0x17)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("2nd District")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard = 0x17,

    [Address(0x18)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("2nd District")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion = 0x18,

    [Address(0x19)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Alleyway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion19 = 0x19,

    [Address(0x1A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Alleyway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.PrettyStone)]
    [CheckName("Pretty Stone")]
    PrettyStone = 0x1A,

    [Address(0x1B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Alleyway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1B = 0x1B,

    [Address(0x1C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion1C = 0x1C,

    [Address(0x1D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Green Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril = 0x1D,

    [Address(0x1E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Green Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 40")]
    Reward40 = 0x1E,

    [Address(0x1F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Red Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.PrettyStone)]
    [CheckName("Pretty Stone")]
    PrettyStone1F = 0x1F,

    [Address(0x20)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Mystical House")]
    [CheckRequirements(" Fire Magic ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 41")]
    Reward41 = 0x20,

    [Address(0x21)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Accessory Shop")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard21 = 0x21,

    [Address(0x22)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Secret Waterway")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 42")]
    Reward42 = 0x22,

    [Address(0x23)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Gepetto's House")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 33")]
    Reward33 = 0x23,

    [Address(0x24)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard24 = 0x24,

    [Address(0x25)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion25 = 0x25,

    [Address(0x26)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion26 = 0x26,

    [Address(0x27)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion27 = 0x27,

    [Address(0x28)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("1st District")]
    [CheckRequirements(" Blue Trinity OR Glide")]
    [CheckItem(ItemList.Postcard)]
    [CheckName("Postcard")]
    Postcard28 = 0x28,

    [Address(0x29)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion29 = 0x29,

    [Address(0x2A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2A = 0x2A,

    [Address(0x2B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2B = 0x2B,

    [Address(0x2C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2C = 0x2C,

    [Address(0x2D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2D = 0x2D,

    [Address(0x2E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2E = 0x2E,

    [Address(0x2F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion2F = 0x2F,

    [Address(0x30)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion30 = 0x30,

    [Address(0x31)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion31 = 0x31,

    [Address(0x32)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion32 = 0x32,

    [Address(0x33)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion33 = 0x33,

    [Address(0x34)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion34 = 0x34,

    [Address(0x35)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion35 = 0x35,

    [Address(0x36)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion36 = 0x36,

    [Address(0x37)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion37 = 0x37,

    [Address(0x38)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion38 = 0x38,

    [Address(0x39)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion39 = 0x39,

    [Address(0x3A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3A = 0x3A,

    [Address(0x3B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3B = 0x3B,

    [Address(0x3C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3C = 0x3C,

    [Address(0x3D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3D = 0x3D,

    [Address(0x3E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3E = 0x3E,

    [Address(0x3F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion3F = 0x3F,

    [Address(0x40)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion40 = 0x40,

    [Address(0x41)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion41 = 0x41,

    [Address(0x42)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion42 = 0x42,

    [Address(0x43)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion43 = 0x43,

    [Address(0x44)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion44 = 0x44,

    [Address(0x45)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion45 = 0x45,

    [Address(0x46)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion46 = 0x46,

    [Address(0x47)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion47 = 0x47,

    [Address(0x48)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion48 = 0x48,

    [Address(0x49)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion49 = 0x49,

    [Address(0x4A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4A = 0x4A,

    [Address(0x4B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4B = 0x4B,

    [Address(0x4C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4C = 0x4C,

    [Address(0x4D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4D = 0x4D,

    [Address(0x4E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4E = 0x4E,

    [Address(0x4F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion4F = 0x4F,

    [Address(0x50)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion50 = 0x50,

    [Address(0x51)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion51 = 0x51,

    [Address(0x52)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion52 = 0x52,

    [Address(0x53)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion53 = 0x53,

    [Address(0x54)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion54 = 0x54,

    [Address(0x55)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion55 = 0x55,

    [Address(0x56)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion56 = 0x56,

    [Address(0x57)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion57 = 0x57,

    [Address(0x58)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Mystical House")]
    [CheckRequirements(" Glide ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 1")]
    Dalmatians1 = 0x58,

    [Address(0x59)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Alleyway")]
    [CheckRequirements(" Red Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 2")]
    Dalmatians2 = 0x59,

    [Address(0x5A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Item Workshop")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 3")]
    Dalmatians3 = 0x5A,

    [Address(0x5B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Secret Waterway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 4")]
    Dalmatians4 = 0x5B,

    [Address(0x5C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rabbit hole")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 74")]
    Reward74 = 0x5C,

    [Address(0x5D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rabbit hole")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 43")]
    Reward43 = 0x5D,

    [Address(0x5E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rabbit hole")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 44")]
    Reward44 = 0x5E,

    [Address(0x5F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rabbit hole")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 45")]
    Reward45 = 0x5F,

    [Address(0x60)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bizarre Room")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 46")]
    Reward46 = 0x60,

    [Address(0x61)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion61 = 0x61,

    [Address(0x62)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion62 = 0x62,

    [Address(0x63)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion63 = 0x63,

    [Address(0x64)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Queen's Castle")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraG = 0x64,

    [Address(0x65)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Queen's Castle")]
    [CheckRequirements(" Evidence OR High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 5")]
    Dalmatians5 = 0x65,

    [Address(0x66)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Queen's Castle")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorG = 0x66,

    [Address(0x67)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements(" Thunder Magic ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraG67 = 0x67,

    [Address(0x68)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements(" Thunder Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 20")]
    Dalmatians20 = 0x68,

    [Address(0x69)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements(" Glide OR High Jump")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 47")]
    Reward47 = 0x69,

    [Address(0x6A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 6")]
    Dalmatians6 = 0x6A,

    [Address(0x6B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Scan-G")]
    ScanG = 0x6B,

    [Address(0x6C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bizarre Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp = 0x6C,

    [Address(0x6D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion6D = 0x6D,

    [Address(0x6E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tea Party Garden")]
    [CheckRequirements(" Glide OR High Jump ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Flare-G")]
    FlareG = 0x6E,

    [Address(0x6F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tea Party Garden")]
    [CheckRequirements(" Glide OR High Jump ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 7")]
    Dalmatians7 = 0x6F,

    [Address(0x70)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tea Party Garden")]
    [CheckRequirements(" Evidence OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 99")]
    Reward99 = 0x70,

    [Address(0x71)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tea Party Garden")]
    [CheckRequirements(" Glide OR High Jumpra ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 32")]
    Reward32 = 0x71,

    [Address(0x72)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lotus Forest")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 48")]
    Reward48 = 0x72,

    [Address(0x73)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion73 = 0x73,

    [Address(0x74)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion74 = 0x74,

    [Address(0x75)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion75 = 0x75,

    [Address(0x76)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion76 = 0x76,

    [Address(0x77)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion77 = 0x77,

    [Address(0x78)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion78 = 0x78,

    [Address(0x79)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion79 = 0x79,

    [Address(0x7A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tree House")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 49")]
    Reward49 = 0x7A,

    [Address(0x7B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tree House")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4a")]
    Reward4a = 0x7B,

    [Address(0x7C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hippos' Lagoon")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 9")]
    Dalmatians9 = 0x7C,

    [Address(0x7D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hippos' Lagoon")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion7D = 0x7D,

    [Address(0x7E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hippos' Lagoon")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorG7E = 0x7E,

    [Address(0x7F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether7F = 0x7F,

    [Address(0x80)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle: Vines")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril80 = 0x80,

    [Address(0x81)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle: Vines 2")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 10")]
    Dalmatians10 = 0x81,

    [Address(0x82)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Climbing Trees")]
    [CheckRequirements(" Blue Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraG82 = 0x82,

    [Address(0x83)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion83 = 0x83,

    [Address(0x84)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle: Tunnel")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEther = 0x84,

    [Address(0x85)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cavern of Hearts")]
    [CheckRequirements(" White Trinity ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4b")]
    Reward4b = 0x85,

    [Address(0x86)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Camp")]
    [CheckRequirements(" Blue Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 12")]
    Dalmatians12 = 0x86,

    [Address(0x87)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Camp: Tent")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard87 = 0x87,

    [Address(0x88)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterfall Cavern")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard88 = 0x88,

    [Address(0x89)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterfall Cavern")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 11")]
    Dalmatians11 = 0x89,

    [Address(0x8A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterfall Cavern")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril8A = 0x8A,

    [Address(0x8B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterfall Cavern")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum = 0x8B,

    [Address(0x8C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle: Cliff")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 72")]
    Reward72 = 0x8C,

    [Address(0x8D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle: Cliff")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 73")]
    Reward73 = 0x8D,

    [Address(0x8E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Tree House")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 75")]
    Reward75 = 0x8E,

    [Address(0x8F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion8F = 0x8F,

    [Address(0x90)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion90 = 0x90,

    [Address(0x91)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion91 = 0x91,

    [Address(0x92)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion92 = 0x92,

    [Address(0x93)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion93 = 0x93,

    [Address(0x94)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion94 = 0x94,

    [Address(0x95)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion95 = 0x95,

    [Address(0x96)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion96 = 0x96,

    [Address(0x97)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion97 = 0x97,

    [Address(0x98)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion98 = 0x98,

    [Address(0x99)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion99 = 0x99,

    [Address(0x9A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9A = 0x9A,

    [Address(0x9B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9B = 0x9B,

    [Address(0x9C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9C = 0x9C,

    [Address(0x9D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9D = 0x9D,

    [Address(0x9E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9E = 0x9E,

    [Address(0x9F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion9F = 0x9F,

    [Address(0xA0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA0 = 0xA0,

    [Address(0xA1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA1 = 0xA1,

    [Address(0xA2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA2 = 0xA2,

    [Address(0xA3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA3 = 0xA3,

    [Address(0xA4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA4 = 0xA4,

    [Address(0xA5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA5 = 0xA5,

    [Address(0xA6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionA6 = 0xA6,

    [Address(0xA7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Woods")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShardA7 = 0xA7,

    [Address(0xA8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Woods")]
    [CheckRequirements(" Page3")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4c")]
    Reward4c = 0xA8,

    [Address(0xA9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Woods")]
    [CheckRequirements(" Page3")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9b")]
    Reward9b = 0xA9,

    [Address(0xAA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Woods")]
    [CheckRequirements(" Page3")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4d")]
    Reward4d = 0xAA,

    [Address(0xAB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionAB = 0xAB,

    [Address(0xAC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionAC = 0xAC,

    [Address(0xAD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionAD = 0xAD,

    [Address(0xAE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionAE = 0xAE,

    [Address(0xAF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionAF = 0xAF,

    [Address(0xB0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB0 = 0xB0,

    [Address(0xB1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB1 = 0xB1,

    [Address(0xB2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB2 = 0xB2,

    [Address(0xB3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB3 = 0xB3,

    [Address(0xB4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB4 = 0xB4,

    [Address(0xB5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB5 = 0xB5,

    [Address(0xB6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB6 = 0xB6,

    [Address(0xB7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB7 = 0xB7,

    [Address(0xB8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB8 = 0xB8,

    [Address(0xB9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionB9 = 0xB9,

    [Address(0xBA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBA = 0xBA,

    [Address(0xBB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBB = 0xBB,

    [Address(0xBC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBC = 0xBC,

    [Address(0xBD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBD = 0xBD,

    [Address(0xBE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBE = 0xBE,

    [Address(0xBF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionBF = 0xBF,

    [Address(0xC0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC0 = 0xC0,

    [Address(0xC1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC1 = 0xC1,

    [Address(0xC2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC2 = 0xC2,

    [Address(0xC3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC3 = 0xC3,

    [Address(0xC4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionC4 = 0xC4,

    [Address(0xC5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Plaza")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotionC5 = 0xC5,

    [Address(0xC6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Plaza")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEtherC6 = 0xC6,

    [Address(0xC7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Plaza")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4e")]
    Reward4e = 0xC7,

    [Address(0xC8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Alley")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotionC8 = 0xC8,

    [Address(0xC9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Bazaar")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraGC9 = 0xC9,

    [Address(0xCA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Bazaar")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 4f")]
    Reward4f = 0xCA,

    [Address(0xCB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Main Street")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEtherCB = 0xCB,

    [Address(0xCC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Main Street")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9c")]
    Reward9c = 0xCC,

    [Address(0xCD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Main Street")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 50")]
    Reward50 = 0xCD,

    [Address(0xCE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Palace Gates")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 76")]
    Reward76 = 0xCE,

    [Address(0xCF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Palace Gates")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 18")]
    Dalmatians18 = 0xCF,

    [Address(0xD0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Palace Gates")]
    [CheckRequirements(" Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Osmose-G")]
    OsmoseG = 0xD0,

    [Address(0xD1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Storage")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 51")]
    Reward51 = 0xD1,

    [Address(0xD2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah: Storage")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotionD2 = 0xD2,

    [Address(0xD3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cave: Entrance")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEtherD3 = 0xD3,

    [Address(0xD4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cave: Entrance")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 17")]
    Dalmatians17 = 0xD4,

    [Address(0xD5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cave: Hall")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir = 0xD5,

    [Address(0xD6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cave: Hall")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShardD6 = 0xD6,

    [Address(0xD7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bottomless Hall")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage = 0xD7,

    [Address(0xD8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bottomless Hall")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 52")]
    Reward52 = 0xD8,

    [Address(0xD9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bottomless Hall")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 53")]
    Reward53 = 0xD9,

    [Address(0xDA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Treasure Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 13")]
    Dalmatians13 = 0xDA,

    [Address(0xDB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Treasure Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShardDB = 0xDB,

    [Address(0xDC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Treasure Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraGDC = 0xDC,

    [Address(0xDD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Treasure Room")]
    [CheckRequirements("")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUpDD = 0xDD,

    [Address(0xDE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Relic Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    MythrilDE = 0xDE,

    [Address(0xDF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Relic Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 77")]
    Reward77 = 0xDF,

    [Address(0xE0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dark Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 54")]
    Reward54 = 0xE0,

    [Address(0xE1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dark Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorGE1 = 0xE1,

    [Address(0xE2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dark Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.TornPage3)]
    [CheckName("Torn Page 3")]
    TornPage3 = 0xE2,

    [Address(0xE3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dark Chamber")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    CottageE3 = 0xE3,

    [Address(0xE4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Silent Chamber")]
    [CheckRequirements(" Blue Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraGE4 = 0xE4,

    [Address(0xE5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hidden Room")]
    [CheckRequirements(" Yellow Trinity OR High Jump")]
    [CheckItem(ItemList.A41)]
    [CheckName("Haste2-G")]
    Haste2G = 0xE5,

    [Address(0xE6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hidden Room")]
    [CheckRequirements(" Yellow Trinity OR High Jump")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 16")]
    Dalmatians16 = 0xE6,

    [Address(0xE7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Aladdin's House")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Scissors-G")]
    ScissorsG = 0xE7,

    [Address(0xE8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Aladdin's House")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir = 0xE8,

    [Address(0xE9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cave: Entrance")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9d")]
    Reward9d = 0xE9,

    [Address(0xEA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionEA = 0xEA,

    [Address(0xEB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionEB = 0xEB,

    [Address(0xEC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionEC = 0xEC,

    [Address(0xED)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionED = 0xED,

    [Address(0xEE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionEE = 0xEE,

    [Address(0xEF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionEF = 0xEF,

    [Address(0xF0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF0 = 0xF0,

    [Address(0xF1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF1 = 0xF1,

    [Address(0xF2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 6")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    MegalixirF2 = 0xF2,

    [Address(0xF3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 6")]
    [CheckRequirements("")]
    [CheckItem(ItemList.TornPage2)]
    [CheckName("Torn Page 2")]
    TornPage2 = 0xF3,

    [Address(0xF4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 6")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 29")]
    Reward29 = 0xF4,

    [Address(0xF5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 6")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 26")]
    Dalmatians26 = 0xF5,

    [Address(0xF6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF6 = 0xF6,

    [Address(0xF7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF7 = 0xF7,

    [Address(0xF8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF8 = 0xF8,

    [Address(0xF9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionF9 = 0xF9,

    [Address(0xFA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFA = 0xFA,

    [Address(0xFB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFB = 0xFB,

    [Address(0xFC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFC = 0xFC,

    [Address(0xFD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFD = 0xFD,

    [Address(0xFE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFE = 0xFE,

    [Address(0xFF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    PotionFF = 0xFF,

    [Address(0x100)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion100 = 0x100,

    [Address(0x101)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion101 = 0x101,

    [Address(0x102)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion102 = 0x102,

    [Address(0x103)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion103 = 0x103,

    [Address(0x104)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion104 = 0x104,

    [Address(0x105)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion105 = 0x105,

    [Address(0x106)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion106 = 0x106,

    [Address(0x107)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion107 = 0x107,

    [Address(0x108)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion108 = 0x108,

    [Address(0x109)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion109 = 0x109,

    [Address(0x10A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10A = 0x10A,

    [Address(0x10B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10B = 0x10B,

    [Address(0x10C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10C = 0x10C,

    [Address(0x10D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10D = 0x10D,

    [Address(0x10E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10E = 0x10E,

    [Address(0x10F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion10F = 0x10F,

    [Address(0x110)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion110 = 0x110,

    [Address(0x111)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion111 = 0x111,

    [Address(0x112)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion112 = 0x112,

    [Address(0x113)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion113 = 0x113,

    [Address(0x114)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion114 = 0x114,

    [Address(0x115)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion115 = 0x115,

    [Address(0x116)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion116 = 0x116,

    [Address(0x117)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion117 = 0x117,

    [Address(0x118)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion118 = 0x118,

    [Address(0x119)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion119 = 0x119,

    [Address(0x11A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11A = 0x11A,

    [Address(0x11B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11B = 0x11B,

    [Address(0x11C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11C = 0x11C,

    [Address(0x11D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11D = 0x11D,

    [Address(0x11E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11E = 0x11E,

    [Address(0x11F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion11F = 0x11F,

    [Address(0x120)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion120 = 0x120,

    [Address(0x121)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion121 = 0x121,

    [Address(0x122)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion122 = 0x122,

    [Address(0x123)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion123 = 0x123,

    [Address(0x124)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion124 = 0x124,

    [Address(0x125)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion125 = 0x125,

    [Address(0x126)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion126 = 0x126,

    [Address(0x127)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion127 = 0x127,

    [Address(0x128)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion128 = 0x128,

    [Address(0x129)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion129 = 0x129,

    [Address(0x12A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion12A = 0x12A,

    [Address(0x12B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion12B = 0x12B,

    [Address(0x12C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion12C = 0x12C,

    [Address(0x12D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion12D = 0x12D,

    [Address(0x12E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion12E = 0x12E,

    [Address(0x12F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Moonlight Hill")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 23")]
    Dalmatians23 = 0x12F,

    [Address(0x130)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bridge")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Fira-G")]
    FiraG = 0x130,

    [Address(0x131)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Boneyard")]
    [CheckRequirements("")]
    [CheckItem(ItemList.JackInTheBox)]
    [CheckName("Jack-In-The-Box")]
    JackInTheBox = 0x131,

    [Address(0x132)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bridge")]
    [CheckRequirements(" High Jump OR Glide ")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp132 = 0x132,

    [Address(0x133)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cemetery")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a0")]
    Rewarda0 = 0x133,

    [Address(0x134)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cemetery")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 22")]
    Dalmatians22 = 0x134,

    [Address(0x135)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cemetery")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Gummi")]
    Gummi = 0x135,

    [Address(0x136)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9f")]
    Reward9f = 0x136,

    [Address(0x137)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEther137 = 0x137,

    [Address(0x138)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 14")]
    Dalmatians14 = 0x138,

    [Address(0x139)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Red Trinity ")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard139 = 0x139,

    [Address(0x13A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Guillotine Square")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.PowerUp)]
    [CheckName("Power Up")]
    PowerUp = 0x13A,

    [Address(0x13B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Guillotine Square")]
    [CheckRequirements(" Glide")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir13B = 0x13B,

    [Address(0x13C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether13C = 0x13C,

    [Address(0x13D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Manor")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.Ether)]
    [CheckName("Ether")]
    Ether13D = 0x13D,

    [Address(0x13E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion13E = 0x13E,

    [Address(0x13F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion13F = 0x13F,

    [Address(0x140)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion140 = 0x140,

    [Address(0x141)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion141 = 0x141,

    [Address(0x142)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion142 = 0x142,

    [Address(0x143)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion143 = 0x143,

    [Address(0x144)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion144 = 0x144,

    [Address(0x145)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion145 = 0x145,

    [Address(0x146)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion146 = 0x146,

    [Address(0x147)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion147 = 0x147,

    [Address(0x148)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Bridge")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorG148 = 0x148,

    [Address(0x149)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cemetery")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Holy-G")]
    HolyG = 0x149,

    [Address(0x14A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Guillotine Square")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraG14A = 0x14A,

    [Address(0x14B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Guillotine Square")]
    [CheckRequirements(" Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 24")]
    Dalmatians24 = 0x14B,

    [Address(0x14C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion14C = 0x14C,

    [Address(0x14D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion14D = 0x14D,

    [Address(0x14E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements(" Blue Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 8")]
    Dalmatians8 = 0x14E,

    [Address(0x14F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements(" Blue Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 55")]
    Reward55 = 0x14F,

    [Address(0x150)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 56")]
    Reward56 = 0x150,

    [Address(0x151)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements(" Blizzara Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Gummi")]
    Gummi151 = 0x151,

    [Address(0x152)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Coliseum Gates")]
    [CheckRequirements(" Blizzaga Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9a")]
    Reward9a = 0x152,

    [Address(0x153)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion153 = 0x153,

    [Address(0x154)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion154 = 0x154,

    [Address(0x155)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion155 = 0x155,

    [Address(0x156)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion156 = 0x156,

    [Address(0x157)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion157 = 0x157,

    [Address(0x158)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion158 = 0x158,

    [Address(0x159)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion159 = 0x159,

    [Address(0x15A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion15A = 0x15A,

    [Address(0x15B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 27")]
    Reward27 = 0x15B,

    [Address(0x15C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage15C = 0x15C,

    [Address(0x15D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 25")]
    Dalmatians25 = 0x15D,

    [Address(0x15E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Scan-G")]
    ScanG15E = 0x15E,

    [Address(0x15F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements(" High Jump OR Glide ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 57")]
    Reward57 = 0x15F,

    [Address(0x160)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion160 = 0x160,

    [Address(0x161)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion161 = 0x161,

    [Address(0x162)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion162 = 0x162,

    [Address(0x163)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 2")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage163 = 0x163,

    [Address(0x164)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 2")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir164 = 0x164,

    [Address(0x165)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion165 = 0x165,

    [Address(0x166)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion166 = 0x166,

    [Address(0x167)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion167 = 0x167,

    [Address(0x168)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion168 = 0x168,

    [Address(0x169)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion169 = 0x169,

    [Address(0x16A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 5")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril16A = 0x16A,

    [Address(0x16B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 3")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEther16B = 0x16B,

    [Address(0x16C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 3")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 19")]
    Dalmatians19 = 0x16C,

    [Address(0x16D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 3")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Osmose-G")]
    OsmoseG16D = 0x16D,

    [Address(0x16E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 3")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Flare-G")]
    FlareG16E = 0x16E,

    [Address(0x16F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion16F = 0x16F,

    [Address(0x170)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion170 = 0x170,

    [Address(0x171)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion171 = 0x171,

    [Address(0x172)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion172 = 0x172,

    [Address(0x173)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion173 = 0x173,

    [Address(0x174)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion174 = 0x174,

    [Address(0x175)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Monstro: Mouth")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 28")]
    Reward28 = 0x175,

    [Address(0x176)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 5")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 27")]
    Dalmatians27 = 0x176,

    [Address(0x177)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 5")]
    [CheckRequirements("")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEther177 = 0x177,

    [Address(0x178)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 5")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundaga-G")]
    ThundagaG = 0x178,

    [Address(0x179)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pirate Ship")]
    [CheckRequirements(" White Trinity ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 15")]
    Dalmatians15 = 0x179,

    [Address(0x17A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pirate Ship")]
    [CheckRequirements(" Green Trinity ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a2")]
    Rewarda2 = 0x17A,

    [Address(0x17B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Hold")]
    [CheckRequirements(" Yellow Trinity")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum17B = 0x17B,

    [Address(0x17C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Hold")]
    [CheckRequirements(" Yellow Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a1")]
    Rewarda1 = 0x17C,

    [Address(0x17D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Galley")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorG17D = 0x17D,

    [Address(0x17E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Cabin")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 78")]
    Reward78 = 0x17E,

    [Address(0x17F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Hold")]
    [CheckRequirements(" Glide ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 28")]
    Dalmatians28 = 0x17F,

    [Address(0x180)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion180 = 0x180,

    [Address(0x181)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion181 = 0x181,

    [Address(0x182)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion182 = 0x182,

    [Address(0x183)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion183 = 0x183,

    [Address(0x184)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion184 = 0x184,

    [Address(0x185)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion185 = 0x185,

    [Address(0x186)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion186 = 0x186,

    [Address(0x187)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion187 = 0x187,

    [Address(0x188)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion188 = 0x188,

    [Address(0x189)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion189 = 0x189,

    [Address(0x18A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18A = 0x18A,

    [Address(0x18B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18B = 0x18B,

    [Address(0x18C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18C = 0x18C,

    [Address(0x18D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18D = 0x18D,

    [Address(0x18E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18E = 0x18E,

    [Address(0x18F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion18F = 0x18F,

    [Address(0x190)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion190 = 0x190,

    [Address(0x191)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion191 = 0x191,

    [Address(0x192)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion192 = 0x192,

    [Address(0x193)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Clock Tower")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Flare-G")]
    FlareG193 = 0x193,

    [Address(0x194)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Hold")]
    [CheckRequirements(" Glide ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Paper-G")]
    PaperG = 0x194,

    [Address(0x195)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ship: Hold")]
    [CheckRequirements(" Yellow Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 29")]
    Dalmatians29 = 0x195,

    [Address(0x196)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Captain's Cabin")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 30")]
    Dalmatians30 = 0x196,

    [Address(0x197)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Life-G")]
    LifeG = 0x197,

    [Address(0x198)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Meteor-G")]
    MeteorG198 = 0x198,

    [Address(0x199)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 58")]
    Reward58 = 0x199,

    [Address(0x19A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements(" Blizzard Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 31")]
    Dalmatians31 = 0x19A,

    [Address(0x19B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements(" Blizzard Magic")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 79")]
    Reward79 = 0x19B,

    [Address(0x19C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir19C = 0x19C,

    [Address(0x19D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Castle Gates")]
    [CheckRequirements(" Dumbo OR HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 32")]
    Dalmatians32 = 0x19D,

    [Address(0x19E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Castle Gates")]
    [CheckRequirements(" Dumbo OR HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 59")]
    Reward59 = 0x19E,

    [Address(0x19F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Castle Gates")]
    [CheckRequirements(" Dumbo OR HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Haste2-G")]
    Haste2G19F = 0x19F,

    [Address(0x1A0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Great Crest")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum1A0 = 0x1A0,

    [Address(0x1A1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Great Crest")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundaga-G")]
    ThundagaG1A1 = 0x1A1,

    [Address(0x1A2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("High Tower")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Osmose-G")]
    OsmoseG1A2 = 0x1A2,

    [Address(0x1A3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("High Tower")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 5a")]
    Reward5a = 0x1A3,

    [Address(0x1A4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("High Tower")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir1A4 = 0x1A4,

    [Address(0x1A5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Entrance Hall")]
    [CheckRequirements(" Dumbo")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 5b")]
    Reward5b = 0x1A5,

    [Address(0x1A6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Library")]
    [CheckRequirements(" Khama")]
    [CheckItem(ItemList.A41)]
    [CheckName("Ultima-G")]
    UltimaG = 0x1A6,

    [Address(0x1A7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1A7 = 0x1A7,

    [Address(0x1A8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion1A8 = 0x1A8,

    [Address(0x1A9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion1A9 = 0x1A9,

    [Address(0x1AA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1AA = 0x1AA,

    [Address(0x1AB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lift Stop")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a3")]
    Rewarda3 = 0x1AB,

    [Address(0x1AC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lift Stop")]
    [CheckRequirements(" Dumbo OR HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Osmose-G")]
    OsmoseG1AC = 0x1AC,

    [Address(0x1AD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lift Stop")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a4")]
    Rewarda4 = 0x1AD,

    [Address(0x1AE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lift Stop")]
    [CheckRequirements(" Dumbo OR HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 33")]
    Dalmatians33 = 0x1AE,

    [Address(0x1AF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Lift Stop")]
    [CheckRequirements(" Dumbo OR HB1")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum1AF = 0x1AF,

    [Address(0x1B0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Base Level")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril1B0 = 0x1B0,

    [Address(0x1B1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Base Level")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Paper-G")]
    PaperG1B1 = 0x1B1,

    [Address(0x1B2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Base Level")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundara-G")]
    ThundaraG1B2 = 0x1B2,

    [Address(0x1B3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7a")]
    Reward7a = 0x1B3,

    [Address(0x1B4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterway")]
    [CheckRequirements(" High Jump ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a5")]
    Rewarda5 = 0x1B4,

    [Address(0x1B5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Waterway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundaga-G")]
    ThundagaG1B5 = 0x1B5,

    [Address(0x1B6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dungeon")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Ultima-G")]
    UltimaG1B6 = 0x1B6,

    [Address(0x1B7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dungeon")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundaga-G")]
    ThundagaG1B7 = 0x1B7,

    [Address(0x1B8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1B8 = 0x1B8,

    [Address(0x1B9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1B9 = 0x1B9,

    [Address(0x1BA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1BA = 0x1BA,

    [Address(0x1BB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1BB = 0x1BB,

    [Address(0x1BC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1BC = 0x1BC,

    [Address(0x1BD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1BD = 0x1BD,

    [Address(0x1BE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion1BE = 0x1BE,

    [Address(0x1BF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Grand Hall")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a6")]
    Rewarda6 = 0x1BF,

    [Address(0x1C0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Grand Hall")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 31")]
    Reward31 = 0x1C0,

    [Address(0x1C1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Grand Hall")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dalmatians 21")]
    Dalmatians21 = 0x1C1,

    [Address(0x1C2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion1C2 = 0x1C2,

    [Address(0x1C3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Rising Falls")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Thundaga-G")]
    ThundagaG1C3 = 0x1C3,

    [Address(0x1C4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7b")]
    Reward7b = 0x1C4,

    [Address(0x1C5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7c")]
    Reward7c = 0x1C5,

    [Address(0x1C6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7d")]
    Reward7d = 0x1C6,

    [Address(0x1C7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7e")]
    Reward7e = 0x1C7,

    [Address(0x1C8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 7f")]
    Reward7f = 0x1C8,

    [Address(0x1C9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 80")]
    Reward80 = 0x1C9,

    [Address(0x1CA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 81")]
    Reward81 = 0x1CA,

    [Address(0x1CB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 82")]
    Reward82 = 0x1CB,

    [Address(0x1CC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 83")]
    Reward83 = 0x1CC,

    [Address(0x1CD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 84")]
    Reward84 = 0x1CD,

    [Address(0x1CE)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Giant Crevasse")]
    [CheckRequirements(" EotW ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Full-Life-G")]
    FullLifeG = 0x1CE,

    [Address(0x1CF)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Giant Crevasse")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a8")]
    Rewarda8 = 0x1CF,

    [Address(0x1D0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Giant Crevasse")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Drill-G")]
    DrillG = 0x1D0,

    [Address(0x1D1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Giant Crevasse")]
    [CheckRequirements(" EotW ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward a7")]
    Rewarda7 = 0x1D1,

    [Address(0x1D2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Giant Crevasse")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Ultima-G")]
    UltimaG1D2 = 0x1D2,

    [Address(0x1D3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 87")]
    Reward87 = 0x1D3,

    [Address(0x1D4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 88")]
    Reward88 = 0x1D4,

    [Address(0x1D5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 89")]
    Reward89 = 0x1D5,

    [Address(0x1D6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 8a")]
    Reward8a = 0x1D6,

    [Address(0x1D7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 8b")]
    Reward8b = 0x1D7,

    [Address(0x1D8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp = 0x1D8,

    [Address(0x1D9)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 8c")]
    Reward8c = 0x1D9,

    [Address(0x1DA)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 8d")]
    Reward8d = 0x1DA,

    [Address(0x1DB)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir1DB = 0x1DB,

    [Address(0x1DC)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("World Terminus")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 8e")]
    Reward8e = 0x1DC,

    [Address(0x1DD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Rest")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.Megalixir)]
    [CheckName("Megalixir")]
    Megalixir1DD = 0x1DD,

    [Address(0x1FD)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chamber 6")]
    [CheckRequirements(" White Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Reward 9E")]
    Reward9E = 0x1FD,

        
    
}