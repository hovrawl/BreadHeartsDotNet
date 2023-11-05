using Ardalis.SmartEnum;
using BreadFramework.Game;

namespace BreadFramework.Data;

public abstract class KHItem : SmartEnum<KHItem>
{
    public abstract long Address { get; }
    
    public abstract string Name { get; }
    
    public KHItem(string name, int value) : base(name, value)
    {
    }
}