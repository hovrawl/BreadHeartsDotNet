namespace BreadHeartsLauncher.Config.Models;

public class DirectoryPickerConfigModel : ConfigModel
{
    public required BrowserMode BrowserMode { get; set; }
    public string? Title { get; set; }
    public string? Filter { get; set; }
    public string? SuggestedFileName { get; set; }
    public string? InstanceBrowserKey { get; set; }
    
}

public enum BrowserMode
{
    OpenFile,
    OpenFolder,
    SaveFile
}