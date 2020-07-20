using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

//returns an array containing the factors of a given number
namespace Factorizor.BLL
{
    public class FactorFinder
    {
        private static int Divides(int num, int potentalFactor)
        {
            return num % potentalFactor;
        }
        public int[] FactorArray(int number)
        {
            
            //if the number is not positive return null
            if (number < 1)
            {
                return null;

            }

            //create an array to store the factors
            int[] factors = {};
            
            //loop through potential factors
            for (int i = 1; i <= number; i++)
            {
                //if factor is found resize the array and add the factor to the array
                if (Divides(number, i) == 0)
                {
                    Array.Resize(ref factors, factors.Length + 1);
                    factors[factors.Length - 1] = i;
                }
            }
            return factors;
        }
    }
}
