namespace BreadHeartsLauncher.Config.Models;

public class ConfigModel : IConfigModel
{
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public string ValidationColor { get; set; }
}