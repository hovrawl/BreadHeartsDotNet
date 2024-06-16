using BreadFramework.Game;
using Ionic.Zip;
using OpenKh.Egs;

namespace BreadRuntime.Tools;

public static class FilePatcher
{
    public static void ApplyPatch(List<string> patchFiles, KHGame patchType,
        string epicFolder, PatchBackgroundWorker bgWorker, bool backupPKG = true, bool extractPatch = false)
    {
        Console.WriteLine("Applying " + patchType.GameName + " patch...");

        var resourcePath = Path.Combine(Path.GetDirectoryName(AppContext.BaseDirectory) ?? "", "resources");
        if (!Directory.Exists(resourcePath)) throw new Exception("Unable to find resources");
        EgsTools.SetResourcesPath(resourcePath);

        if (string.IsNullOrEmpty(epicFolder) || !Directory.Exists(epicFolder))
        {
            if (patchType == KHGame.KHFM || patchType == KHGame.KHIIFM || patchType == KHGame.KHBBS || patchType == KHGame.KHRECOM)
            {
                throw new Exception(
                    "If you want to patch KH1, KH2, Recom or BBS, please drag your \"dt\" folder (en for epic) (the one that contains kh1_first, kh1_second, etc.) located under \"Kingdom Hearts HD 1 5 and 2 5 ReMIX/Image/\" here, and press Enter:");
            }
            if (patchType == KHGame.KHDDD)
            {
                throw new Exception(
                    "If you want to patch Dream Drop Distance, please drag your \"dt\" folder (en for epic) (the one that contains kh3d_first, kh3d_second, etc.) located under \"Kingdom Hearts HD 2 8 Final Chapter Prologue/Image/\" here, and press Enter:");
            }
        }

        var timestamp = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_ms");
        var tempFolder = "";
        if (extractPatch)
        {
            Console.WriteLine("Extracting patch...");
            //if (GUI_Displayed) status.Text = $"Extracting patch: 0%";
            tempFolder = patchFiles[0] + "_" + timestamp;
            Directory.CreateDirectory(tempFolder);
        }

        
        bgWorker.DoWork += (s, e) =>
        {
            var epicBackup = Path.Combine(epicFolder, "backup");
            Directory.CreateDirectory(epicBackup);

            ZipManager.ZipFiles.Clear();
            foreach (var patchFile in patchFiles)
            {
                using (ZipFile zip = ZipFile.Read(patchFile))
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

            bgWorker.ReportProgress(0, "Applying patch...");

            var foundFolder = false;

            foreach (var gameFile in khFiles[patchType])
            {
                bgWorker.ReportProgress(0, $"Searching {gameFile}...");
                var epicFile = Path.Combine(epicFolder, gameFile + ".pkg");
                var epicHedFile = Path.Combine(epicFolder, gameFile + ".hed");
                var patchFolder = Path.Combine(tempFolder, gameFile);
                var epicPkgBackupFile = Path.Combine(epicBackup,
                    gameFile + (!backupPKG ? "_" + timestamp : "") + ".pkg");
                var epicHedBackupFile = Path.Combine(epicBackup,
                    gameFile + (!backupPKG ? "_" + timestamp : "") + ".hed");

                try
                {
                    var patchDirectoryExists = ZipManager.DirectoryExists(gameFile);
                    if (((!extractPatch && patchDirectoryExists) ||
                         (extractPatch && Directory.Exists(patchFolder))) && File.Exists(epicFile))
                    {
                        foundFolder = true;
                        // move original files to a backup folder for writing
                        if (File.Exists(epicPkgBackupFile)) File.Delete(epicPkgBackupFile);
                        File.Move(epicFile, epicPkgBackupFile);
                        if (File.Exists(epicHedBackupFile)) File.Delete(epicHedBackupFile);
                        File.Move(epicHedFile, epicHedBackupFile);
                        bgWorker.ReportProgress(0, $"Patching {gameFile}...");
                        // Set file name for patching on BGW
                        bgWorker.PKG = gameFile;
                        // Patch file
                        EgsTools.Patch(epicPkgBackupFile, (!extractPatch ? gameFile : patchFolder), epicFolder, bgWorker);
                        if (!backupPKG)
                        {
                            if (File.Exists(epicPkgBackupFile)) File.Delete(epicPkgBackupFile);
                            File.Move(Path.Combine(epicFolder, gameFile + "_" + timestamp + ".pkg"),
                                Path.Combine(epicFolder, gameFile + ".pkg"));
                            if (File.Exists(epicHedBackupFile)) File.Delete(epicHedBackupFile);
                            File.Move(Path.Combine(epicFolder, gameFile + "_" + timestamp + ".hed"),
                                Path.Combine(epicFolder, gameFile + ".hed"));
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
        bgWorker.RunWorkerCompleted += (s, e) =>
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
        bgWorker.WorkerReportsProgress = true;
        bgWorker.RunWorkerAsync();
    }

    static Dictionary<KHGame, string[]> khFiles = new ()
    {
        {
            KHGame.KHFM, new string[]
            {
                "kh1_first",
                "kh1_second",
                "kh1_third",
                "kh1_fourth",
                "kh1_fifth"
            }
        },
        {
            KHGame.KHIIFM, new string[]
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
            KHGame.KHBBS, new string[]
            {
                "bbs_first",
                "bbs_second",
                "bbs_third",
                "bbs_fourth"
            }
        },
        {
            KHGame.KHDDD, new string[]
            {
                "kh3d_first",
                "kh3d_second",
                "kh3d_third",
                "kh3d_fourth"
            }
        },
        {
            KHGame.KHRECOM, new string[]
            {
                "Recom"
            }
        }
    };
}