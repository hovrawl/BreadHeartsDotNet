using Config.Net;

namespace BreadHeartsLauncher.Config;

public interface IPaths
{
    string Mods { get; set; }
    
    string Game { get; set; }

    string Patches { get; set; }
    
    [Option(Alias = "Paths.Game")]
    void SetGamePath(string value);
    
    [Option(Alias = "Paths.Mods")]
    void SetModsPath(string value);
    
    [Option(Alias = "Paths.Patches")]
    void SetPatchesPath(string value);
    
}