using KHData.Common;
using KHData.Enums;

namespace KHData.Worlds;

public static class Worlds
{
    public static List<CheckBase> GetWorldList()
    {
        var returnList = new List<CheckBase>();

        foreach (var worldEnum in Enum.GetValues<WorldList>())
        {
            var world = new CheckBase
            {
                Name = worldEnum.GetDescription(),
                OriginalAddress = (int) worldEnum,
                CheckType = CheckType.World,
            };
            
            returnList.Add(world);
        }

        return returnList;
    }
}