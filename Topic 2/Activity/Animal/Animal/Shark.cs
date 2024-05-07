using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalConsoleApp
{
    class Shark : Animal, ISwimmable
    {
        public override void Talk()
        {
            Console.WriteLine("Shark does not talk, it snaps!");
        }

        public void Swim()
        {
            Console.WriteLine("Shark swims powerfully through the water.");
        }
    }
}