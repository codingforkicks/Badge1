using System;

namespace SpringForwardFallBack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's Spring...!");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine("\nOh no, it's fall...");
            for (int i = 10; i > 0; i--)
            {
                Console.Write(i + ", ");
            }
        }
    }
}
