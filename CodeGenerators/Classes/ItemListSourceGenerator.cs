using System.Text;
using KHData.Worlds;

namespace CodeGenerators.Classes;

public static class ItemListSourceGenerator
{
    public static void Generate ()
    {
        // Code generation goes here
        Console.WriteLine("Generating Item List...");

        // begin creating the source we'll inject into the users compilation
        var sourceBuilder = new StringBuilder(@"
using KHData.Enums;
using KHData.Worlds;

namespace KHData.Items;

public enum ItemList 
{        
");

        var inputFilePath = "items.txt";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Missing Item Data!");
            return;
        }
        var inputLines = File.ReadLines(inputFilePath);
        
        // list of enum names so we can make unique when needed
        var uniqueEntryNames = new List<string>();
        
        // iterate over all chest entries and build an enum entry
        
        foreach (var line in inputLines)
        {
            var entryData = line.Split(";").ToList();
            // indexes
            // 0 entryValue + entryName
            // 1 Location
            // 2 Requirement one
            var entryInfo = entryData[0].Split(" ").Where(i => !string.IsNullOrEmpty(i)).ToList();
             
            // value + name + description
            var entryValue = entryInfo[0].ToUpper();
            var entryNameParts = entryInfo.Skip(1).ToList();
            var entryName = string.Join("", entryNameParts).Trim().MakeSafe();
            var entryDescription = string.Join(" ", entryNameParts).Trim();
            var itemEnum = Helpers.GetItemFromName(entryName);
            if (uniqueEntryNames.Contains(entryName))
            {
                entryName += entryValue;
            }
            else
            {
                uniqueEntryNames.Add(entryName);
            }

            // check location
            var location = entryData[1].Trim();
            var world = Helpers.GetWorldFromLocation(location);

            // requirements 
            var requirement = "";
            if (entryData.Count > 2)
            {
                requirement = entryData[2];
            }

            sourceBuilder.AppendLine($@"
    [Address(0x{entryValue})]
    [CheckLocation(""{location}"")]
    [CheckRequirements(""{requirement}"")]
    [CheckName(""{entryDescription}"")]
    {entryName} = 0x{entryValue},");
        }

        // finish creating the source to inject
        sourceBuilder.Append(@"
        
    
}");

        // write chests file
        var outputEnumDirectory = "Output/";
        var outputEnumPath = "Output/ItemList.cs";
        if (!Directory.Exists(outputEnumDirectory))
        {
            Directory.CreateDirectory(outputEnumDirectory);
        }
        
        File.WriteAllText(outputEnumPath, sourceBuilder.ToString(), UTF8Encoding.UTF8);
        Console.WriteLine("Done");

    }
}