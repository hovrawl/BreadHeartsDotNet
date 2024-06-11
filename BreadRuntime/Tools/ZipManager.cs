using Ionic.Zip;

namespace BreadRuntime.Tools;

public static class ZipManager
{
    public static readonly List<ZipFile> ZipFiles = new ();

    private static bool ZipDirectoryExists(string dir)
    {
        return ZipFiles.Find(x => x.SelectEntries(Path.Combine(dir, "*")).Count > 0) != null;
    }

    public static bool ZipFileExists(string file)
    {
        return ZipFiles.Find(x => x.ContainsEntry(file)) != null;
    }

    public static bool DirectoryExists(string dir)
    {
        return ZipDirectoryExists(dir) || Directory.Exists(dir);
    }

    public static bool FileExists(string file)
    {
        return ZipFileExists(file) || File.Exists(file);
    }

    public static IEnumerable<string> GetFiles(string folder)
    {
        if (ZipDirectoryExists(folder))
        {
            List<string> foundFiles = new List<string>();
            ZipFiles.ForEach(x =>
            {
                ICollection<ZipEntry> entries = x.SelectEntries(Path.Combine(folder, "*"));
                foreach (var entry in entries)
                {
                    string filename = entry.FileName.Replace(folder.Replace(@"\", "/") + "/", "");
                    if (!entry.IsDirectory && !foundFiles.Contains(filename))
                    {
                        foundFiles.Add(filename);
                    }
                }
            });
            return foundFiles;
        }
        else if (Directory.Exists(folder))
        {
            return Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                .Select(x => x.Replace($"{folder}\\", "")
                    .Replace(@"\", "/"));
        }

        return Enumerable.Empty<string>();
    }

    public static byte[] FileReadAllBytes(string file)
    {
        if (ZipFileExists(file))
        {
            ZipEntry entry = null;
            foreach (var zipFile in ZipFiles)
            {
                var entries = zipFile.SelectEntries(file).Where(y => !y.IsDirectory);
                if (entries.FirstOrDefault() != null)
                {
                    entry = entries.FirstOrDefault();

                    using (var stream = entry.OpenReader())
                    {
                        var bytes = new byte[entry.UncompressedSize];
                        stream.Read(bytes, 0, (int)entry.UncompressedSize);
                        return bytes;
                    }
                }
            }

            ;
        }
        else if (File.Exists(file))
        {
            return File.ReadAllBytes(file);
        }

        return new byte[0];
    }

    public static string[] FileReadAllLines(string file)
    {
        if (ZipFileExists(file))
        {
            byte[] bytes = FileReadAllBytes(file);
            string text = System.Text.Encoding.ASCII.GetString(bytes);
            return text.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.None
            );
        }
        else if (File.Exists(file))
        {
            return File.ReadAllLines(file);
        }

        return new string[0];
    }

    public static Stream FileReadStream(string file)
    {
        if (ZipFileExists(file))
        {
            byte[] bytes = FileReadAllBytes(file);
            return new MemoryStream(bytes);
        }
        else if (File.Exists(file))
        {
            var stream = File.OpenRead(file);
            return stream;
        }

        return new MemoryStream();
    }
}