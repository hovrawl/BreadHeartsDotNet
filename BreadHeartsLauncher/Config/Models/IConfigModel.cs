namespace BreadHeartsLauncher.Config.Models;

public interface IConfigModel
{
    public string Header { get; set; }
    
    public string Description { get; set; }
    
    public string ValidationColor { get; set; }
}