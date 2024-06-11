using System;
using BreadRuntime.Modules;
using BreadRuntime.Engine;

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
            
            // Engine.AddModule(new SaveAnywhereModule());
            // Engine.AddModule(new InstantGummiWarpModule());
            // Engine.AddModule(new FastCameraModule());
            // Engine.AddModule(new FasterAnimationsModule());
            // Engine.AddModule(new FasterDialogModule());
            // Engine.AddModule(new OpenInCombatModule());
            // Engine.AddModule(new UnskippableModule());
            //
            // Console.WriteLine("Engine Initialised!");
            // Console.WriteLine("Press any key after KH1 is open...");
            // Console.ReadKey();
            //
            // Engine.Start();
            
            Console.WriteLine("Finding Patch files");
            Console.WriteLine("Press any key to start patch...");
            Console.ReadKey();
            
            var patchType = "KH1";
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
            
            Engine.PatchFiles(patchFiles, patchType, epicFolder, backupPkg, extractPkg);
            
            
            Console.WriteLine("Press any key close...");
            Console.ReadKey();

            Engine.Stop();
            
            Console.WriteLine("Stopping...");

            Console.ReadKey();
        }
    }
}

