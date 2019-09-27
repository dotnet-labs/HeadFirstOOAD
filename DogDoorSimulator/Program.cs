using System;

namespace DogDoorSimulator
{
    internal class Program
    {
        private static void Main()
        {
            var door = new DogDoor();
            door.AddAllowedBark(new Bark("rowlf"));
            door.AddAllowedBark(new Bark("rooowlf"));
            door.AddAllowedBark(new Bark("rawlf"));
            door.AddAllowedBark(new Bark("woof"));
            var recognizer=new BarkRecognizer(door);
            var remote = new Remote(door);

            // simulate the hardware hearing a bark
            Console.WriteLine("Bruce starts barking...");
            recognizer.Recognize(new Bark("rowlf"));

            Console.WriteLine("\nBruce has gone outside...");


            System.Threading.Thread.Sleep(5000);
     
            Console.WriteLine("\nBruce's all done...");
            Console.WriteLine("...but he's stuck outside!");

            // simulate the hardware hearing a bark (not Bruce!)
            var smallDogBark = new Bark("yip");
            Console.WriteLine("A small dog starts barking...");
            recognizer.Recognize(smallDogBark);

            System.Threading.Thread.Sleep(1000);

            // simulate the hardware hearing a bark again
            Console.WriteLine("Bruce starts barking...");
            recognizer.Recognize(new Bark("rooowlf"));

            Console.WriteLine("\nBruce's back inside...");
            Console.ReadLine();
        }
    }
}
