using System;
using System.IO;

namespace RouteFinder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Objectville!\n");
            LoadTester();
            SubwayDirectionTester(args);
            Console.ReadKey();
        }

        private static void SubwayDirectionTester(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: two arguments");
                Console.ReadKey();
                Environment.Exit(3);
            }

            Console.WriteLine("Printing Directions from {0} to {1}.\n", args[0], args[1]);

            try
            {
                var loader = new SubwayLoader();
                var objectville = loader.LoadFromFile(@"ObjectvilleSubway.txt");

                if (!objectville.HasStation(args[0]) || !objectville.HasStation(args[1]))
                {
                    Console.WriteLine("{0} or {1} is not a station in Objectville.",args[0],args[1]);
                    Environment.Exit(4);
                }

                var route = objectville.GetDirections(args[0], args[1]);
                
                var printer=new SubwayPrinter(new StringWriter());
                printer.PrintDirections(route);
            }
            catch (Exception)
            {
                
                Console.ReadKey();
                Environment.Exit(5);
            }
        }

        private static void LoadTester()
        {
            var loader=new SubwayLoader();
            var objectville = loader.LoadFromFile(@"ObjectvilleSubway.txt");

            Console.WriteLine("Testing stations...");
            if(objectville.HasStation("DRY Drive") 
                && objectville.HasStation("Weather-O-Rama, Inc.") 
                && objectville.HasStation("Boards 'R' Us"))
            {
                Console.WriteLine("... station test passed\n");
            }
            else
            {
                Console.WriteLine("... station test FAILED");
                //Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("\nTesting connections...");
            if (objectville.HasConnection("Meyer Line", "DRY Drive", "Head First Theater") &&
                objectville.HasConnection("Wirfs-Brock Line", "Weather-O-Rama, Inc.", "XHTML Expressway") &&
                objectville.HasConnection("Rumbaugh Line", "Head First Theater", "Infinite Circle"))
            {
                Console.WriteLine("... connections test passed\n");
            }
            else
            {
                Console.WriteLine("Meyer Line\tDRY Drive\tHead First Theater");
                Console.WriteLine("... connections test FAILED");
                Console.ReadKey();
                Environment.Exit(2);
            }
        }
    }
}
