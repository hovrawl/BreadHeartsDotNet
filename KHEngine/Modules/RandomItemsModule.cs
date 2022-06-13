using KHData.Flags;
using Memory;

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
    private GameFlag EmblemCount;
    private GameFlag Slides;
    private GameFlag Evidence;
    private GameFlag ClawmarkBox;
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
    
    
    #endregion
    
    public List<string> GummiNames = new List<string>();
    public List<string> ItemNames = new List<string>();
    public List<string> ChestDetails = new List<string>();
    public List<string> RewardDetails = new List<string>();
    public List<string> VanillaChests = new List<string>();
    public List<string> VanillaRewards = new List<string>();
    public List<string> Itemids = new List<string>();
    public List<string> Rewards = new List<string>();
    public List<string> SoraLevels = new List<string>();
    public List<string> SoraAbilities = new List<string>();
    public List<string> SoraAbilities2 = new List<string>();
    public List<string> SoraAbilities3 = new List<string>();
    public List<string> DonaldLevels = new List<string>();
    public List<string> DonaldAbilities = new List<string>();
    public List<string> GoofyLevels = new List<string>();
    public List<string> GoofyAbilities = new List<string>();
    public List<string> WeaponStr = new List<string>();
    public List<string> WeaponMag = new List<string>();
    public List<string> ItemData = new List<string>();
    public List<string> Shops = new List<string>();
    public List<string> Synths = new List<string>();
    public List<string> Chests = new List<string>();
    public List<string> ItemsAvailable = new List<string>();
    public List<string> AbilitiesAvailable = new List<string>();
    public List<string> MagicAvailable = new List<string>();
    public List<string> ReportData = new List<string>();
    public int DalmatiansAvailable = 0;
    public string SeedString = "";
    public bool Randomized = false;
    public bool SuccessfulRando = true;
    public bool IsValidSeed = false;
    public bool InitDone = false;
    public int InfiniteDetection = 0;
    public bool canExecute = false;
    
    public override string Author => "Denhonator";
    
    public override string Name => "Random Items";

    public override string Description => "Randomise the items in game. Can be configured";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = true;

        KhEngine = khEngine;
        
        Initialised = success;
        return success;
    }

    public override void OnFrame()
    {
        
    }
}