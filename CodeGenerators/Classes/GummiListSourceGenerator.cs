using System.Text;
using KHData.Worlds;

namespace CodeGenerators.Classes;

public static class GummiListSourceGenerator
{
    public static void Generate ()
    {
        // Code generation goes here
        Console.WriteLine("Generating Gummi List...");

        // begin creating the source we'll inject into the users compilation
        var sourceBuilder = new StringBuilder(@"
using KHData.Enums;
using KHData.Worlds;

namespace KHData.Items;

public enum GummiList 
{        
");

        var inputFilePath = "Gummis.txt";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Missing Gummi Data!");
            return;
        }
        var inputLines = File.ReadLines(inputFilePath);
        
        // list of enum names so we can make unique when needed
        var uniqueEntryNames = new List<string>();
        
        // iterate over all chest entries and build an enum entry
        var gummiIndex = 0;
        foreach (var line in inputLines)
        {
            var entryData = line.Split(";").ToList();
            // indexes
            // 0 entryName
            var entryInfo = entryData[0].Split(" ").Where(i => !string.IsNullOrEmpty(i)).ToList();
             
            // value + name + description
            var entryValue = gummiIndex;
            var entryNameParts = entryInfo.ToList();
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

            sourceBuilder.AppendLine($@"
   
    [CheckName(""{entryDescription}"")]
    {entryName} = {entryValue},");

            gummiIndex++;
        }

        // finish creating the source to inject
        sourceBuilder.Append(@"
        
    
}");

        // write chests file
        var outputEnumDirectory = "Output/";
        var outputEnumPath = "Output/GummiList.cs";
        if (!Directory.Exists(outputEnumDirectory))
        {
            Directory.CreateDirectory(outputEnumDirectory);
        }
        
        File.WriteAllText(outputEnumPath, sourceBuilder.ToString(), UTF8Encoding.UTF8);
        Console.WriteLine("Done");

    }
}