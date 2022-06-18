using KHData.Flags;

namespace KHData.Enums;

public class AddressAttribute : Attribute
{
    private readonly int _address;

    /// <summary>
    /// 
    /// </summary>
    public int Address => _address;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="address"></param>
    public AddressAttribute(int address)
    {
        _address = address;
    }
}

public class FlagTypeAttribute : Attribute
{
    private readonly FlagType _type;

    /// <summary>
    /// 
    /// </summary>
    public FlagType Type => _type;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public FlagTypeAttribute(FlagType type)
    {
        _type = type;
    }
}

public class LengthAttribute : Attribute
{
    private readonly int _length;

    /// <summary>
    /// 
    /// </summary>
    public int Length => _length;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="length"></param>
    public LengthAttribute(int length)
    {
        _length = length;
    }
}