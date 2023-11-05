using Ardalis.SmartEnum;

namespace BreadFramework.Flags;

public abstract class GameFlagsBase : SmartEnum<GameFlagsBase>
{
    public abstract FlagType FlagType { get; set; }
    public abstract string Description { get; set; }
    public abstract long Address { get; set; }
    
    internal GameFlagsBase(string name, int value) : base(name, value)
    {
        
    }
}