using Ionic.Zip;
using OpenKh.Egs;

namespace BreadRuntime.Tools;

public static class FilePatcher
{
    public static void ApplyPatch(List<string> patchFile, string patchType, string epicFolder = null, bool backupPKG = true,
        bool extractPatch = false)
    {
        Console.WriteLine("Applying " + patchType + " patch...");

        var resourcePath = Path.Combine(Path.GetDirectoryName(AppContext.BaseDirectory) ?? "", "resources");
        if (!Directory.Exists(resourcePath)) throw new Exception("Unable to find resources");
        EgsTools.SetResourcesPath(resourcePath);
        
        if (epicFolder == null)
        {
            epicFolder = @"C:\Program Files\Epic Games\KH_1.5_2.5\Image\en\";
            if (patchType == "DDD") epicFolder = null;
        }

        while (!Directory.Exists(epicFolder))
        {
            if (patchType == "KH1" || patchType == "KH2" || patchType == "BBS" || patchType == "COM")
            {
                Console.WriteLine(
                    "If you want to patch KH1, KH2, Recom or BBS, please drag your \"en\" folder (the one that contains kh1_first, kh1_second, etc.) located under \"Kingdom Hearts HD 1 5 and 2 5 ReMIX/Image/\" here, and press Enter:");
                epicFolder = Console.ReadLine()?.Trim('"');
            }
            else if (patchType == "DDD")
            {
                Console.WriteLine(
                    "If you want to patch Dream Drop Distance, please drag your \"en\" folder (the one that contains kh3d_first, kh3d_second, etc.) located under \"Kingdom Hearts HD 2 8 Final Chapter Prologue/Image/\" here, and press Enter:");
                epicFolder = Console.ReadLine()?.Trim('"');
            }
        }

        string timestamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_ms");
        string tempFolder = "";
        if (extractPatch)
        {
            Console.WriteLine("Extracting patch...");
            //if (GUI_Displayed) status.Text = $"Extracting patch: 0%";
            tempFolder = patchFile[0] + "_" + timestamp;
            Directory.CreateDirectory(tempFolder);
        }

        var backgroundWorker1 = new PatchBackgroundWorker();
        backgroundWorker1.ProgressChanged += (s, e) =>
        {
            Console.WriteLine((string)e.UserState);
            //if (GUI_Displayed) status.Text = (string)e.UserState;
        };
        backgroundWorker1.DoWork += (s, e) =>
        {
            string epicBackup = Path.Combine(epicFolder, "backup");
            Directory.CreateDirectory(epicBackup);

            ZipManager.ZipFiles.Clear();
            for (int i = 0; i < patchFile.Count; i++)
            {
                using (ZipFile zip = ZipFile.Read(patchFile[i]))
                {
                    if (extractPatch)
                    {
                        //totalFiles = zip.Count;
                        //filesExtracted = 0;
                        //currentExtraction = patchFile[i];
                        //zip.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(ExtractionProgress);
                        zip.ExtractAll(tempFolder, ExtractExistingFileAction.OverwriteSilently);
                    }
                    else
                    {
                        ZipManager.ZipFiles.Add(zip);
                    }
                }
            }

            backgroundWorker1.ReportProgress(0, "Applying patch...");

            bool foundFolder = false;
            for (int i = 0; i < khFiles[patchType].Length; i++)
            {
                backgroundWorker1.ReportProgress(0, $"Searching {khFiles[patchType][i]}...");
                string epicFile = Path.Combine(epicFolder, khFiles[patchType][i] + ".pkg");
                string epicHedFile = Path.Combine(epicFolder, khFiles[patchType][i] + ".hed");
                string patchFolder = Path.Combine(tempFolder, khFiles[patchType][i]);
                string epicPkgBackupFile = Path.Combine(epicBackup,
                    khFiles[patchType][i] + (!backupPKG ? "_" + timestamp : "") + ".pkg");
                string epicHedBackupFile = Path.Combine(epicBackup,
                    khFiles[patchType][i] + (!backupPKG ? "_" + timestamp : "") + ".hed");

                try
                {
                    var patchDirectoryExists = ZipManager.DirectoryExists(khFiles[patchType][i]);
                    if (((!extractPatch && patchDirectoryExists) ||
                         (extractPatch && Directory.Exists(patchFolder))) && File.Exists(epicFile))
                    {
                        foundFolder = true;
                        if (File.Exists(epicPkgBackupFile)) File.Delete(epicPkgBackupFile);
                        File.Move(epicFile, epicPkgBackupFile);
                        if (File.Exists(epicHedBackupFile)) File.Delete(epicHedBackupFile);
                        File.Move(epicHedFile, epicHedBackupFile);
                        backgroundWorker1.ReportProgress(0, $"Patching {khFiles[patchType][i]}...");
                        backgroundWorker1.PKG = khFiles[patchType][i];
                        OpenKh.Egs.EgsTools.Patch(epicPkgBackupFile,
                            (!extractPatch ? khFiles[patchType][i] : patchFolder), epicFolder, backgroundWorker1);
                        if (!backupPKG)
                        {
                            if (File.Exists(epicPkgBackupFile)) File.Delete(epicPkgBackupFile);
                            File.Move(Path.Combine(epicFolder, khFiles[patchType][i] + "_" + timestamp + ".pkg"),
                                Path.Combine(epicFolder, khFiles[patchType][i] + ".pkg"));
                            if (File.Exists(epicHedBackupFile)) File.Delete(epicHedBackupFile);
                            File.Move(Path.Combine(epicFolder, khFiles[patchType][i] + "_" + timestamp + ".hed"),
                                Path.Combine(epicFolder, khFiles[patchType][i] + ".hed"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            if (extractPatch && Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
            if (!foundFolder)
            {
                string error =
                    "Could not find any folder to patch!\nMake sure you are using the correct path for the \"en\" folder!";
                Console.WriteLine(error);
                //if (GUI_Displayed) status.Text = "";
                //if (GUI_Displayed) MessageBox.Show(error);
            }
            else
            {
                //if (GUI_Displayed) status.Text = "";
                //if (GUI_Displayed) MessageBox.Show("Patch applied!");
                Console.WriteLine("Done!");
            }
        };
        backgroundWorker1.RunWorkerCompleted += (s, e) =>
        {
            if (e.Error != null)
            {
                //if (GUI_Displayed) MessageBox.Show("There was an error! " + e.Error.ToString());
                Console.WriteLine("There was an error! " + e.Error.ToString());
            }

            //if (GUI_Displayed) selPatchButton.Enabled = true;
            //if (GUI_Displayed) applyPatchButton.Enabled = true;
            //if (GUI_Displayed) backupOption.Enabled = true;
        };
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.RunWorkerAsync();
    }

    static Dictionary<string, string[]> khFiles = new Dictionary<string, string[]>()
    {
        {
            "KH1", new string[]
            {
                "kh1_first",
                "kh1_second",
                "kh1_third",
                "kh1_fourth",
                "kh1_fifth"
            }
        },
        {
            "KH2", new string[]
            {
                "kh2_first",
                "kh2_second",
                "kh2_third",
                "kh2_fourth",
                "kh2_fifth",
                "kh2_sixth"
            }
        },
        {
            "BBS", new string[]
            {
                "bbs_first",
                "bbs_second",
                "bbs_third",
                "bbs_fourth"
            }
        },
        {
            "DDD", new string[]
            {
                "kh3d_first",
                "kh3d_second",
                "kh3d_third",
                "kh3d_fourth"
            }
        },
        {
            "COM", new string[]
            {
                "Recom"
            }
        }
    };
}