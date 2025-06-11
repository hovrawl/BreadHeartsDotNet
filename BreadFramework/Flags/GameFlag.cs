namespace BreadFramework.Flags;

public class GameFlag
{

    /// <summary>
    /// The enum value of the flag
    /// </summary>
    public GameFlags Flag { get;  init; }
    
    
    public FlagType Type { get; set; }

    
    /// <summary>
    /// The c# type of the flag value
    /// </summary>
    public FlagValueType ValueType { get; set; }
    
    /// <summary>
    /// Display name of the flag
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Memory address of the flag
    /// </summary>
    public long Address { get; init; }

    /// <summary>
    /// Length value used for strings/byte[]
    /// </summary>
    public int Length { get; init; }
    
    /// <summary>
    /// Object representation of the value, should access specific value as type
    /// </summary>
    public object Value { get; set; }

    public string ValueAsString => Value as string ?? string.Empty;
    
    public bool ValueAsBool => Value as bool? ?? false;
    
    public int ValueAsInt => Value as int? ?? 0;

    public long ValueAsLong => Value as long? ?? 0;
    
    public float ValueAsFloat => Value as float? ?? 0;

    public byte ValueAsByte => Value as byte? ?? new byte();
    
    public byte[] ValueAsBytes => Value as byte[] ?? Array.Empty<byte>();

    private int _timeSinceLastRead = 0;
    public int TimeSinceLastRead => _timeSinceLastRead;

    public void UpdateLastRead()
    {
        _timeSinceLastRead = DateTime.Now.Millisecond;
    }
    
    private int _timeSinceLastWrite = 0;
    public int TimeSinceLastWrite => _timeSinceLastWrite;

    public void UpdateLastWrite()
    {
        _timeSinceLastWrite = DateTime.Now.Millisecond;
    }
    
    public override string ToString()
    {
        return $"{Name} - {ValueType:G} - {Value}";
    }
}