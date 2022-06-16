namespace KHData.Flags;

public class GameFlag
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
    public long Address { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public string Value { get; set; }

    public override string ToString()
    {
        return base.ToString();
    }
}