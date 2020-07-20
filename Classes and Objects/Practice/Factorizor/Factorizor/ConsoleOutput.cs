using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Factor Finder!\n\n");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
        }

        public static void DisplayResults(int num, int[] factors = null, bool isPrime = false, bool isPerfect = false)
        {
            if(factors.Length > 0)
            {
                Console.WriteLine("The Factors of {0} are: ", num);
                for(int i = 0; i < factors.Length; i++)
                {
                    Console.Write(factors[i]);
                }
                Console.WriteLine("is Prime: {0} \n" +
                    "               is Perfect {0}", isPrime, isPerfect);
            } else
            {
                Console.WriteLine("{0} does not have any factors: ", num);
            }
        }
    }
}
