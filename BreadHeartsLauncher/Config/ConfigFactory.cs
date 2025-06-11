using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BreadHeartsLauncher.Config.Builders.Base;
using BreadHeartsLauncher.Config.Models;
using BreadHeartsLauncher.Views;

namespace BreadHeartsLauncher.Config;

public static class ConfigFactory
{
    private static readonly List<IControlBuilder> _builders = new();
    
    public static void BuildControl(this LauncherConfig config)
    {
        var modelType = typeof(bool);
        var model = config.ConfigModel;
        switch (model) 
        {
            case DirectoryPickerConfigModel:
            {
                modelType = typeof(DirectoryPickerConfigModel);
                break;
            }
            case BoolConfigModel:
            {
                modelType = typeof(BoolConfigModel);
                break;
            }
        }

        
        var propertyInfo = typeof(LauncherConfig).GetProperty(nameof(LauncherConfig.Value));
        
        if (_builders.FirstOrDefault(x => x.IsValid(modelType)) is IControlBuilder builder)
        {
            config.Content = builder.Build(config, propertyInfo);
        }
    }
    
    public static void Register(this IControlBuilder builder)
    {
        _builders.Add(builder);
    }
}