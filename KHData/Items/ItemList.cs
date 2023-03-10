
using KHData.Enums;
using KHData.Worlds;

namespace KHData.Items;

public enum ItemList 
{        

    [Address(0x01)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Potion")]
    Potion = 0x01,

    [Address(0x02)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Hi-Potion")]
    HiPotion = 0x02,

    [Address(0x03)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ether")]
    Ether = 0x03,

    [Address(0x04)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Elixir")]
    Elixir = 0x04,

    [Address(0x05)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("BO5")]
    BO5 = 0x05,

    [Address(0x06)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mega-Potion")]
    MegaPotion = 0x06,

    [Address(0x07)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mega-Ether")]
    MegaEther = 0x07,

    [Address(0x08)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Megalixir")]
    Megalixir = 0x08,

    [Address(0x09)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fury Stone")]
    FuryStone = 0x09,

    [Address(0x0A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Stone")]
    PowerStone = 0x0A,

    [Address(0x0B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Energy Stone")]
    EnergyStone = 0x0B,

    [Address(0x0C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blazing Stone")]
    BlazingStone = 0x0C,

    [Address(0x0D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Frost Stone")]
    FrostStone = 0x0D,

    [Address(0x0E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lightning Stone")]
    LightningStone = 0x0E,

    [Address(0x0F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dazzling Stone")]
    DazzlingStone = 0x0F,

    [Address(0x10)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Stormy Stone")]
    StormyStone = 0x10,

    [Address(0x11)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Protect Chain")]
    ProtectChain = 0x11,

    [Address(0x12)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Protera Chain")]
    ProteraChain = 0x12,

    [Address(0x13)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Protega Chain")]
    ProtegaChain = 0x13,

    [Address(0x14)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fire Ring")]
    FireRing = 0x14,

    [Address(0x15)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fira Ring")]
    FiraRing = 0x15,

    [Address(0x16)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Firaga Ring")]
    FiragaRing = 0x16,

    [Address(0x17)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blizzard Ring")]
    BlizzardRing = 0x17,

    [Address(0x18)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blizzara Ring")]
    BlizzaraRing = 0x18,

    [Address(0x19)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blizzaga Ring")]
    BlizzagaRing = 0x19,

    [Address(0x1A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thunder Ring")]
    ThunderRing = 0x1A,

    [Address(0x1B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thundara Ring")]
    ThundaraRing = 0x1B,

    [Address(0x1C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thundaga Ring")]
    ThundagaRing = 0x1C,

    [Address(0x1D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ability Stud")]
    AbilityStud = 0x1D,

    [Address(0x1E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Guard Earring")]
    GuardEarring = 0x1E,

    [Address(0x1F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Master Earring")]
    MasterEarring = 0x1F,

    [Address(0x20)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Chaos Ring")]
    ChaosRing = 0x20,

    [Address(0x21)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dark Ring")]
    DarkRing = 0x21,

    [Address(0x22)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Element Ring")]
    ElementRing = 0x22,

    [Address(0x23)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Three Stars")]
    ThreeStars = 0x23,

    [Address(0x24)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Chain")]
    PowerChain = 0x24,

    [Address(0x25)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Golem Chain")]
    GolemChain = 0x25,

    [Address(0x26)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Titan Chain")]
    TitanChain = 0x26,

    [Address(0x27)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Energy Bangle")]
    EnergyBangle = 0x27,

    [Address(0x28)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Angel Bangle")]
    AngelBangle = 0x28,

    [Address(0x29)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Gaia Bangle")]
    GaiaBangle = 0x29,

    [Address(0x2A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Magic Armlet")]
    MagicArmlet = 0x2A,

    [Address(0x2B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Rune Armlet")]
    RuneArmlet = 0x2B,

    [Address(0x2C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Atlas Armlet")]
    AtlasArmlet = 0x2C,

    [Address(0x2D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Heartguard")]
    Heartguard = 0x2D,

    [Address(0x2E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ribbon")]
    Ribbon = 0x2E,

    [Address(0x2F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Crystal Crown")]
    CrystalCrown = 0x2F,

    [Address(0x30)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Brave Warrior")]
    BraveWarrior = 0x30,

    [Address(0x31)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ifrit's Horn")]
    IfritsHorn = 0x31,

    [Address(0x32)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Inferno Band")]
    InfernoBand = 0x32,

    [Address(0x33)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("White Fang")]
    WhiteFang = 0x33,

    [Address(0x34)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ray of Light")]
    RayofLight = 0x34,

    [Address(0x35)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Holy Circlet")]
    HolyCirclet = 0x35,

    [Address(0x36)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Raven's Claw")]
    RavensClaw = 0x36,

    [Address(0x37)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Omega Arts")]
    OmegaArts = 0x37,

    [Address(0x38)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("EXP Earring")]
    EXPEarring = 0x38,

    [Address(0x39)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A41")]
    A41 = 0x39,

    [Address(0x3A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("EXP Ring")]
    EXPRing = 0x3A,

    [Address(0x3B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("EXP Bracelet")]
    EXPBracelet = 0x3B,

    [Address(0x3C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("EXP Necklace")]
    EXPNecklace = 0x3C,

    [Address(0x3D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Firagun Band")]
    FiragunBand = 0x3D,

    [Address(0x3E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blizzagun Band")]
    BlizzagunBand = 0x3E,

    [Address(0x3F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thundagun Band")]
    ThundagunBand = 0x3F,

    [Address(0x40)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ifrit Belt")]
    IfritBelt = 0x40,

    [Address(0x41)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Shiva Belt")]
    ShivaBelt = 0x41,

    [Address(0x42)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ramuh Belt")]
    RamuhBelt = 0x42,

    [Address(0x43)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Moogle Badge")]
    MoogleBadge = 0x43,

    [Address(0x44)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Cosmic Arts")]
    CosmicArts = 0x44,

    [Address(0x45)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Royal Crown")]
    RoyalCrown = 0x45,

    [Address(0x46)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Prime Cap")]
    PrimeCap = 0x46,

    [Address(0x47)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Obsidian Ring")]
    ObsidianRing = 0x47,

    [Address(0x48)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A56")]
    A56 = 0x48,

    [Address(0x49)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A57")]
    A57 = 0x49,

    [Address(0x4A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A58")]
    A58 = 0x4A,

    [Address(0x4B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A59")]
    A59 = 0x4B,

    [Address(0x4C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A60")]
    A60 = 0x4C,

    [Address(0x4D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A61")]
    A61 = 0x4D,

    [Address(0x4E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A62")]
    A62 = 0x4E,

    [Address(0x4F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A63")]
    A63 = 0x4F,

    [Address(0x50)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("A64")]
    A64 = 0x50,

    [Address(0x51)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Kingdom Key")]
    KingdomKey = 0x51,

    [Address(0x52)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dream Sword")]
    DreamSword = 0x52,

    [Address(0x53)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dream Shield")]
    DreamShield = 0x53,

    [Address(0x54)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dream Rod")]
    DreamRod = 0x54,

    [Address(0x55)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Wooden Sword")]
    WoodenSword = 0x55,

    [Address(0x56)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Jungle King")]
    JungleKing = 0x56,

    [Address(0x57)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Three Wishes")]
    ThreeWishes = 0x57,

    [Address(0x58)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fairy Harp")]
    FairyHarp = 0x58,

    [Address(0x59)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Pumpkinhead")]
    Pumpkinhead = 0x59,

    [Address(0x5A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Crabclaw")]
    Crabclaw = 0x5A,

    [Address(0x5B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Divine Rose")]
    DivineRose = 0x5B,

    [Address(0x5C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Spellbinder")]
    Spellbinder = 0x5C,

    [Address(0x5D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Olympia")]
    Olympia = 0x5D,

    [Address(0x5E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lionheart")]
    Lionheart = 0x5E,

    [Address(0x5F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Metal Chocobo")]
    MetalChocobo = 0x5F,

    [Address(0x60)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Oathkeeper")]
    Oathkeeper = 0x60,

    [Address(0x61)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Oblivion")]
    Oblivion = 0x61,

    [Address(0x62)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lady Luck")]
    LadyLuck = 0x62,

    [Address(0x63)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Wishing Star")]
    WishingStar = 0x63,

    [Address(0x64)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ultima Weapon")]
    UltimaWeapon = 0x64,

    [Address(0x65)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Diamond Dust")]
    DiamondDust = 0x65,

    [Address(0x66)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("One-Winged Angel")]
    OneWingedAngel = 0x66,

    [Address(0x67)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mage's Staff")]
    MagesStaff = 0x67,

    [Address(0x68)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Morning Star")]
    MorningStar = 0x68,

    [Address(0x69)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Shooting Star")]
    ShootingStar = 0x69,

    [Address(0x6A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Magus Staff")]
    MagusStaff = 0x6A,

    [Address(0x6B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Wisdom Staff")]
    WisdomStaff = 0x6B,

    [Address(0x6C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Warhammer")]
    Warhammer = 0x6C,

    [Address(0x6D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Silver Mallet")]
    SilverMallet = 0x6D,

    [Address(0x6E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Grand Mallet")]
    GrandMallet = 0x6E,

    [Address(0x6F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lord Fortune")]
    LordFortune = 0x6F,

    [Address(0x70)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Violetta")]
    Violetta = 0x70,

    [Address(0x71)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dream Rod (Donald)")]
    DreamRodDonald = 0x71,

    [Address(0x72)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Save the Queen")]
    SavetheQueen = 0x72,

    [Address(0x73)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Wizard's Relic")]
    WizardsRelic = 0x73,

    [Address(0x74)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Meteor Strike")]
    MeteorStrike = 0x74,

    [Address(0x75)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fantasista")]
    Fantasista = 0x75,

    [Address(0x76)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Unused (Donald)")]
    UnusedDonald = 0x76,

    [Address(0x77)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Knight's Shield")]
    KnightsShield = 0x77,

    [Address(0x78)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mythril Shield")]
    MythrilShield = 0x78,

    [Address(0x79)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Onyx Shield")]
    OnyxShield = 0x79,

    [Address(0x7A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Stout Shield")]
    StoutShield = 0x7A,

    [Address(0x7B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Golem Shield")]
    GolemShield = 0x7B,

    [Address(0x7C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Adamant Shield")]
    AdamantShield = 0x7C,

    [Address(0x7D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Smasher")]
    Smasher = 0x7D,

    [Address(0x7E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Gigas Fist")]
    GigasFist = 0x7E,

    [Address(0x7F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Genji Shield")]
    GenjiShield = 0x7F,

    [Address(0x80)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Herc's Shield")]
    HercsShield = 0x80,

    [Address(0x81)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dream Shield")]
    DreamShield81 = 0x81,

    [Address(0x82)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Save the King")]
    SavetheKing = 0x82,

    [Address(0x83)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Defender")]
    Defender = 0x83,

    [Address(0x84)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mighty Shield")]
    MightyShield = 0x84,

    [Address(0x85)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Seven Elements")]
    SevenElements = 0x85,

    [Address(0x86)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Unused (Goofy)")]
    UnusedGoofy = 0x86,

    [Address(0x87)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Spear")]
    Spear = 0x87,

    [Address(0x88)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("No Weapon")]
    NoWeapon = 0x88,

    [Address(0x89)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Genie")]
    Genie = 0x89,

    [Address(0x8A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("No Weapon")]
    NoWeapon8A = 0x8A,

    [Address(0x8B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("No Weapon")]
    NoWeapon8B = 0x8B,

    [Address(0x8C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Tinker Bell")]
    TinkerBell = 0x8C,

    [Address(0x8D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Claws")]
    Claws = 0x8D,

    [Address(0x8E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Tent")]
    Tent = 0x8E,

    [Address(0x8F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Camping Set")]
    CampingSet = 0x8F,

    [Address(0x90)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Cottage")]
    Cottage = 0x90,

    [Address(0x91)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("C04")]
    C04 = 0x91,

    [Address(0x92)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("C05")]
    C05 = 0x92,

    [Address(0x93)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("C06")]
    C06 = 0x93,

    [Address(0x94)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("C07")]
    C07 = 0x94,

    [Address(0x95)]
    [CheckLocation("Kurt Zisa")]
    [CheckRequirements(" HB1 ")]
    [CheckName("Ansem's Report 11")]
    AnsemsReport11 = 0x95,

    [Address(0x96)]
    [CheckLocation("Sephiroth")]
    [CheckRequirements(" HB1 ")]
    [CheckName("Ansem's Report 12")]
    AnsemsReport12 = 0x96,

    [Address(0x97)]
    [CheckLocation("Unknown")]
    [CheckRequirements(" HB1 ")]
    [CheckName("Ansem's Report 13")]
    AnsemsReport13 = 0x97,

    [Address(0x98)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Up")]
    PowerUp = 0x98,

    [Address(0x99)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Defense Up")]
    DefenseUp = 0x99,

    [Address(0x9A)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("AP Up")]
    APUp = 0x9A,

    [Address(0x9B)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Serenity Power")]
    SerenityPower = 0x9B,

    [Address(0x9C)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Dark Matter")]
    DarkMatter = 0x9C,

    [Address(0x9D)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mythril Stone")]
    MythrilStone = 0x9D,

    [Address(0x9E)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Fire Arts")]
    FireArts = 0x9E,

    [Address(0x9F)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blizzard Arts")]
    BlizzardArts = 0x9F,

    [Address(0xA0)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thunder Arts")]
    ThunderArts = 0xA0,

    [Address(0xA1)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Cure Arts")]
    CureArts = 0xA1,

    [Address(0xA2)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Gravity Arts")]
    GravityArts = 0xA2,

    [Address(0xA3)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Stop Arts")]
    StopArts = 0xA3,

    [Address(0xA4)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Aero Arts")]
    AeroArts = 0xA4,

    [Address(0xA5)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Shiitank Rank")]
    ShiitankRank = 0xA5,

    [Address(0xA6)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Matsutake Rank")]
    MatsutakeRank = 0xA6,

    [Address(0xA7)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mystery Mold")]
    MysteryMold = 0xA7,

    [Address(0xA8)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 1")]
    AnsemsReport1 = 0xA8,

    [Address(0xA9)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 2")]
    AnsemsReport2 = 0xA9,

    [Address(0xAA)]
    [CheckLocation("Ursula")]
    [CheckRequirements(" Mermaid Kick")]
    [CheckName("Ansem's Report 3")]
    AnsemsReport3 = 0xAA,

    [Address(0xAB)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 4")]
    AnsemsReport4 = 0xAB,

    [Address(0xAC)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 5")]
    AnsemsReport5 = 0xAC,

    [Address(0xAD)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 6")]
    AnsemsReport6 = 0xAD,

    [Address(0xAE)]
    [CheckLocation("Oogie")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckName("Ansem's Report 7")]
    AnsemsReport7 = 0xAE,

    [Address(0xAF)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 8")]
    AnsemsReport8 = 0xAF,

    [Address(0xB0)]
    [CheckLocation("Hook")]
    [CheckRequirements(" Green Trinity")]
    [CheckName("Ansem's Report 9")]
    AnsemsReport9 = 0xB0,

    [Address(0xB1)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Ansem's Report 10")]
    AnsemsReport10 = 0xB1,

    [Address(0xB2)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Khama Vol. 8")]
    KhamaVol8 = 0xB2,

    [Address(0xB3)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Salegg Vol. 6")]
    SaleggVol6 = 0xB3,

    [Address(0xB4)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Azal Vol. 3")]
    AzalVol3 = 0xB4,

    [Address(0xB5)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mava Vol. 3")]
    MavaVol3 = 0xB5,

    [Address(0xB6)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mava Vol. 6")]
    MavaVol6 = 0xB6,

    [Address(0xB7)]
    [CheckLocation("")]
    [CheckRequirements(" -")]
    [CheckName("Theon Vol. 6")]
    TheonVol6 = 0xB7,

    [Address(0xB8)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Nahara Vol. 5")]
    NaharaVol5 = 0xB8,

    [Address(0xB9)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Hafet Vol. 4")]
    HafetVol4 = 0xB9,

    [Address(0xBA)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Empty Bottle")]
    EmptyBottle = 0xBA,

    [Address(0xBB)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Old Book")]
    OldBook = 0xBB,

    [Address(0xBC)]
    [CheckLocation("Entrance Hall")]
    [CheckRequirements(" Fire Magic ")]
    [CheckName("Emblem Piece (Flame)")]
    EmblemPieceFlame = 0xBC,

    [Address(0xBD)]
    [CheckLocation("Entrance Hall")]
    [CheckRequirements(" Theon OR High Jumpra")]
    [CheckName("Emblem Piece (Chest)")]
    EmblemPieceChest = 0xBD,

    [Address(0xBE)]
    [CheckLocation("Entrance Hall")]
    [CheckRequirements(" Red Trinity ")]
    [CheckName("Emblem Piece (Statue)")]
    EmblemPieceStatue = 0xBE,

    [Address(0xBF)]
    [CheckLocation("Entrance Hall")]
    [CheckRequirements(" Theon OR High Jumpra")]
    [CheckName("Emblem Piece (Fountain)")]
    EmblemPieceFountain = 0xBF,

    [Address(0xC0)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements("")]
    [CheckName("Log")]
    Log = 0xC0,

    [Address(0xC1)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements("")]
    [CheckName("Cloth")]
    Cloth = 0xC1,

    [Address(0xC2)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements("")]
    [CheckName("Rope")]
    Rope = 0xC2,

    [Address(0xC3)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckName("Seagull Egg")]
    SeagullEgg = 0xC3,

    [Address(0xC4)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckName("Fish")]
    Fish = 0xC4,

    [Address(0xC5)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckName("Mushroom")]
    Mushroom = 0xC5,

    [Address(0xC6)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckName("Coconut")]
    Coconut = 0xC6,

    [Address(0xC7)]
    [CheckLocation("Destiny Islands")]
    [CheckRequirements(" Day1")]
    [CheckName("Drinking Water")]
    DrinkingWater = 0xC7,

    [Address(0xC8)]
    [CheckLocation("Wonderland")]
    [CheckRequirements(" Evidence")]
    [CheckName("Navi-G Piece 1")]
    NaviGPiece1 = 0xC8,

    [Address(0xC9)]
    [CheckLocation("Deep Jungle")]
    [CheckRequirements(" Slides")]
    [CheckName("Navi-G Piece 2")]
    NaviGPiece2 = 0xC9,

    [Address(0xCA)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Navi-Gummi Unused")]
    NaviGummiUnused = 0xCA,

    [Address(0xCB)]
    [CheckLocation("Traverse Town")]
    [CheckRequirements(" Red Trinity")]
    [CheckName("Navi-G Piece 3")]
    NaviGPiece3 = 0xCB,

    [Address(0xCC)]
    [CheckLocation("Neverland")]
    [CheckRequirements(" Green Trinity")]
    [CheckName("Navi-G Piece 4")]
    NaviGPiece4 = 0xCC,

    [Address(0xCD)]
    [CheckLocation("Traverse Town")]
    [CheckRequirements(" HB1")]
    [CheckName("Navi-Gummi")]
    NaviGummi = 0xCD,

    [Address(0xCE)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Watergleam")]
    Watergleam = 0xCE,

    [Address(0xCF)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Naturespark")]
    Naturespark = 0xCF,

    [Address(0xD0)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Fireglow")]
    Fireglow = 0xD0,

    [Address(0xD1)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Earthshine")]
    Earthshine = 0xD1,

    [Address(0xD2)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Crystal Trident")]
    CrystalTrident = 0xD2,

    [Address(0xD3)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Postcard")]
    Postcard = 0xD3,

    [Address(0xD4)]
    [CheckLocation("Dalmatians' House")]
    [CheckRequirements(" 51 Puppies")]
    [CheckName("Torn Page 1")]
    TornPage1 = 0xD4,

    [Address(0xD5)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Torn Page 2")]
    TornPage2 = 0xD5,

    [Address(0xD6)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Torn Page 3")]
    TornPage3 = 0xD6,

    [Address(0xD7)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Torn Page 4")]
    TornPage4 = 0xD7,

    [Address(0xD8)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Torn Page 5")]
    TornPage5 = 0xD8,

    [Address(0xD9)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 1")]
    Slide1 = 0xD9,

    [Address(0xDA)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 2")]
    Slide2 = 0xDA,

    [Address(0xDB)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 3")]
    Slide3 = 0xDB,

    [Address(0xDC)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 4")]
    Slide4 = 0xDC,

    [Address(0xDD)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 5")]
    Slide5 = 0xDD,

    [Address(0xDE)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Slide 6")]
    Slide6 = 0xDE,

    [Address(0xDF)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Footprints")]
    Footprints = 0xDF,

    [Address(0xE0)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Claw Marks")]
    ClawMarks = 0xE0,

    [Address(0xE1)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Stench")]
    Stench = 0xE1,

    [Address(0xE2)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Antenna")]
    Antenna = 0xE2,

    [Address(0xE3)]
    [CheckLocation("-")]
    [CheckRequirements(" Jack-In-The-Box")]
    [CheckName("Forget-Me-Not")]
    ForgetMeNot = 0xE3,

    [Address(0xE4)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("Jack-In-The-Box")]
    JackInTheBox = 0xE4,

    [Address(0xE5)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Entry Pass")]
    EntryPass = 0xE5,

    [Address(0xE6)]
    [CheckLocation("-")]
    [CheckRequirements(" Entry Pass")]
    [CheckName("Hero License")]
    HeroLicense = 0xE6,

    [Address(0xE7)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Pretty Stone")]
    PrettyStone = 0xE7,

    [Address(0xE8)]
    [CheckLocation("-")]
    [CheckRequirements(" -")]
    [CheckName("N41")]
    N41 = 0xE8,

    [Address(0xE9)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lucid Shard")]
    LucidShard = 0xE9,

    [Address(0xEA)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lucid Gem")]
    LucidGem = 0xEA,

    [Address(0xEB)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Lucid Crystal")]
    LucidCrystal = 0xEB,

    [Address(0xEC)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Spirit Shard")]
    SpiritShard = 0xEC,

    [Address(0xED)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Spirit Gem")]
    SpiritGem = 0xED,

    [Address(0xEE)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Shard")]
    PowerShard = 0xEE,

    [Address(0xEF)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Gem")]
    PowerGem = 0xEF,

    [Address(0xF0)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Power Crystal")]
    PowerCrystal = 0xF0,

    [Address(0xF1)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blaze Shard")]
    BlazeShard = 0xF1,

    [Address(0xF2)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Blaze Gem")]
    BlazeGem = 0xF2,

    [Address(0xF3)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Frost Shard")]
    FrostShard = 0xF3,

    [Address(0xF4)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Frost Gem")]
    FrostGem = 0xF4,

    [Address(0xF5)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thunder Shard")]
    ThunderShard = 0xF5,

    [Address(0xF6)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Thunder Gem")]
    ThunderGem = 0xF6,

    [Address(0xF7)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Shiny Crystal")]
    ShinyCrystal = 0xF7,

    [Address(0xF8)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Bright Shard")]
    BrightShard = 0xF8,

    [Address(0xF9)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Bright Gem")]
    BrightGem = 0xF9,

    [Address(0xFA)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Bright Crystal")]
    BrightCrystal = 0xFA,

    [Address(0xFB)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mystery Goo")]
    MysteryGoo = 0xFB,

    [Address(0xFC)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Gale")]
    Gale = 0xFC,

    [Address(0xFD)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mythril Shard")]
    MythrilShard = 0xFD,

    [Address(0xFE)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Mythril")]
    Mythril = 0xFE,

    [Address(0xFF)]
    [CheckLocation("-")]
    [CheckRequirements("")]
    [CheckName("Orichalcum")]
    Orichalcum = 0xFF,

        
    
}