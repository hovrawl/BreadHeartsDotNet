using Ardalis.SmartEnum;

namespace BreadFramework.Game;

public abstract class KHGame  : SmartEnum<KHGame>
{
    public static readonly KHGame KHFM = new KHFMGame();
    public static readonly KHGame KHIIFM = new KHIIFMGame();
    public static readonly KHGame KHRECOM = new KHRECOMGame();
    public static readonly KHGame KHBBS = new KHBBSGame();
    
    protected KHGame(string name, int value) : base(name, value)
    {
    }

    /// <summary>
    /// Name of the Game
    /// </summary>
    public abstract string Name { get; }
    
    /// <summary>
    /// Process executable name
    /// </summary>
    public abstract string ProcessName { get; }
    
    /// <summary>
    /// Process name for direct memory access to process
    /// </summary>
    public abstract string ProcessId { get; }
    
    private sealed class KHFMGame : KHGame
    {
        public override string Name => "KINGDOM HEARTS Final Mix";
        public override string ProcessName => "KINGDOM HEARTS FINAL MIX.exe";
        public override string ProcessId => "KINGDOM HEARTS FINAL MIX";
        
        public KHFMGame() : base("KHFM", 0)
        {
        }
    }
    
    private sealed class KHIIFMGame : KHGame
    {
        public override string Name => "KINGDOM HEARTS II Final Mix";
        public override string ProcessName => "KINGDOM HEARTS II FINAL MIX.exe";
        public override string ProcessId => "KINGDOM HEARTS II FINAL MIX";
        
        public KHIIFMGame() : base("KHIIFM", 0)
        {
        }
    }
    
    private sealed class KHRECOMGame : KHGame
    {
        public override string Name => "KINGDOM HEARTS Re: Chain of Memories";
        public override string ProcessName => "KINGDOM HEARTS Re_Chain of Memories.exe";
        public override string ProcessId => "KINGDOM HEARTS Re_Chain of Memories";
        
        public KHRECOMGame() : base("KHIIFM", 0)
        {
        }
    }
    
    private sealed class KHBBSGame : KHGame
    {
        public override string Name => "KINGDOM HEARTS Birth By Sleep";
        public override string ProcessName => "KINGDOM HEARTS Birth by Sleep FINAL MIX.exe";
        public override string ProcessId => "KINGDOM HEARTS Birth by Sleep FINAL MIX";
        
        public KHBBSGame() : base("KHIIFM", 0)
        {
        }
    }
}