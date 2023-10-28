using BreadFramework.Flags;
using BreadFramework.Common;
using BreadFramework.Enums;

namespace BreadFramework.Worlds;

public static class Worlds
{
    public static List<WorldInfo> GetWorldList()
    {
        var returnList = new List<WorldInfo>();

        foreach (var worldEnum in Enum.GetValues<WorldList>())
        {
            var world = new WorldInfo
            {
                World = worldEnum,
                Name = worldEnum.GetDescription(),
                WorldId = (int) worldEnum,
            };
            
            returnList.Add(world);
        }

        return returnList;
    }
}