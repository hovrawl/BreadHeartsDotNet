using System.Text;
using BreadFramework.Worlds;

namespace CodeGenerators.Classes;

public static class RewardsSourceGenerator
{
    public static void Generate ()
    {
        // Code generation goes here
        Console.WriteLine("Generating Rewards...");

        // begin creating the source we'll inject into the users compilation
        var sourceBuilder = new StringBuilder(@"
using BreadFramework.Enums;
using BreadFramework.Worlds;

namespace BreadFramework.Items;

public enum Rewards 
{        
");

        var inputFilePath = "Rewards.txt";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Missing Reward Data!");
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
    [CheckWorld(WorldList.{world})]
    [CheckLocation(""{location}"")]
    [CheckRequirements(""{requirement}"")]
    [CheckItem(ItemList.{itemEnum})]
    [CheckName(""{entryDescription}"")]
    {entryName} = 0x{entryValue},");
        }

        // finish creating the source to inject
        sourceBuilder.Append(@"
        
    
}");

        // write chests file
        var outputEnumDirectory = "Output/";
        var outputEnumPath = "Output/Rewards.cs";
        if (!Directory.Exists(outputEnumDirectory))
        {
            Directory.CreateDirectory(outputEnumDirectory);
        }
        
        File.WriteAllText(outputEnumPath, sourceBuilder.ToString(), UTF8Encoding.UTF8);
        Console.WriteLine("Done");

    }
}