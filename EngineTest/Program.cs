using System;
using BreadRuntime.Modules;
using BreadRuntime.Engine;
using Memory;

namespace EngineTest
{
    internal class Program
    {

        public static KHEngine Engine;
        
        static void Main(string[] args)
        {
            Console.WriteLine("KH Engine Test!");
            Console.WriteLine("Initialising Engine...");

            KHEngine.Instance.Initialise(new Mem());

            Engine = KHEngine.Instance;
            
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

