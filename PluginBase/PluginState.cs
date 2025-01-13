using PluginBase.Settings;

namespace PluginBase;

public class PluginState
{
    /// <summary>
    /// Id for the plugin this state corresponds to
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Is this plugin enabled
    /// </summary>
    public bool Enabled { get; set; }
    
    /// <summary>
    /// Settings for this plugin
    /// </summary>
    public PluginSettings PluginSettings { get; set; }
    
    public string Name { get; set; }
    
    public string Author { get; set; }
    
    public string Description { get; set; }


    /// <summary>
    /// Json parameterless constructor
    /// </summary>
    public PluginState()
    {
        
    }
    
    public PluginState(BasePlugin plugin)
    {
        Id = plugin.Id;
        Name = plugin.Name;
        Description = plugin.Description;
        Author = plugin.Author;
        Enabled = true;
        PluginSettings = plugin.GetSettings();
    }

    /// <summary>
    /// Get plugin setting from key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public PluginSettingBase<T> GetSettingByKey<T>(string key)
    {
        return 
            PluginSettings.FirstOrDefault(i => i.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                as PluginSettingBase<T>
            ?? new PluginSettingBase<T>();
    }

    /// <summary>
    /// Apply value to existing setting
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void ApplySettingValue(string key, string value)
    {
        if (string.IsNullOrEmpty(key)) return;
        var setting = GetSettingByKey<object>(key);
        if (string.IsNullOrEmpty(setting.Name)) return;

        setting.Value = value;
    }
}