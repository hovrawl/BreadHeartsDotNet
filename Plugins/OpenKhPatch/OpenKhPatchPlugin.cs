using BreadFramework.Game;
using PluginBase;

namespace BreadRuntime.Modules;

public class OpenKhPatchPlugin : BasePlugin
{
    public override KHGame Game { get; init; }
    public override string Author { get; init; }
    public override string Name { get; init; }
    public override string Description { get; init; }
    
    public string PatchFilePath { get; init; }
    
    public override bool Initialise(EngineApi.EngineApi khEngine)
    {
        return true;
    }

    public override void OnFrame(PluginState state)
    {
        // No op
    }
}