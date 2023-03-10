
using KHData.Enums;
using KHData.Worlds;

namespace KHData.Items;

public enum Rewards 
{        

    [Address(0x00)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Defeat Leon")]
    [CheckRequirements(" Missable")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir = 0x00,

    [Address(0x01)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("End of TT")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dodge Roll")]
    DodgeRoll = 0x01,

    [Address(0x02)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Aerith TT")]
    [CheckRequirements(" Missable")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion = 0x02,

    [Address(0x03)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Dodge Roll")]
    DodgeRoll03 = 0x03,

    [Address(0x04)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Treasure Magnet")]
    TreasureMagnet = 0x04,

    [Address(0x05)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Second Wind")]
    SecondWind = 0x05,

    [Address(0x06)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("High Jump")]
    HighJump = 0x06,

    [Address(0x07)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion = 0x07,

    [Address(0x08)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion08 = 0x08,

    [Address(0x09)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion09 = 0x09,

    [Address(0x0A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion0A = 0x0A,

    [Address(0x0B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion0B = 0x0B,

    [Address(0x0C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion0C = 0x0C,

    [Address(0x0D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.Potion)]
    [CheckName("Potion")]
    Potion0D = 0x0D,

    [Address(0x0E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ursula 1")]
    [CheckRequirements("")]
    [CheckItem(ItemList.A41)]
    [CheckName("Mermaid Kick")]
    MermaidKick = 0x0E,

    [Address(0x0F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Neverland")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Glide")]
    Glide = 0x0F,

    [Address(0x10)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chernabog")]
    [CheckRequirements(" EotW ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Superglide")]
    Superglide = 0x10,

    [Address(0x11)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dragon Maleficent")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.FireGlow)]
    [CheckName("Fireglow")]
    Fireglow = 0x11,

    [Address(0x12)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Secret Waterway")]
    [CheckRequirements("")]
    [CheckItem(ItemList.Earthshine)]
    [CheckName("Earthshine")]
    Earthshine = 0x12,

    [Address(0x13)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Deep Jungle")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.JungleKing)]
    [CheckName("Jungle King")]
    JungleKing = 0x13,

    [Address(0x14)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Agrabah")]
    [CheckRequirements("")]
    [CheckItem(ItemList.ThreeWishes)]
    [CheckName("Three Wishes")]
    ThreeWishes = 0x14,

    [Address(0x15)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Neverland")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.FairyHarp)]
    [CheckName("Fairy Harp")]
    FairyHarp = 0x15,

    [Address(0x16)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Halloween Town")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.A41)]
    [CheckName("Pumpkinhead")]
    Pumpkinhead = 0x16,

    [Address(0x17)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Atlantica")]
    [CheckRequirements(" Mermaid Kick")]
    [CheckItem(ItemList.Crabclaw)]
    [CheckName("Crabclaw")]
    Crabclaw = 0x17,

    [Address(0x18)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Belle in HB2")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.DivineRose)]
    [CheckName("Divine Rose")]
    DivineRose = 0x18,

    [Address(0x19)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Leon & Cloud Hades Cup")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.Lionheart)]
    [CheckName("Lionheart")]
    Lionheart = 0x19,

    [Address(0x1A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cloud Hercules Cup")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.MetalChocobo)]
    [CheckName("Metal Chocobo")]
    MetalChocobo = 0x1A,

    [Address(0x1B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Kairi TT4")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.Oathkeeper)]
    [CheckName("Oathkeeper")]
    Oathkeeper = 0x1B,

    [Address(0x1C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Yuffie Hades Cup")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.GenjiShield)]
    [CheckName("Genji Shield")]
    GenjiShield = 0x1C,

    [Address(0x1D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hercules Cup")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.HercsShield)]
    [CheckName("Herc's Shield")]
    HercsShield = 0x1D,

    [Address(0x1E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Olympus Coliseum")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Sonic Blade")]
    SonicBlade = 0x1E,

    [Address(0x1F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Anti-Sora")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.RavensClaw)]
    [CheckName("Raven's Claw")]
    RavensClaw = 0x1F,

    [Address(0x20)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pegasus Cup")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Strike Raid")]
    StrikeRaid = 0x20,

    [Address(0x21)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Riku 2")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.A41)]
    [CheckName("Ragnarok")]
    Ragnarok = 0x21,

    [Address(0x22)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hades Cup")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Trinity Limit")]
    TrinityLimit = 0x22,

    [Address(0x23)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Capt. Hook")]
    [CheckRequirements(" Green Trinity")]
    [CheckItem(ItemList.A41)]
    [CheckName("Ars Arcanum")]
    ArsArcanum = 0x23,

    [Address(0x24)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Maleficent")]
    [CheckRequirements(" HB1")]
    [CheckItem(ItemList.A41)]
    [CheckName("Cheer (Donald)")]
    CheerDonald = 0x24,

    [Address(0x25)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Parasite Cage")]
    [CheckRequirements(" High Jump OR Glide")]
    [CheckItem(ItemList.A41)]
    [CheckName("Cheer (Goofy)")]
    CheerGoofy = 0x25,

    [Address(0x26)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Fairy Godmother")]
    [CheckRequirements(" All Summons ")]
    [CheckItem(ItemList.LordFortune)]
    [CheckName("Lord Fortune")]
    LordFortune = 0x26,

    [Address(0x27)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.A41)]
    [CheckName("High Jump")]
    HighJump27 = 0x27,

    [Address(0x28)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.WaterGleam)]
    [CheckName("Watergleam")]
    Watergleam = 0x28,

    [Address(0x29)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril = 0x29,

    [Address(0x2A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Wood")]
    [CheckRequirements(" Page1")]
    [CheckItem(ItemList.A41)]
    [CheckName("Naturespark")]
    Naturespark = 0x2A,

    [Address(0x2B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Wood")]
    [CheckRequirements(" Page2")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard = 0x2B,

    [Address(0x2C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Wood")]
    [CheckRequirements(" Page4")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril2C = 0x2C,

    [Address(0x2D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hundred Acre Wood")]
    [CheckRequirements(" Page5")]
    [CheckItem(ItemList.EXPRing)]
    [CheckName("EXP Ring")]
    EXPRing = 0x2D,

    [Address(0x2E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("From Owl")]
    [CheckRequirements(" Page5")]
    [CheckItem(ItemList.A41)]
    [CheckName("Cheer (Sora)")]
    CheerSora = 0x2E,

    [Address(0x2F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Merlin")]
    [CheckRequirements(" Arts ")]
    [CheckItem(ItemList.DreamShield)]
    [CheckName("Dream Shield")]
    DreamShield = 0x2F,

    [Address(0x30)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Olympus Coliseum")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.Olympia)]
    [CheckName("Olympia")]
    Olympia = 0x30,

    [Address(0x31)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Oblivion)]
    [CheckName("Oblivion")]
    Oblivion = 0x31,

    [Address(0x32)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril32 = 0x32,

    [Address(0x33)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.WishingStar)]
    [CheckName("Wishing Star")]
    WishingStar = 0x33,

    [Address(0x34)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 42 Puppies")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard34 = 0x34,

    [Address(0x35)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 60 Puppies")]
    [CheckItem(ItemList.A41)]
    [CheckName("Megalixir")]
    Megalixir = 0x35,

    [Address(0x36)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 72 Puppies")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum = 0x36,

    [Address(0x37)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 90 Puppies")]
    [CheckItem(ItemList.A41)]
    [CheckName("Tech Boost")]
    TechBoost = 0x37,

    [Address(0x38)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Guard Armor")]
    [CheckRequirements("")]
    [CheckItem(ItemList.BraveWarrior)]
    [CheckName("Brave Warrior")]
    BraveWarrior = 0x38,

    [Address(0x39)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Trickmaster")]
    [CheckRequirements(" Evidence")]
    [CheckItem(ItemList.IfritsHorn)]
    [CheckName("Ifrit's Horn")]
    IfritsHorn = 0x39,

    [Address(0x3A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Cerberus")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.InfernoBand)]
    [CheckName("Inferno Band")]
    InfernoBand = 0x3A,

    [Address(0x3B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Sabor 2")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.WhiteFang)]
    [CheckName("White Fang")]
    WhiteFang = 0x3B,

    [Address(0x3C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pot Centipede")]
    [CheckRequirements("")]
    [CheckItem(ItemList.RayOfLight)]
    [CheckName("Ray of Light")]
    RayofLight = 0x3C,

    [Address(0x3D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Oogie Boogie")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckItem(ItemList.HolyCirclet)]
    [CheckName("Holy Circlet")]
    HolyCirclet = 0x3D,

    [Address(0x3E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Behemoth")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.OmegaArts)]
    [CheckName("Omega Arts")]
    OmegaArts = 0x3E,

    [Address(0x3F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp = 0x3F,

    [Address(0x40)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir40 = 0x40,

    [Address(0x41)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp = 0x41,

    [Address(0x42)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum42 = 0x42,

    [Address(0x43)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.CampingSet)]
    [CheckName("Camping Set")]
    CampingSet = 0x43,

    [Address(0x44)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion44 = 0x44,

    [Address(0x45)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.A41)]
    [CheckName("Megalixir")]
    Megalixir45 = 0x45,

    [Address(0x46)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard46 = 0x46,

    [Address(0x47)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum47 = 0x47,

    [Address(0x48)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.LadyLuck)]
    [CheckName("Lady Luck")]
    LadyLuck = 0x48,

    [Address(0x49)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion49 = 0x49,

    [Address(0x4A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ProtectChain)]
    [CheckName("Protect Chain")]
    ProtectChain = 0x4A,

    [Address(0x4B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum4B = 0x4B,

    [Address(0x4C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard4C = 0x4C,

    [Address(0x4D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp4D = 0x4D,

    [Address(0x4E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage = 0x4E,

    [Address(0x4F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.FireRing)]
    [CheckName("Fire Ring")]
    FireRing = 0x4F,

    [Address(0x50)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril50 = 0x50,

    [Address(0x51)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage51 = 0x51,

    [Address(0x52)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir52 = 0x52,

    [Address(0x53)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion53 = 0x53,

    [Address(0x54)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ProteraChain)]
    [CheckName("Protera Chain")]
    ProteraChain = 0x54,

    [Address(0x55)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard55 = 0x55,

    [Address(0x56)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Violetta)]
    [CheckName("Violetta")]
    Violetta = 0x56,

    [Address(0x57)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard57 = 0x57,

    [Address(0x58)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp58 = 0x58,

    [Address(0x59)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum59 = 0x59,

    [Address(0x5A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ThundaraRing)]
    [CheckName("Thundara Ring")]
    ThundaraRing = 0x5A,

    [Address(0x5B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp5B = 0x5B,

    [Address(0x5C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Merlin")]
    [CheckRequirements(" All Spells")]
    [CheckItem(ItemList.Spellbinder)]
    [CheckName("Spellbinder")]
    Spellbinder = 0x5C,

    [Address(0x5D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Merlin")]
    [CheckRequirements(" Max Spells")]
    [CheckItem(ItemList.DreamRod)]
    [CheckName("Dream Rod")]
    DreamRod = 0x5D,

    [Address(0x5E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Phil Cup Solo")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Combo Plus")]
    ComboPlus = 0x5E,

    [Address(0x5F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pegasus Cup Solo")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum5F = 0x5F,

    [Address(0x60)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hercules Cup Solo")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Critical Plus")]
    CriticalPlus = 0x60,

    [Address(0x61)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hades Cup Solo")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.SaveTheQueen)]
    [CheckName("Save the Queen")]
    SavetheQueen = 0x61,

    [Address(0x62)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Phil Cup Time Trial")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Tech Boost")]
    TechBoost62 = 0x62,

    [Address(0x63)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Pegasus Cup Time Trial")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter = 0x63,

    [Address(0x64)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hercules Cup Time Trial")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.A41)]
    [CheckName("Gravity Break")]
    GravityBreak = 0x64,

    [Address(0x65)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Hades Cup Time Trial")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.SaveTheKing)]
    [CheckName("Save the King")]
    SavetheKing = 0x65,

    [Address(0x66)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ProtectChain)]
    [CheckName("Protect Chain")]
    ProtectChain66 = 0x66,

    [Address(0x67)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 1")]
    [CheckRequirements(" Postcard 1")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage67 = 0x67,

    [Address(0x68)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 2")]
    [CheckRequirements(" Postcard 2")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard68 = 0x68,

    [Address(0x69)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 3")]
    [CheckRequirements(" Postcard 3")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion69 = 0x69,

    [Address(0x6A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 4")]
    [CheckRequirements(" Postcard 4")]
    [CheckItem(ItemList.MegaEther)]
    [CheckName("Mega-Ether")]
    MegaEther = 0x6A,

    [Address(0x6B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 5")]
    [CheckRequirements(" Postcard 5")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril6B = 0x6B,

    [Address(0x6C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 6")]
    [CheckRequirements(" Postcard 6")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir6C = 0x6C,

    [Address(0x6D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 7")]
    [CheckRequirements(" Postcard 7")]
    [CheckItem(ItemList.A41)]
    [CheckName("Megalixir")]
    Megalixir6D = 0x6D,

    [Address(0x6E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 8")]
    [CheckRequirements(" Postcard 8")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum6E = 0x6E,

    [Address(0x6F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 9")]
    [CheckRequirements(" Postcard 9")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp6F = 0x6F,

    [Address(0x70)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Postcard 10")]
    [CheckRequirements(" Postcard 10")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp70 = 0x70,

    [Address(0x71)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 51 Puppies")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril71 = 0x71,

    [Address(0x72)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion72 = 0x72,

    [Address(0x73)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard73 = 0x73,

    [Address(0x74)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir74 = 0x74,

    [Address(0x75)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril75 = 0x75,

    [Address(0x76)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ProteraChain)]
    [CheckName("Protera Chain")]
    ProteraChain76 = 0x76,

    [Address(0x77)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ThunderRing)]
    [CheckName("Thunder Ring")]
    ThunderRing = 0x77,

    [Address(0x78)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ProteraChain)]
    [CheckName("Protera Chain")]
    ProteraChain78 = 0x78,

    [Address(0x79)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.BlizzaraRing)]
    [CheckName("Blizzara Ring")]
    BlizzaraRing = 0x79,

    [Address(0x7A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.FiraRing)]
    [CheckName("Fira Ring")]
    FiraRing = 0x7A,

    [Address(0x7B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard7B = 0x7B,

    [Address(0x7C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.PrettyStone)]
    [CheckName("Pretty Stone")]
    PrettyStone = 0x7C,

    [Address(0x7D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.MegaPotion)]
    [CheckName("Mega-Potion")]
    MegaPotion7D = 0x7D,

    [Address(0x7E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.Mythril)]
    [CheckName("Mythril")]
    Mythril7E = 0x7E,

    [Address(0x7F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir7F = 0x7F,

    [Address(0x80)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MythrilShard)]
    [CheckName("Mythril Shard")]
    MythrilShard80 = 0x80,

    [Address(0x81)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.PrettyStone)]
    [CheckName("Pretty Stone")]
    PrettyStone81 = 0x81,

    [Address(0x82)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Cottage)]
    [CheckName("Cottage")]
    Cottage82 = 0x82,

    [Address(0x83)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.A41)]
    [CheckName("Gale")]
    Gale = 0x83,

    [Address(0x84)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Final Dimension")]
    [CheckRequirements(" EotW")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp84 = 0x84,

    [Address(0x85)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Megalixir")]
    Megalixir85 = 0x85,

    [Address(0x86)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.A41)]
    [CheckName("Megalixir")]
    Megalixir86 = 0x86,

    [Address(0x87)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.SpiritGem)]
    [CheckName("Spirit Gem")]
    SpiritGem = 0x87,

    [Address(0x88)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ThunderGem)]
    [CheckName("Thunder Gem")]
    ThunderGem = 0x88,

    [Address(0x89)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.FrostGem)]
    [CheckName("Frost Gem")]
    FrostGem = 0x89,

    [Address(0x8A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.BrightGem)]
    [CheckName("Bright Gem")]
    BrightGem = 0x8A,

    [Address(0x8B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.BlazeGem)]
    [CheckName("Blaze Gem")]
    BlazeGem = 0x8B,

    [Address(0x8C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.LucidGem)]
    [CheckName("Lucid Gem")]
    LucidGem = 0x8C,

    [Address(0x8D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MightyShield)]
    [CheckName("Mighty Shield")]
    MightyShield = 0x8D,

    [Address(0x8E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir8E = 0x8E,

    [Address(0x8F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle Slider")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.Elixir)]
    [CheckName("Elixir")]
    Elixir8F = 0x8F,

    [Address(0x90)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle Slider")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.APUp)]
    [CheckName("AP Up")]
    APUp90 = 0x90,

    [Address(0x91)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle Slider")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter91 = 0x91,

    [Address(0x92)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle Slider")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.DefenseUp)]
    [CheckName("Defense Up")]
    DefenseUp92 = 0x92,

    [Address(0x93)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Jungle Slider")]
    [CheckRequirements(" Slides")]
    [CheckItem(ItemList.PowerUp)]
    [CheckName("Power Up")]
    PowerUp = 0x93,

    [Address(0x94)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Ice Titan")]
    [CheckRequirements(" Entry Pass")]
    [CheckItem(ItemList.DiamondDust)]
    [CheckName("Diamond Dust")]
    DiamondDust = 0x94,

    [Address(0x95)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Sephiroth")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.OneWingedAngel)]
    [CheckName("One-Winged Angel")]
    OneWingedAngel = 0x95,

    [Address(0x96)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Kurt Zisa")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.A41)]
    [CheckName("Zantetsuken")]
    Zantetsuken = 0x96,

    [Address(0x97)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Unknown")]
    [CheckRequirements(" HB1 ")]
    [CheckItem(ItemList.EXPNecklace)]
    [CheckName("EXP Necklace")]
    EXPNecklace = 0x97,

    [Address(0x98)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("?")]
    [CheckRequirements(" ?")]
    [CheckItem(ItemList.FiragunBand)]
    [CheckName("Firagun Band")]
    FiragunBand = 0x98,

    [Address(0x99)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter99 = 0x99,

    [Address(0x9A)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.ShivaBelt)]
    [CheckName("Shiva Belt")]
    ShivaBelt = 0x9A,

    [Address(0x9B)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter9B = 0x9B,

    [Address(0x9C)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter9C = 0x9C,

    [Address(0x9D)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.IfritBelt)]
    [CheckName("Ifrit Belt")]
    IfritBelt = 0x9D,

    [Address(0x9E)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatter9E = 0x9E,

    [Address(0x9F)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    Orichalcum9F = 0x9F,

    [Address(0xA0)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatterA0 = 0xA0,

    [Address(0xA1)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatterA1 = 0xA1,

    [Address(0xA2)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.Orichalcum)]
    [CheckName("Orichalcum")]
    OrichalcumA2 = 0xA2,

    [Address(0xA3)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.RamuhBelt)]
    [CheckName("Ramuh Belt")]
    RamuhBelt = 0xA3,

    [Address(0xA4)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.RoyalCrown)]
    [CheckName("Royal Crown")]
    RoyalCrown = 0xA4,

    [Address(0xA5)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatterA5 = 0xA5,

    [Address(0xA6)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatterA6 = 0xA6,

    [Address(0xA7)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.DarkMatter)]
    [CheckName("Dark Matter")]
    DarkMatterA7 = 0xA7,

    [Address(0xA8)]
    [CheckWorld(WorldList.TraverseTown)]
    [CheckLocation("Chest")]
    [CheckRequirements(" -")]
    [CheckItem(ItemList.MeteorStrike)]
    [CheckName("Meteor Strike")]
    MeteorStrike = 0xA8,

        
    
}