using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BreadHeartsLauncher.Config.Models;

namespace BreadHeartsLauncher.Config;

public class LauncherConfig: INotifyPropertyChanged
{
    public string Key { get; set; }
    public string Header { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string ValidationColor { get; set; } = "00FFFFFF";
    
    public ConfigModel ConfigModel { get; set; } = new ();
    
    public object? Content { get; set; }

    private string _value;
    public string Value 
    { 
        get { return _value; }
        set
        {
            _value = value;
            OnPropertyChanged(nameof(_value));
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}