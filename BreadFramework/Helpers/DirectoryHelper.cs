using BreadFramework.Common;
using BreadFramework.Enums;

namespace BreadFramework.Helpers;

public static class DirectoryHelper
{
    public static GameDirectoryInfo GetGameRootDirectory(DirectoryInfo directoryInfo)
    {
        var returnInfo = new GameDirectoryInfo();

        // check steam
        var platformRootDirectory = GetFolderUpwards(directoryInfo, "Steam");
        if (platformRootDirectory != null)
        {
            returnInfo.Platform = GamePlatform.Steam;
            returnInfo.Path = platformRootDirectory.FullName;
        }
        else
        {
            platformRootDirectory = GetFolderUpwards(directoryInfo, "Epic Games");
            if (platformRootDirectory != null)
            {
                returnInfo.Platform = GamePlatform.Epic;
                returnInfo.Path = platformRootDirectory.FullName;
            }
        }


        return returnInfo;
    }

    public static DirectoryInfo GetFolderUpwards(DirectoryInfo startDirectory, string folderName)
    {
        if (string.IsNullOrEmpty(folderName)) return null;
        if (startDirectory == null) return null;

        if (startDirectory.Name.Equals(folderName, StringComparison.CurrentCultureIgnoreCase)) return startDirectory;

        return GetFolderUpwards(startDirectory.Parent, folderName);
    }

    public static GameDirectoryInfo AutoDetectGameDirectory()
    {
        var returnDirectory = new GameDirectoryInfo();
        var programFiles86 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
        
        // check steam
        var steamDirectory = programFiles86.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("Steam", StringComparison.CurrentCultureIgnoreCase));
        if (steamDirectory != null)
        {
            var steamApps = steamDirectory.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("steamapps", StringComparison.CurrentCultureIgnoreCase));
            if (steamApps != null)
            {
                var common = steamApps.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("common", StringComparison.CurrentCultureIgnoreCase));
                if (common != null)
                {
                    var khFolder = common.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("KINGDOM HEARTS -HD 1.5+2.5 ReMIX-", StringComparison.CurrentCultureIgnoreCase));
                    if (khFolder != null)
                    {
                        returnDirectory.Path = steamDirectory.FullName;
                        returnDirectory.Platform = GamePlatform.Steam;
                        return returnDirectory;
                    }
                }
            }
           
        }
        
        // check epic games
        var programFiles64 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        var epicGamesDirectory = programFiles64.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("Epic Games", StringComparison.CurrentCultureIgnoreCase));

        if (epicGamesDirectory != null)
        {
            var khDirectory = epicGamesDirectory.EnumerateDirectories().FirstOrDefault(i => i.Name.Equals("KH_1.5_2.5", StringComparison.CurrentCultureIgnoreCase));
            if (khDirectory != null)
            {
                
                returnDirectory.Path = khDirectory.FullName;
                returnDirectory.Platform = GamePlatform.Epic;
            }
            

        }
        
        return returnDirectory;
    }

    public static GameDirectoryInfo VerifyGameDirectory(DirectoryInfo directoryInfo)
    {
        var returnDirectory = new GameDirectoryInfo();

        // steam folder
        var khDirectory = GetFolderUpwards(directoryInfo, "KINGDOM HEARTS -HD 1.5+2.5 ReMIX-");
        if (khDirectory != null)
        {
            returnDirectory.Path = khDirectory.FullName;
            returnDirectory.Platform = GamePlatform.Steam;
            return returnDirectory;
        }
        
        // epic folder
        khDirectory = GetFolderUpwards(directoryInfo, "KH_1.5_2.5");
        if (khDirectory != null)
        {
            returnDirectory.Path = khDirectory.FullName;
            returnDirectory.Platform = GamePlatform.Epic;
        }

        return returnDirectory;
    }
}