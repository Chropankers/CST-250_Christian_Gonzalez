using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalConsoleApp
{
    class Dog : Animal, IDomesticated
    {
        public Dog()
        {
            Console.WriteLine("Dog Constructor. Good puppy.");
        }

        public override void Talk()
        {
            Console.WriteLine("Bark Bark Bark");
        }

        public override void Sing()
        {
            Console.WriteLine("Hooooowwwwl!");
        }

        public void Fetch(string thing)
        {
            Console.WriteLine("Oh boy, here is your " + thing + ". Let's do it again!");
        }

        public void TouchMe()
        {
            Console.WriteLine("Please scratch behind my ears.");
        }

        public void FeedMe()
        {
            Console.WriteLine("It's suppertime. The very best time of day!");
        }
    }
}
