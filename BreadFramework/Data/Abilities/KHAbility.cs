using Ardalis.SmartEnum;

namespace BreadFramework.Data.Abilities;

public abstract class KHAbility : SmartEnum<KHAbility>
{
    protected KHAbility(string name, int value) : base(name, value)
    {
    }
}