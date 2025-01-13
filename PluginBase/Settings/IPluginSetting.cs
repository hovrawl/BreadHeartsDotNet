namespace PluginBase.Settings;

public interface IPluginSetting<T>
{
    string Name { get; }
    
    T Value { get; set; }
}