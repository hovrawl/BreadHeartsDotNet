// See https://aka.ms/new-console-template for more information


using System;
using KHEngine.Modules;
using Memory;

namespace EngineTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        public static KHEngine.Engine.KHEngine Engine;
        static void Main(string[] args)
        {
            Console.WriteLine("KH Engine Test!");
            Console.WriteLine("Initialising Engine...");

            KHEngine.Engine.KHEngine.Instance.Initialise(new Mem());

            Engine = KHEngine.Engine.KHEngine.Instance;
            
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
            
            Console.WriteLine("Press any key close...");
            Console.ReadKey();

            Engine.Stop();
            
            Console.WriteLine("Stopping...");

            Console.ReadKey();
        }
    }
}

