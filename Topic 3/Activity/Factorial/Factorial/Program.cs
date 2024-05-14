namespace Factorial
// Christian Gonzalez/CST-250/ 5/13/24 This is a work based upon the Activity x Assignment for Programming in C# II, Grand Canyon University
{
    class Program
    {
        static void Main(string[] args) 
        {
            int startingNumber = 3;
            Console.Out.WriteLine(factorial(startingNumber));
            Console.ReadLine();
        }

        static int factorial(int x) 
        {
            Console.Out.WriteLine("X is {0}", x);
            if (x == 1)
            {
                return 1;
            }
            else
            {
                return x * factorial(x - 1);
            }
        }
    }
}