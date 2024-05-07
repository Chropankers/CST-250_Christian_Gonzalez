using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalConsoleApp
{
    class Duck : Animal, IFlyable, ISwimmable
    {
        public override void Talk()
        {
            Console.WriteLine("Duck quacks!");
        }

        public void Fly()
        {
            Console.WriteLine("Duck flaps its wings and flies.");
        }

        public void Swim()
        {
            Console.WriteLine("Duck paddles and swims in the water.");
        }
    }
}