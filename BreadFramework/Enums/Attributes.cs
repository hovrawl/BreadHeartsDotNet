using BreadFramework.Flags;
using BreadFramework.Items;
using BreadFramework.Worlds;

namespace BreadFramework.Enums;

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

public class CheckWorldAttribute : Attribute
{
    private readonly WorldList _world;

    /// <summary>
    /// 
    /// </summary>
    public WorldList World => _world;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="world"></param>
    public CheckWorldAttribute(WorldList world)
    {
        _world = world;
    }
}

public class CheckLocationAttribute : Attribute
{
    private readonly string _location;

    /// <summary>
    /// 
    /// </summary>
    public string Location => _location;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="{"></param>
    public CheckLocationAttribute(string location)
    {
        _location = location;
    }
}

public class CheckRequirementsAttribute : Attribute
{
    private readonly string _requirements;

    /// <summary>
    /// 
    /// </summary>
    public string Requirements => _requirements;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requirements"></param>
    public CheckRequirementsAttribute(string requirements)
    {
        _requirements = requirements;
    }
}

public class CheckItemAttribute : Attribute
{
    private readonly ItemList _itemList;

    /// <summary>
    /// 
    /// </summary>
    public ItemList ItemList => _itemList;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requirements"></param>
    public CheckItemAttribute(ItemList itemList)
    {
        _itemList = itemList;
    }
}

public class CheckNameAttribute : Attribute
{
    private readonly string _name;

    /// <summary>
    /// 
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public CheckNameAttribute(string name)
    {
        _name = name;
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