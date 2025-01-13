namespace PluginBase.Settings;

public class PluginSettingBase
{
    public Type Type { get; }
    
    public string Name { get; set; }
}

public class PluginSettingBase<T> : PluginSettingBase
{
    public new Type Type => typeof(T);

    public T Value { get; set; }
    
    public string Name { get; set; }
}