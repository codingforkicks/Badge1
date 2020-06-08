using System;

namespace DifferentKettleOfFish
{
    class Program
    {
        static void Main(string[] args)
        {
            int fish = 1;

            while (fish < 10)
            {
                if (fish == 3)
                {
                    Console.WriteLine("RED fish!");
                }
                else if (fish == 4)
                {
                    Console.WriteLine("BLUE fish!");
                }
                else
                {
                    Console.WriteLine(fish + " fish!");
                }

                fish++;
            }
        }
    }
}
