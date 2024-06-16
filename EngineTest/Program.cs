using System;
using BreadFramework.Game;
using BreadRuntime.Modules;
using BreadRuntime.Engine;
using BreadRuntime.Tools;

namespace EngineTest
{
    internal class Program
    {

        public static KHEngine Engine;
        
        static void Main(string[] args)
        {
            Console.WriteLine("KH Engine Test!");
            Console.WriteLine("Initialising Engine...");

            KHEngine.Instance.Initialise();

            Engine = KHEngine.Instance;

            //RunModules();
            
            RunPatches();
            
            Console.WriteLine("Press any key close...");
            Console.ReadKey();

            Engine.Stop();
            
            Console.WriteLine("Stopping...");

            Console.ReadKey();
        }

        private static void RunModules()
        {
            Engine.AddModule(new SaveAnywhereModule());
            Engine.AddModule(new InstantGummiWarpModule());
            Engine.AddModule(new FastCameraModule());
            Engine.AddModule(new FasterAnimationsModule());
            Engine.AddModule(new FasterDialogModule());
            Engine.AddModule(new OpenInCombatModule());
            Engine.AddModule(new UnskippableModule());
            
            Console.WriteLine("Engine Initialised!");
            Console.WriteLine("Press any key after KH1 is open...");
            Console.ReadKey();
            
            Engine.Start();

        }

        private static void RunPatches()
        {
            Console.WriteLine("Finding Patch files");
            Console.WriteLine("Press any key to start patch...");
            Console.ReadKey();
            
            var patchType = KHGame.KHFM;
            var backupPkg = true;
            var extractPkg = false;
            var epicFolder = @"C:\Program Files\Epic Games\KH_1.5_2.5\Image\en\";
            if (!Directory.Exists(epicFolder))
            {
                Console.WriteLine("Kingdom Hearts not found.");
                Console.WriteLine("Press any key close...");
                Console.ReadKey();
                return;
            }
            
            var patchFiles = new List<string>();
            var patchDirectory = Path.Combine(Environment.CurrentDirectory, "Patches");
            if (Directory.Exists(patchDirectory))
            {
                foreach (var patchFile in Directory.EnumerateFiles(patchDirectory))
                {
                    patchFiles.Add(patchFile);
                }
            }

            if (patchFiles.Count < 1)
            {
                Console.WriteLine("No patches found.");
                Console.WriteLine("Press any key close...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"{patchFiles.Count} patches found, patching...");
            var bgWorker = new PatchBackgroundWorker();
            bgWorker.ProgressChanged += (s, e) =>
            {
                Console.WriteLine((string)e.UserState);
            };
            Engine.PatchFiles(patchFiles, patchType, bgWorker, backupPkg, extractPkg);
        }
    }
}

