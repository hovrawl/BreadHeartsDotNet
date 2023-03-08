using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using KHData.Flags;
using KHData.Items;
using KHData.Worlds;
using Memory;
using Newtonsoft.Json;

namespace KHEngine.Modules;

public class RandomItemsModule : BaseModule
{
    #region Flags

    private GameFlag BtlTbl;
    private GameFlag ItemTable;
    private GameFlag WeaponTable;
    private GameFlag SoraStatTable;
    private GameFlag DonaldStatTable;
    private GameFlag GoofyStatTable;
    private GameFlag SoraAbilityTable;
    private GameFlag SoraAbilityTable2;
    private GameFlag SoraAbilityTable3;
    private GameFlag DonaldAbilityTable;
    private GameFlag GoofyAbilityTable;
    private GameFlag RewardTable;
    private GameFlag ChestTable;
    private GameFlag ShopTableBase;
    private GameFlag SynthRequirements;
    private GameFlag SynthItems;
    
    private GameFlag ChestsOpened;
    private GameFlag SummonsReturned;
    private GameFlag Summon;
    private GameFlag Inventory;
    private GameFlag TornPageCount;
    private GameFlag PoohProgress;
    private GameFlag PoohProgress2;
    private GameFlag EmblemCount;
    private GameFlag Slides;
    private GameFlag SlidesActive;
    private GameFlag Evidence;
    private GameFlag EvidenceActiveForest;
    private GameFlag EvidenceActiveBizarre;
    private GameFlag KhamaActive;
    private GameFlag TheonActive;
    private GameFlag EmblemDoor;
    private GameFlag MinigameStatus;
    private GameFlag GummiInventory;
    private GameFlag Reports;
    
    private GameFlag WorldWarps;
    private GameFlag WorldFlagBase;
    private GameFlag GummiFlagBase;
    private GameFlag WorldMapLines;
    private GameFlag GummiSelect;
    private GameFlag InGummi;
    private GameFlag BattleLevel;
    private GameFlag UnlockedWarps;
    private GameFlag WarpCount;
    private GameFlag CutsceneFlags;
    private GameFlag LibraryFlag;
    private GameFlag ScriptPointer;
    private GameFlag OCCupUnlock;
    private GameFlag OCCupDialog;
    private GameFlag ArdOffset;
    private GameFlag ArdOffsetClock;
    private GameFlag TextBox;
    private GameFlag CupCurrentSeed;
    private GameFlag WaterwayGate;
    private GameFlag WaterwayTrinity;
    private GameFlag CurrentTerminus;
    private GameFlag TerminusTeleUsable;
    private GameFlag TerminusTeleVisible;
    private GameFlag Speedup;
    private GameFlag SliderProgress;
    private GameFlag SavedFruits;
    private GameFlag MinigameTimer;
    private GameFlag CollectedFruits;
    private GameFlag UnequipBlacklist;
    private GameFlag TutorialFlag;
    private GameFlag OppositeState;
    private GameFlag OppositeTrigger;
    
    private GameFlag Chronicles;
    private GameFlag JournalCharacters;
    
    private GameFlag InfoBoxNotVisible;
    private GameFlag PreventMenu;
    private GameFlag BlackFade;
    private GameFlag EnableRc;
    private GameFlag LockMenu;
    private GameFlag Party1;
    private GameFlag Party2;
    private GameFlag SoraHUD;
    private GameFlag StateFlag;
    private GameFlag MagicUnlock;
    private GameFlag MagicLevels;
    private GameFlag MagicFlags;
    private GameFlag Shortcuts;
    private GameFlag TrinityUnlock;
    private GameFlag World;
    private GameFlag Room;
    private GameFlag SoraCurAbilities;
    private GameFlag SharedAbilties;
    private GameFlag SoraPointer;
    private GameFlag SoraJumpHeight;
    private GameFlag JumpHeight;
    private GameFlag MermaidKickSpeed;
    private GameFlag SoraHp;
    private GameFlag SuperGlideSpeedHack;
    
    private GameFlag SoraStats;
    private GameFlag DonaldStats;
    private GameFlag GoofyStats;
    private GameFlag ExerienceMult;
    
    private GameFlag GoToWorldMap;
    private GameFlag StartGameWarpHack;
    private GameFlag WorldMapTriggerFlag;
    private GameFlag OpenMenu;
    private GameFlag MenuCheck;
    private GameFlag Input;
    private GameFlag MenuState;
    private GameFlag Report1;
    private GameFlag Language;
    private GameFlag WorldWarp;
    private GameFlag RoomWarp;
    private GameFlag RoomWarpRead;
    private GameFlag WarpTrigger;
    private GameFlag WarpType1;
    private GameFlag WarpType2;
    private GameFlag WarpDefinitions;
    private GameFlag RCName;
    
    private GameFlag ItemDropId;
    private GameFlag TextsBase;
    private GameFlag TextPointerBase;


    #endregion
    
    public int TextPos = 0;
    public int IdFind = 0;
    public int IdReplace = 0;
    public string TextFind = "";
    public string NextTextFind = "";
    public string TextReplace = "";
    public string NextTextReplace = "";
    public List<string> MagicTexts = new() { "fire.", "ice.", "thunder.", "healing.", "stars.", "time.", "wind." };
    public List<string> MagicTexts2 = new() { "Fire", "Blizzard", "Thunder", "Cure", "Gravity", "Stop", "Aero" };
    public List<string> TrinityTexts = new() { "Blue Trinity", "Red Trinity", "Green Trinity", "Yellow Trinity", "White Trinity" };
    public List<string> AbilityNames = new() { "High Jump", "Mermaid Kick", "Glide", "Superglide" };
    public int InfoBoxWas = 0;

    
    public List<int> TrinityTable = new ();
    public List<int> MagicShuffled = new ();
    public List<int> PerMagicShuffle = new ();
    public List<int> InventoryUpdater = new ();
    public List<int> GummiUpdate = new ();
    public List<int> SliderSavedProg = new () { 0, 0, 0, 0, 0 };
    public int DodgeDataAddr = 0;
    public int ReportUpdater = 0;
    public int BufferRemove = 0;
    public int BufferRemoveTimer = 10;
    public int HUDWas = 0;
    public int MenuWas = 0;
    public int RemoveBlackTimer = 0;
    public int PrevBlack = 128;
    public int PrevWorld = 0;
    public int PrevRoom = 0;
    public int PrevTTFlag = 0;
    public int OCTextFix = 0;
    public bool IntroJump = true;
    
    
    public List<int> Important = new () { 0xBC, 0xBD, 0xBE, 0xBF, 0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7, 0xCD, 0xE5 };
    public List<int> ShopPool = new ();
    public List<string> GummiNames = new ();
    public Dictionary<int, List<string>> ItemNames = new ();
    public Dictionary<int, List<string>> ChestDetails = new ();
    public Dictionary<int, List<string>> RewardDetails = new ();
    public List<string> VanillaChests = new ();
    public List<string> VanillaRewards = new ();
    public List<string> ItemIds = new ();
    public List<string> Rewards = new ();
    public List<string> SoraLevels = new();
    public List<string> SoraAbilities = new();
    public List<string> SoraAbilities2 = new();
    public List<string> SoraAbilities3 = new();
    public List<string> DonaldLevels = new();
    public List<string> DonaldAbilities = new();
    public List<string> GoofyLevels = new();
    public List<string> GoofyAbilities = new();
    public List<string> WeaponStr = new();
    public List<string> WeaponMag = new();
    public List<string> ItemData = new();
    public List<string> Shops = new();
    public List<string> Synths = new();
    public List<string> Chests = new();
    public Dictionary<int, int> ItemsAvailable = new();
    public Dictionary<int, int> AbilitiesAvailable = new();
    public Dictionary<int, int> MagicAvailable = new();
    public List<string> ReportData = new();
    public int DalmatiansAvailable = 0;
    public string SeedString = "";
    public bool Randomized = false;
    public bool SuccessfulRando = true;
    public bool IsValidSeed = false;
    public bool InitDone = false;
    public int InfiniteDetection = 0;
    public bool canExecute = false;
    
    public List<int> ChecksDebug = new();
    public List<int> ChecksDebug2 = new();
    public Dictionary<string, int> Sets = new();

    public override string Author => "Original Script By Denhonator";
    
    public override string Name => "Random Items";

    public override string Description => "Randomise the items in game. Can be configured";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;

        // Load ID's
        var gummisTextPath = "randofiles/gummis.txt";
        if (!File.Exists(gummisTextPath))
        {
            // Error Log - gummis.txt missing!
        }
        else
        {
            var gummiLines = File.ReadAllLines(gummisTextPath);
            ChestDetails = LoadRewards("randofiles/Chests.txt", 1);
            RewardDetails = LoadRewards("randofiles/Rewards.txt", 1);
            ItemNames = LoadRewards("randofiles/items.txt", 0);
        }

        Sets["RequiredSlides"] = 0;
        Sets["RequiredEvidence"] = 0;
        
        var settingsPath = "randofiles/settings.txt";
        if (!File.Exists(settingsPath))
        {
            // Error Log - settings.txt missing!
        }
        else
        {
            var settingsString = File.ReadAllText(settingsPath);
            var settings = JsonConvert.DeserializeObject<RandoSettings>(settingsString);
            
        }

        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        
    }

    #region Helpers
    private List<byte> ReadArray(int offset, int c)
    {
        var returnArray = new List<byte>();
        for (int i = 1; i < c; i ++)
        {
            returnArray.Add(KhEngine.ReadByte(offset + (i - 1)));
        }

        return returnArray;
    }
    
    private void WriteArray(int offset, int c, List<byte> array)
    {
        for (int i = 1; i < c; i ++)
        {
            KhEngine.WriteByte(offset + (i - 1), array[i]);
        }
    }

    
    private Dictionary<int, List<string>> LoadRewards(string filePath, int offset)
    {
        var detailsTable = new Dictionary<int, List<string>>();
        if (!File.Exists(filePath))
        {
            return detailsTable;
        }
        var rewardsLines = File.ReadAllLines(filePath);
        foreach (var rewardLine in rewardsLines)
        {
            if (rewardLine.Contains("?"))
            {
                continue;
            }

            if (!int.TryParse(rewardLine.Substring(1, 3), out var chestId))
            {
                continue;
            }

            chestId = chestId + offset;

            var rewardDetailsLine = rewardLine.Substring(5);
            var details = new List<string>();
            var wordsRegex = new Regex("([^;]+)");
            var subRegex = new Regex("^%s*(.-)%s*$");
            var words = wordsRegex.Matches(rewardDetailsLine);
            
            foreach (Match wordMatch in words)
            {
                var word = wordMatch.Value;
                var subWord = subRegex.Replace(word, "%1");
                details.Add(subWord);
            }

            detailsTable.Add(chestId, details);
        }

        
        return detailsTable;
    }

    /// <summary>
    /// Get attributes describing and item
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private List<ItemType> GetItemTypes(int i)
    {
        var attributes = new List<ItemType>();

        if ((i >= 1 && i <= 8 && i != 5) || (i >= 0x98 && i <= 0x9A) || (i >= 0x8E && i <= 0x90))
        {
            attributes.Add(ItemType.Use);
        }
        if ((i >= 9 && i <= 0x10) || (i >= 0x9))
        {
            attributes.Add(ItemType.Synth);
        }
        if ((i >= 0x11 && i <= 0x47) || (i != 0x39))
        {
            attributes.Add(ItemType.Accessory);
        }
        if (i >= 0x51 && i <= 0x66)
        {
            attributes.Add(ItemType.SoraWeapon);
        }
        if (i >= 0x67 && i <= 0x75)
        {
            attributes.Add(ItemType.DonaldWeapon);
        }
        if (i >= 0x77 && i <= 0x85)
        {
            attributes.Add(ItemType.GoofyWeapon);
        }
        if ((i >= 0xCe && i <= 0xD1) || i == 0x89 || i == 0x8C)
        {
            attributes.Add(ItemType.Summon);
        }
        if (i >= 0xD9 && i <= 0xDE)
        {
            attributes.Add(ItemType.Slide);
        }
        if (i >= 0xDF && i <= 0xE2)
        {
            attributes.Add(ItemType.Evidence);
        }
        if (i == 0xB2 || i == 0xB7)
        {
            attributes.Add(ItemType.Book);
        }
        if (i == 0xE3 || i == 0xE6 || i == 0xD2 || i == 0xA8 || i == 0xAA || 
            i == 0xAE || i == 0xB0 || i == 0xC8 || i == 0xC9 || i == 0xCB || i == 0xCC) 
        {
            attributes.Add(ItemType.NonImportant);
        }

        foreach (var importantItem in Important)
        {
            if (importantItem == i)
            {
                attributes.Add(ItemType.Important);
            }
        }
        return attributes;
    }

    /// <summary>
    /// Compare two items to see if they are compatible
    /// </summary>
    /// <param name="i"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    private bool ItemCompatibility(int i, int r)
    {
        var returnBool = true;
        var a = GetItemTypes(i);
        var b = GetItemTypes(r);
        var weaponCheck = new List<ItemType> { ItemType.DonaldWeapon, ItemType.SoraWeapon,ItemType.GoofyWeapon }; 
        var useSynthCheck = new List<ItemType> { ItemType.Use, ItemType.Synth }; 
        var accessoryCheck = new List<ItemType> { ItemType.Accessory }; 
        var summonCheck = new List<ItemType> { ItemType.Summon }; 
        
        if (a.Any(i => weaponCheck.Contains(i)) || b.Any(i => weaponCheck.Contains(i)) )
        {
            return a == b;
        }
        if (a.Any(i => useSynthCheck.Contains(i)) || b.Any(i => useSynthCheck.Contains(i)) )
        {
            return a == b;
        }
        if (a.Any(i => accessoryCheck.Contains(i)) || b.Any(i => accessoryCheck.Contains(i)) )
        {
            return true;
        }
        if (a.Any(i => summonCheck.Contains(i)) && b.Any(i => summonCheck.Contains(i)) )
        {
            return true;
        }
        
        return returnBool;
    }

    private bool Salable(int i)
    {
        return i < 0xB2 || i == 0xD2 || i >= 0xE6;
    }

    /// <summary>
    /// Simple string hashing algorithm designed by Daniel J. Bernstein
    /// </summary>
    /// <param name="str">string to hash</param>
    /// <returns></returns>
    private string Djb2(string str)
    {
        var hash = 5381;

        foreach(var strChar in str)
        {
            hash = (hash << 5) + strChar.GetHashCode();
        }
        
        return hash.ToString();
    }

    /// <summary>
    /// Is the specified item accessible/obtained
    /// </summary>
    /// <param name="i">Item address</param>
    /// <param name="c">Item count</param>
    /// <returns></returns>
    private bool ItemAccessible(int i, int c)
    {
        return ItemsAvailable.ContainsKey(i) && ItemsAvailable[i] >= c;
    }
    
    /// <summary>
    /// Is the specified ability accessible/obtained
    /// </summary>
    /// <param name="i">Ability address</param>
    /// <param name="c">Ability count</param>
    /// <returns></returns>
    private bool AbilityAccessible(int i, int c)
    {
        return AbilitiesAvailable.ContainsKey(i) && AbilitiesAvailable[i] >= c;
    }

    /// <summary>
    /// Is the specified Trinity accessible
    /// </summary>
    /// <param name="s">The trinity to check</param>
    /// <returns></returns>
    private bool TrinityAccessible(string s)
    {
        var accessible = true;
        var i = 1;
        while (i <= 5)
        {
            if (TrinityTexts[i] == s)
            {
                if (TrinityTable[2] == i)
                {
                    accessible = ItemAccessible(0xD9, 6);
                    break;
                } 
                else if (TrinityTable[4] == i)
                {
                    accessible = ItemAccessible(0xE5, 1);
                    break;
                }
            }
            i++;
        }

        return accessible;
    }

    /// <summary>
    /// Is the specified Magic accessible
    /// </summary>
    /// <param name="s">The magic to check</param>
    /// <returns></returns>
    private bool MagicAccessible(string s)
    {
        if (!MagicAvailable.Any())
        {
            return false;
        }

        var magicRef = new List<string> { "Fire", "Blizzard", "Thunder", "Cure", "Gravity", "Stop", "Aero" };
        var magicRef2 = new List<string> { "Fira", "Blizzara", "Thundera", "Cura", "Gravira", "Stopra", "Aerora" };
        var magicRef3 = new List<string> { "Firaga", "Blizzaga", "Thundaga", "Curaga", "Graviga", "Stopga", "Aeroga" };
        
        var accessible = true;

        var i = 1;
        while (i <= magicRef.Count)
        {
            if (s.Contains(magicRef3[i]) || s.Equals("Max", StringComparison.CurrentCultureIgnoreCase))
            {
                accessible = accessible && MagicAvailable[i] > 2;
            }
            else if (s.Contains(magicRef2[i]))
            {
                accessible = accessible && MagicAvailable[i] > 1;
            }
            else if (s.Contains(magicRef[i]) || s.Equals("All", StringComparison.CurrentCultureIgnoreCase))
            {
                accessible = accessible && MagicAvailable[i] > 0;
            }
            i++;
        } 


        return accessible;
    }

    private bool IsAccessible(int t, int i)
    {
        var accessible = true;

        for (int k = 3; k <= 6; k++)
        {
            // if (t[i][k])
            // {
            //     break;
            // }
        }

        return accessible;
    }
    
    #endregion
    
    #region Module Classes
    public class RandoSettings
    {
        /// <summary>
        /// Prevent select key items from being randomized
        /// Item IDs are listed in items.txt
        /// Available options: BC, BD, BE, BF, C0, C1, C2, C3, C4, C5, C6, C7, CD, E5
        /// For example, if you want to unrandomize Entry Pass and Navi-Gummi:
        /// Unrandomize = [ CD, E5 ]
        /// </summary>
        public List<GameFlag> Unrandomize { get; set; }

        /// <summary>
        /// Define how many slides are required to progress Deep Jungle.
        /// All 6 slides will be randomized and accessible regardless.
        /// Slides must be picked up in Deep Jungle after meeting the condition, and must be picked up to progress.
        /// This is to avoid rare softlocks that happened previously.
        /// </summary>
        public int RequiredSlides { get; set; } = 1;
        
        /// <summary>
        /// Define how many evidence is required to progress Wonderland.
        /// All 4 evidence will be randomized and accessible regardless.
        /// This is to avoid rare softlocks that happened previously.
        /// Evidence also becomes available for pick up after meeting condition, but is unnecessary to pick up.
        /// </summary>
        public int RequiredEvidence { get; set; } = 1;
        
        /// <summary>
        /// If you want guaranteed abilities on first level ups, put the hex codes for unequipped abilities here.
        /// Maximum 4 or they will replace other abilities.
        /// Find ability codes here https://pastebin.com/ZH0L3XXi
        /// Scroll down for the Not Equipped versions.
        /// For example, early scan and dodge roll would be:
        /// EarlyAbilities = [ 8A, 96 ]
        /// </summary>
        public List<int> EarlyAbilities { get; set; }

        /// <summary>
        /// Determines how weapon stats will be randomized
        /// </summary>
        public WeaponStatRando WeaponStatRando { get; set; } = WeaponStatRando.Shuffle;
        
        /// <summary>
        /// Stack abilities. Currently, you can sometimes get duplicate abilities.
        /// </summary>
        public StackAbilities StackAbilities { get; set; } = StackAbilities.All;

        /// <summary>
        /// Allow warping with SaveAnywhere
        /// Warping at inopportune times can lead to crashes, audio bugs, softlocks or other issues with story progression
        /// Use at your own responsibility
        /// </summary>
        public WarpAnywhere WarpAnywhere { get; set; } = WarpAnywhere.SavePoint;

        /// <summary>
        /// HB2 unlocks EotW World Terminus warp
        /// Allows skipping a large portion of End of the World
        /// Still requires Navi Gummi as usual, so only speeds things up after necessary items have been found
        /// </summary>
        public bool EndOfTheWorldSkip { get; set; } = true;

        /// <summary>
        /// Shop randomization
        /// </summary>
        public RandomShops ShopRandomization { get; set; } = RandomShops.KeyItems;
        
        /// <summary>
        /// Unrandomize rewards.
        /// List the reward IDs from Rewards.txt that you want to unrandomize
        /// Items in list will be kept vanilla
        /// </summary>
        public List<GameFlag> VanillaRewards { get; set; }
        
        /// <summary>
        /// Unrandomize rewards
        /// List the reward IDs from Rewards.txt that you want to unrandomize
        /// Items in list will have a potion put in and keep the reward in the pool
        /// </summary>
        public List<GameFlag> ReplaceRewards { get; set; }
        
        /// <summary>
        /// Unrandomize rewards.
        /// List the chest IDs from Chests.txt that you want to unrandomize
        /// Items in list will be kept vanilla
        /// However note that if the chest contains a reward, you should unrandomize that reward as well,
        /// else whatever ends up on that reward will be inaccessible
        /// </summary>
        public List<GameFlag> VanillaChests { get; set; }
        
        /// <summary>
        /// Unrandomize chests
        /// List the chest IDs from Chests.txt that you want to unrandomize
        /// Items in list will have a potion put in and keep the reward in the pool
        /// However note that if the chest contains a reward, you should unrandomize that reward as well,
        /// else whatever ends up on that reward will be inaccessible
        /// </summary>
        public List<GameFlag> ReplaceChests { get; set; }
        
    }

    public enum WeaponStatRando
    {
        /// <summary>
        /// Not at all
        /// </summary>
        None = 0,
        /// <summary>
        /// Weak weapons buffed
        /// </summary>
        Weak = 1,
        /// <summary>
        /// Stats shuffled between keyblades (str and magic only)
        /// </summary>
        Shuffle = 2,
        /// <summary>
        /// Stats shuffled and weak stats buffed
        /// </summary>
        BuffedShuffle = 3,
    }
    
    public enum StackAbilities
    {
        /// <summary>
        /// No stacking. Vanilla. You just have excess abilities in the menu.
        /// </summary>
        None = 0,
        /// <summary>
        /// High Jump stacks: Jump higher the more you have.
        /// </summary>
        HighJump = 1,
        /// <summary>
        /// High Jump, Glides, Mermaid Kick, Dodge Roll. First glide/superglide turns into glide, next into superglide and past 
        /// </summary>
        All = 2
    }
    
    public enum WarpAnywhere
    {
        /// <summary>
        /// You can only warp from a save point
        /// </summary>
        SavePoint = 0,
        /// <summary>
        /// You can warp in normal, non-combat state. Should circuvment most issues.
        /// </summary>
        NonCombat = 1,
        /// <summary>
        /// No restrictions
        /// </summary>
        Anywhere = 2
    }

    public enum RandomShops
    {
        /// <summary>
        /// Vanilla shops
        /// </summary>
        Vanilla = 0,
        
        /// <summary>
        /// Shops can have anything but important key items
        /// </summary>
        NonKeyItems = 1,
        
        /// <summary>
        /// Shops can have anything, including extra out of logic key items
        /// </summary>
        KeyItems = 2
    }
    
    #endregion
}