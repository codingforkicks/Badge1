using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    public class ConsoleInput
    {
        public static int GetUserInput()
        {
            Console.Clear();
            int output;
            string input;

            while (true)
            {
                Console.Write("Enter a number to factor: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    if(int.Parse(input) > 0)
                    {
                        return output;
                    }
                }
                Console.WriteLine("That was not a valid number! Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
