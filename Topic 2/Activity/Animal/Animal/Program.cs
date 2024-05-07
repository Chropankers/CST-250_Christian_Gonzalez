using System;

namespace AnimalConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Eagle myEagle = new Eagle();
            myEagle.Greet();
            myEagle.Talk();
            myEagle.Sing();
            myEagle.Fly();

            Duck myDuck = new Duck();
            myDuck.Greet();
            myDuck.Talk();
            myDuck.Fly();
            myDuck.Swim();

            Shark myShark = new Shark();
            myShark.Greet();
            myShark.Talk();
            myShark.Swim();

            Console.ReadKey();
        }
    }
}
