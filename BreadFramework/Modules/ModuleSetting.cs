namespace BreadRuntime.Settings;

public class ModuleSetting
{
    public string Name { get; set; }
    
    public string ValueAsString { get; set; }

    public bool ValueAsBool
    {
        get
        {
            bool.TryParse(ValueAsString, out var returnVal);
            return returnVal;
        }
    }
}