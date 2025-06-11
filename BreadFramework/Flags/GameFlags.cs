using Ardalis.SmartEnum;

namespace BreadFramework.Flags;

public sealed class GameFlags : SmartEnum<GameFlags>
{
    public const int BaseOffset = 0x3A0606;

    public long Address { get; }
    public FlagType Type { get; }
    public FlagValueType ValueType { get; }
    public string Description { get; }

    private GameFlags(string name, int value, long address, FlagType type, FlagValueType valueType, string description)
        : base(name, value)
    {
        Address = address;
        Type = type;
        ValueType = valueType;
        Description = description;
    }

    // Battle and Main Tables
    public static readonly GameFlags BattleTable = new(
        nameof(BattleTable),
        0,
        0x2D1F3C0 - BaseOffset,
        FlagType.Table,
        FlagValueType.ByteArray,
        "Main battle system memory table"
    );

    public static readonly GameFlags WeaponTable = new(
        nameof(WeaponTable),
        1,
        0x2D1F3C0 - BaseOffset + 0x94F8,
        FlagType.Table,
        FlagValueType.ByteArray,
        "Weapon stats and properties table"
    );

    public static readonly GameFlags ItemTable = new(
        nameof(ItemTable),
        2,
        0x2D1F3C0 - BaseOffset + 0x1A58,
        FlagType.Table,
        FlagValueType.ByteArray,
        "Item properties table"
    );

    // Character Stats
    public static readonly GameFlags SoraStatTable = new(
        nameof(SoraStatTable),
        3,
        0x2D1F3C0 - BaseOffset + 0x3AC0,
        FlagType.Stats,
        FlagValueType.ByteArray,
        "Sora's base stats table"
    );

    public static readonly GameFlags DonaldStatTable = new(
        nameof(DonaldStatTable),
        4,
        0x2D1F3C0 - BaseOffset + 0x3AC0 + 0x3F8,
        FlagType.Stats,
        FlagValueType.ByteArray,
        "Donald's base stats table"
    );

    public static readonly GameFlags GoofyStatTable = new(
        nameof(GoofyStatTable),
        5,
        0x2D1F3C0 - BaseOffset + 0x3AC0 + 0x590,
        FlagType.Stats,
        FlagValueType.ByteArray,
        "Goofy's base stats table"
    );

    // Ability Tables
    public static readonly GameFlags SoraAbilityTable = new(
        nameof(SoraAbilityTable),
        6,
        0x2D1F3C0 - BaseOffset + 0x3BF8,
        FlagType.Ability,
        FlagValueType.ByteArray,
        "Sora's equipped abilities"
    );

    public static readonly GameFlags SoraAbilityTable2 = new(
        nameof(SoraAbilityTable2),
        7,
        0x2D1F3C0 - BaseOffset + 0x3B28,
        FlagType.Ability,
        FlagValueType.ByteArray,
        "Sora's learned abilities"
    );

    public static readonly GameFlags SoraAbilityTable3 = new(
        nameof(SoraAbilityTable3),
        8,
        0x2D1F3C0 - BaseOffset + 0x3B90,
        FlagType.Ability,
        FlagValueType.ByteArray,
        "Sora's available abilities"
    );

    public static readonly GameFlags DonaldAbilityTable = new(
        nameof(DonaldAbilityTable),
        9,
        0x2D1F3C0 - BaseOffset + 0x3F20,
        FlagType.Ability,
        FlagValueType.ByteArray,
        "Donald's ability table"
    );

    public static readonly GameFlags GoofyAbilityTable = new(
        nameof(GoofyAbilityTable),
        10,
        0x2D1F3C0 - BaseOffset + 0x40B8,
        FlagType.Ability,
        FlagValueType.ByteArray,
        "Goofy's ability table"
    );

    // Rewards and Treasures
    public static readonly GameFlags ChestTable = new(
        nameof(ChestTable),
        11,
        0x5259E0 - BaseOffset,
        FlagType.Table,
        FlagValueType.ByteArray,
        "Treasure chest contents table"
    );

    public static readonly GameFlags RewardTable = new(
        nameof(RewardTable),
        12,
        0x2D1F3C0 - BaseOffset + 0xC6A8,
        FlagType.Table,
        FlagValueType.ByteArray,
        "Trinity and special rewards table"
    );

    // Shop and Synthesis
    public static readonly GameFlags ShopTableBase = new(
        nameof(ShopTableBase),
        13,
        0x4FB374 - BaseOffset,
        FlagType.Shop,
        FlagValueType.ByteArray,
        "Shop inventory base table"
    );

    public static readonly GameFlags SynthRequirements = new(
        nameof(SynthRequirements),
        14,
        0x544320 - BaseOffset,
        FlagType.Synthesis,
        FlagValueType.ByteArray,
        "Synthesis item requirements"
    );

    public static readonly GameFlags SynthItems = new(
        nameof(SynthItems),
        15,
        0x544500 - BaseOffset,
        FlagType.Synthesis,
        FlagValueType.ByteArray,
        "Synthesis items table"
    );

    // Progress and Collection
    public static readonly GameFlags ChestsOpened = new(
        nameof(ChestsOpened),
        16,
        0x2DE5E00 - BaseOffset,
        FlagType.Progress,
        FlagValueType.ByteArray,
        "Opened chests bitfield"
    );

    public static readonly GameFlags SummonsReturned = new(
        nameof(SummonsReturned),
        17,
        0x2DE66FC - BaseOffset,
        FlagType.Progress,
        FlagValueType.ByteArray,
        "Returned summon gems status"
    );

    public static readonly GameFlags Summons = new(
        nameof(Summons),
        18,
        0x2DE61A0 - BaseOffset,
        FlagType.Progress,
        FlagValueType.ByteArray,
        "Available summons"
    );

    public static readonly GameFlags Inventory = new(
        nameof(Inventory),
        19,
        0x2DE5E6A - BaseOffset,
        FlagType.Inventory,
        FlagValueType.ByteArray,
        "Player inventory"
    );

    // World Progress
    public static readonly GameFlags WorldWarps = new(
        nameof(WorldWarps),
        20,
        0x50B940 - BaseOffset,
        FlagType.World,
        FlagValueType.ByteArray,
        "World warp points"
    );

    public static readonly GameFlags WorldFlagBase = new(
        nameof(WorldFlagBase),
        21,
        0x2DE7A3C - BaseOffset,
        FlagType.World,
        FlagValueType.ByteArray,
        "World progress flags"
    );

    public static readonly GameFlags BattleLevel = new(
        nameof(BattleLevel),
        22,
        0x2DE7394 - BaseOffset,
        FlagType.Progress,
        FlagValueType.Byte,
        "Current battle/difficulty level"
    );

    public static readonly GameFlags UnlockedWarps = new(
        nameof(UnlockedWarps),
        23,
        0x2DE78D6 - BaseOffset,
        FlagType.World,
        FlagValueType.ByteArray,
        "Unlocked warp points"
    );

    // System and Special States
    public static readonly GameFlags MinigameStatus = new(
        nameof(MinigameStatus),
        24,
        0x2DE73A5 - BaseOffset,
        FlagType.System,
        FlagValueType.Byte,
        "Minigame status flags"
    );

    public static readonly GameFlags GummiInventory = new(
        nameof(GummiInventory),
        25,
        0x2DF1848 - BaseOffset,
        FlagType.Inventory,
        FlagValueType.ByteArray,
        "Gummi ship inventory"
    );

    public static readonly GameFlags Reports = new(
        nameof(Reports),
        26,
        0x2DE7390 - BaseOffset,
        FlagType.Progress,
        FlagValueType.ByteArray,
        "Ansem reports collected"
    );

    public static readonly GameFlags SpeedUp = new(
        nameof(SpeedUp),
        27,
        0x233C24C - BaseOffset,
        FlagType.System,
        FlagValueType.Float,
        "Game speed multiplier"
    );

    public static readonly GameFlags TutorialFlag = new(
        nameof(TutorialFlag),
        28,
        0x2DE7394 - BaseOffset,
        FlagType.System,
        FlagValueType.Byte,
        "Tutorial state flags"
    );
    
    public static readonly GameFlags DodgeRollSpeed = new(
        nameof(DodgeRollSpeed),
        86,
        0x4, // Just the offset since base is handled dynamically
        FlagType.Combat,
        FlagValueType.Short,
        "Dodge Roll Speed/Duration (lower = faster)"
    );
    
    public static readonly GameFlags GlideSpeed = new(
        nameof(GlideSpeed),
        88,
        0x2AE2B4 - BaseOffset,  // Base offset for glide speed
        FlagType.Ability,
        FlagValueType.Int,  // Using Int since WriteInt is used in the code
        "Glide Movement Speed"
    );
    
    public static readonly GameFlags JumpHeight = new(
        nameof(JumpHeight),
        89,
        0x2D1F46C - BaseOffset,  // Base offset for glide speed
        FlagType.Ability,
        FlagValueType.Int,  // Using Int since WriteInt is used in the code
        "Jump Height"
    );




    // Camera related flags
    public static readonly GameFlags GameState = new(nameof(GameState), 29, 0x2863958, FlagType.System,
        FlagValueType.Int, "Game State");

    public static readonly GameFlags CameraAcceleration = new(nameof(CameraAcceleration), 30, 0x3E7F58, FlagType.Camera,
        FlagValueType.Float, "Camera Acceleration Flag");

    public static readonly GameFlags CameraDeceleration = new(nameof(CameraDeceleration), 31, 0x3E7F5C, FlagType.Camera,
        FlagValueType.Float, "Camera Deceleration Flag");

    public static readonly GameFlags CameraCurrentSpeedV = new(nameof(CameraCurrentSpeedV), 32, 0x25344C0,
        FlagType.Camera, FlagValueType.Float, "Current Vertical Camera Speed");

    public static readonly GameFlags CameraCurrentSpeedH = new(nameof(CameraCurrentSpeedH), 33, 0x25344C4,
        FlagType.Camera, FlagValueType.Float, "Current Horizontal Camera Speed");

    public static readonly GameFlags CameraInputH = new(nameof(CameraInputH), 34, 0x233D060, FlagType.Camera,
        FlagValueType.Float, "Camera Input Horizontal");

    public static readonly GameFlags CameraInputV = new(nameof(CameraInputV), 35, 0x233D064, FlagType.Camera,
        FlagValueType.Float, "Camera Input Vertical");

    public static readonly GameFlags CameraCenter = new(nameof(CameraCenter), 36, 0x2534724, FlagType.Camera,
        FlagValueType.Float, "Camera Center");

    public static readonly GameFlags CameraSnap = new(nameof(CameraSnap), 37, 0x1DD299, FlagType.Camera,
        FlagValueType.Float, "Camera Snap");

    public static readonly GameFlags CameraAccelerationHack = new(nameof(CameraAccelerationHack), 38, 0x1E2924,
        FlagType.Camera, FlagValueType.Float, "Camera Acceleration Hack");

    public static readonly GameFlags CameraDecelerationHack = new(nameof(CameraDecelerationHack), 39, 0x1E291B,
        FlagType.Camera, FlagValueType.Float, "Camera Deceleration Hack");

    public static readonly GameFlags CameraSpeed = new(nameof(CameraSpeed), 40, 0x503A1C, FlagType.Camera,
        FlagValueType.Float, "Camera Speed");

    public static readonly GameFlags CameraBase = new(nameof(CameraBase), 41, 0x503A18, FlagType.Camera,
        FlagValueType.ByteArray, "Camera Base");

    // UI and Menu flags
    public static readonly GameFlags MenuOpen = new(nameof(MenuOpen), 42, 0x232A600, FlagType.UI, FlagValueType.Bool,
        "Is the Menu Open");

    public static readonly GameFlags SoraHud = new(nameof(SoraHud), 43, 0x280EB1C, FlagType.UI, FlagValueType.Bool,
        "Sora HUD on screen");

    public static readonly GameFlags SaveMenuOpen = new(nameof(SaveMenuOpen), 44, 0x232A604, FlagType.UI,
        FlagValueType.Bool, "Is the Save Menu Open");

    public static readonly GameFlags CloseMenu = new(nameof(CloseMenu), 45, 0x2E90820, FlagType.UI,
        FlagValueType.ByteArray, "Close Menu");

    // Location and Event flags
    public static readonly GameFlags WorldId = new(nameof(WorldId), 46, 0x233CADC, FlagType.World, FlagValueType.Int,
        "World Id");

    public static readonly GameFlags RoomId = new(nameof(RoomId), 47, 0x233CB44, FlagType.World, FlagValueType.Int,
        "Room Id");

    public static readonly GameFlags EventId = new(nameof(EventId), 48, 0x233CB48, FlagType.World, FlagValueType.Int,
        "Event Id");

    // Character and World related flags
    public static readonly GameFlags SoraHp = new(nameof(SoraHp), 65, 0x2D592CC, FlagType.Character, FlagValueType.Int,
        "Sora's HP");

    public static readonly GameFlags WorldSelection = new(nameof(WorldSelection), 66, 0x503CEC, FlagType.World,
        FlagValueType.Int, "World Selection");

    public static readonly GameFlags WorldWarpBase = new(nameof(WorldWarpBase), 67, 0x50B940, FlagType.World,
        FlagValueType.Int, "World Warp Base");

    // Cutscene and Progress flags
    public static readonly GameFlags CutsceneFlagBase = new(nameof(CutsceneFlagBase), 68, 0x2DE65D0 - 0x200,
        FlagType.System, FlagValueType.Int, "Cutscene Flag Base");

    public static readonly GameFlags DjProgressFlag = new(nameof(DjProgressFlag), 69, 0x2DE79D0 + 0x6C + 0x40,
        FlagType.Progress, FlagValueType.Int, "Deep Jungle Progress Flag");

    public static readonly GameFlags NeverlandProgressFlag = new(nameof(NeverlandProgressFlag), 70,
        0x2DE79D0 + 0x6C + 0xED, FlagType.Progress, FlagValueType.Int, "Neverland Progress Flag");

    // Combat and Ability related flags
    public static readonly GameFlags GravityBreakHack = new(nameof(GravityBreakHack), 71, 0x3EA148, FlagType.Combat,
        FlagValueType.Float, "Gravity Break Hack");

    public static readonly GameFlags ZantetsukenHack = new(nameof(ZantetsukenHack), 72, 0x2A2804 + 4, FlagType.Combat,
        FlagValueType.Byte, "Zantetsuken Hack");

    public static readonly GameFlags OpenMenuInCombat = new(nameof(OpenMenuInCombat), 73, 0x17A81A, FlagType.Combat,
        FlagValueType.ByteArray, "Open Menu in Combat");

    // Interaction flags
    public static readonly GameFlags TalkRequirement = new(nameof(TalkRequirement), 74, 0x2903F9, FlagType.Interaction,
        FlagValueType.ByteArray, "Can Talk Requirement");

    public static readonly GameFlags ChestOpenRequirement = new(nameof(ChestOpenRequirement), 75, 0x2B12C4,
        FlagType.Interaction, FlagValueType.ByteArray, "Open Chest Requirement");

    public static readonly GameFlags TrinityRequirement = new(nameof(TrinityRequirement), 76, 0x1A06CF,
        FlagType.Interaction, FlagValueType.ByteArray, "Activate Trinity Requirement");

    public static readonly GameFlags ExamineRequirement = new(nameof(ExamineRequirement), 77, 0x2903B9,
        FlagType.Interaction, FlagValueType.ByteArray, "Can Examine Requirement");

    // System and UI flags
    public static readonly GameFlags OverworldMessageFlag = new(nameof(OverworldMessageFlag), 78, 0x2DE78E9,
        FlagType.UI, FlagValueType.ByteArray, "World Map Messages");

    public static readonly GameFlags CutsceneSkippable = new(nameof(CutsceneSkippable), 79, 0x23944E4, FlagType.System,
        FlagValueType.Int, "Is Cutscene Skippable");

    public static readonly GameFlags InCutscene = new(nameof(InCutscene), 80, 0x2378B60, FlagType.System,
        FlagValueType.Int, "In Cutscene");

    public static readonly GameFlags FramerateHack = new(nameof(FramerateHack), 81, 0x233C24C, FlagType.System,
        FlagValueType.Float, "Framerate Hack");

    public static readonly GameFlags Summoning = new(nameof(Summoning), 82, 0x2D5D62C, FlagType.Combat,
        FlagValueType.Int, "Summoning");

    // Text related flags
    public static readonly GameFlags TextBoxProgression = new(nameof(TextBoxProgression), 83, 0x232A5F4, FlagType.UI,
        FlagValueType.Int, "Text Box Progression");

    public static readonly GameFlags TextBoxTransition = new(nameof(TextBoxTransition), 84, 0x232A5F4, FlagType.UI,
        FlagValueType.Float, "Text Box Transition");

    public static readonly GameFlags TextBoxSpeed = new(nameof(TextBoxSpeed), 85, 0x233C25C, FlagType.UI,
        FlagValueType.Float, "Text Box Speed");

    // Input related flags
    public static readonly GameFlags ButtonPress = new(nameof(ButtonPress), 49, 0x233D034, FlagType.Input,
        FlagValueType.Int, "Buttons Pressed Value");

    public static readonly GameFlags ShoulderPress = new(nameof(ShoulderPress), 50, 0x233D035, FlagType.Input,
        FlagValueType.Int, "Shoulder Buttons Pressed Value");

    // Warp related flags
    public static readonly GameFlags WarpRequirement1 = new(nameof(WarpRequirement1), 51, 0x22E86E0, FlagType.World,
        FlagValueType.Int, "Warp Requirement 1");

    public static readonly GameFlags WarpRequirement2 = new(nameof(WarpRequirement2), 52, 0x233C240, FlagType.World,
        FlagValueType.Int, "Warp Requirement 2");

    public static readonly GameFlags LastUsedOverworldMap = new(nameof(LastUsedOverworldMap), 53, 0x233CB68,
        FlagType.World, FlagValueType.Int, "Last Used Overworld Map");

    public static readonly GameFlags WarpTrigger =
        new(nameof(WarpTrigger), 54, 0x22E86DC, FlagType.World, FlagValueType.Int, "Warp Trigger");

    // Death related flags
    public static readonly GameFlags DeathCheck = new(nameof(DeathCheck), 55, 0x2978E0, FlagType.System,
        FlagValueType.Int, "Death Check");

    public static readonly GameFlags DeathCheckAlternate = new(nameof(DeathCheckAlternate), 56, 0x2978E0 - 0x1C0,
        FlagType.System, FlagValueType.Int, "Death Check Alternate(JP)");

    public static readonly GameFlags DeathPointer = new(nameof(DeathPointer), 57, 0x23944B8, FlagType.System,
        FlagValueType.Int, "Death Pointer");

    public static readonly GameFlags DeathSafetyMeasure = new(nameof(DeathSafetyMeasure), 58, 0x297746, FlagType.System,
        FlagValueType.Int, "Death Safety Measure");

    public static readonly GameFlags DeathSafetyMeasureAlternate = new(nameof(DeathSafetyMeasureAlternate), 59,
        0x297746 - 0x1C0, FlagType.System, FlagValueType.Int, "Death Safety Measure Alternate(JP)");

    // System and UI flags
    public static readonly GameFlags Continue = new(nameof(Continue), 60, 0x2DFC5D0, FlagType.System,
        FlagValueType.ByteArray, "Continue Flag");

    public static readonly GameFlags Config = new(nameof(Config), 61, 0x2DFBDD0, FlagType.UI, FlagValueType.ByteArray,
        "Config Menu");

    public static readonly GameFlags Title = new(nameof(Title), 62, 0x233CAB8, FlagType.UI, FlagValueType.ByteArray,
        "Title Screen");

    // Visual effect flags
    public static readonly GameFlags WhiteFade = new(nameof(WhiteFade), 63, 0x233C49C, FlagType.Visual,
        FlagValueType.ByteArray, "White Fade");

    public static readonly GameFlags BlackFade = new(nameof(BlackFade), 64, 0x4D93B8, FlagType.Visual,
        FlagValueType.ByteArray, "Black Fade");
}