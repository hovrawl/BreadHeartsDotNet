namespace PluginBase.Settings;

public class PluginDropDownSetting<T>: PluginSettingBase<T>
{
    public PluginDropDownOption<T> SelectedValue { get; set; }
    public IReadOnlyList<PluginDropDownOption<T>> Options { get; }

    public PluginDropDownSetting(IEnumerable<PluginDropDownOption<T>> options, PluginDropDownOption<T> defaultValue = default)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));
        
        Options = options.ToList().AsReadOnly();
        
        // Validate default value is in options
        if (defaultValue != null && !Options.Contains(defaultValue))
        {
            throw new ArgumentException("Default value must be one of the provided options", nameof(defaultValue));
        }
        
        SelectedValue = defaultValue ?? Options.FirstOrDefault();

    }

    // Helper method to find option by value
    public PluginDropDownOption<T> GetOptionByValue(T value)
    {
        return Options.FirstOrDefault(o => EqualityComparer<T>.Default.Equals(o.Value, value));
    }

}

public class PluginDropDownOption<T>
{
    public string Name { get; set; }
    
    public T Value { get; set; }
    
    public  PluginDropDownOption(string name, T value)
    {
        Name = name;
        Value = value;
    }

    // Override equals for proper comparison
    public override bool Equals(object obj)
    {
        if (obj is not PluginDropDownOption<T> other) return false;
        return Name == other.Name && EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Value);
    }

    // Optional: String representation for debugging
    public override string ToString() => $"{Name} ({Value})";

}