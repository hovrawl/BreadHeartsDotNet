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
            
            Engine.AddModule(new QuickOverworldWarpModule());
            
            Console.WriteLine("Engine Initialised!");
            Console.WriteLine("Press any key after KH1 is open...");
            Console.ReadKey();
            
            Engine.InitialiseModules();
            
            Console.WriteLine("Press any key close...");
            Console.ReadKey();
        }
    }
}

