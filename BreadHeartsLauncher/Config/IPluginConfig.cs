using Config.Net;
using Newtonsoft.Json.Linq;
using PluginBase;

namespace BreadHeartsLauncher.Config;

public interface IPluginConfig
{
    [Option(Alias = "PluginConfig")]
    string GetState(string pluginId);
    
    [Option(Alias = "PluginConfig")]
    void SetState(string pluginId, string state);
}