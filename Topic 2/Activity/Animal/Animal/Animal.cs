using System;
using System.Collections.Generic;


namespace AnimalConsoleApp
{
    abstract class Animal
    {

        public Animal()
        {
            Console.WriteLine("Animal Constructor");
        }
        
        public void Greet()
        {
            Console.WriteLine("Animal Says Hello");
        }

        public virtual void Talk()
        {
            Console.WriteLine("Animal Talking");
        }

        public virtual void Sing()
        {
            Console.WriteLine("Animal Song");
        }
    }
}