using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

//returns an array containing the factors of a given number
namespace Factorizor.BLL
{
    class FactorFinder
    {

        private int _factor;
        public static int Divides(int num, int potentalFactor)
        {
            return num % potentalFactor;
        }
        private int[] FactorArray(int number)
        {
            int[] factors = { 0 };
            
            if (number < 1)
            {
                return factors;

            }

            factors[1] = 1;
            
            for (int i = 1; i <= number; i++)
            {
                if (Divides(number, i) == 0)
                {
                    Array.Resize(ref factors, factors.Length);
                    factors[i] = i;
                }
            }
            return factors;
        }
    }
}
