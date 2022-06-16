namespace KHData.Flags;

public class GameFlag
{
    /// <summary>
    /// The enum value of the flag
    /// </summary>
    public GameFlags Flag { get;  init; }
    
    /// <summary>
    /// The c# type of the flag value
    /// </summary>
    public FlagType Type { get; set; }
    
    /// <summary>
    /// Display name of the flag
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Memory address of the flag
    /// </summary>
    public long Address { get; init; }

    /// <summary>
    /// String representation of the value
    /// </summary>
    public string Value { get; set; }

    
    public float ValueAsInt => !int.TryParse(Value, out var result) ? 0 : result;

    public long ValueAsLong => !long.TryParse(Value, out var result) ? 0 : result;
    
    public float ValueAsFloat => !float.TryParse(Value, out var result) ? 0 : result;

    public override string ToString()
    {
        return $"{Name} - {Value}";
    }
}