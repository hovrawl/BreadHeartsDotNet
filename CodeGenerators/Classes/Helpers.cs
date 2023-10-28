using BreadFramework.Items;
using BreadFramework.Worlds;

namespace CodeGenerators.Classes;

public static class Helpers
{
    public static WorldList GetWorldFromLocation(string location)
    {
        return WorldList.TraverseTown;
    }

    public static ItemList GetItemFromName(string name)
    {
        var returnItem = ItemList.A41;
        foreach(ItemList item in Enum.GetValues(typeof(ItemList)))
        {
            if (item.ToString().Equals(name, StringComparison.CurrentCultureIgnoreCase))
            {
                returnItem = item;
            }
        }

        return returnItem;
    }
}