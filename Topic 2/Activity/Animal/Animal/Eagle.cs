namespace AnimalConsoleApp
{
    class Eagle : Animal, IFlyable
    {
        public override void Talk()
        {
            Console.WriteLine("Eagle screams!");
        }

        public override void Sing()
        {
            Console.WriteLine("Eagle does not really sing but emits loud calls.");
        }

        public void Fly()
        {
            Console.WriteLine("Eagle soars high in the sky.");
        }
    }
}