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