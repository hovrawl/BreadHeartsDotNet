namespace KHData.Flags;

/// <summary>
/// 
/// </summary>
public class BaseFlag
{
    /// <summary>
    /// 
    /// </summary>
    public GameFlags Flag { get;  init; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public long Address { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}