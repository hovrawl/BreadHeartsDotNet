using Memory;

namespace KHEngine.Modules;

public class RandomItemsModule : BaseModule
{
    public List<string> GummiNames = new List<string>();
    public List<string> ItemNames = new List<string>();
    public List<string> ChestDetails = new List<string>();
    public List<string> RewardDetails = new List<string>();
    public List<string> vanillaChests = new List<string>();
    public List<string> vanillaRewards = new List<string>();
    public List<string> itemids = new List<string>();
    public List<string> rewards = new List<string>();
    public List<string> soraLevels = new List<string>();
    public List<string> soraAbilities = new List<string>();
    public List<string> soraAbilities2 = new List<string>();
    public List<string> soraAbilities3 = new List<string>();
    public List<string> donaldLevels = new List<string>();
    public List<string> donaldAbilities = new List<string>();
    public List<string> goofyLevels = new List<string>();
    public List<string> goofyAbilities = new List<string>();
    public List<string> weaponStr = new List<string>();
    public List<string> weaponMag = new List<string>();
    public List<string> itemData = new List<string>();
    public List<string> shops = new List<string>();
    public List<string> synths = new List<string>();
    public List<string> chests = new List<string>();
    public List<string> itemsAvailable = new List<string>();
    public List<string> abilitiesAvailable = new List<string>();
    public List<string> magicAvailable = new List<string>();
    public List<string> reportData = new List<string>();
    public int dalmatiansAvailable = 0;
    public string seedstring = "";
    public bool randomized = false;
    public bool successfulRando = true;
    public bool isValidSeed = false;
    public bool initDone = false;
    public int infiniteDetection = 0;
    public bool canExecute = false;
    
    public override string Name => "Random Items";

    public override string Description => "Randomise the items in game. Can be configured";
    
    public override bool Initialise(Engine.KHEngine khEngine)
    {
        var success = false;

        KhEngine = khEngine;
        
        return success;
    }

    public override void OnFrame()
    {
        
    }
}