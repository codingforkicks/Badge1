using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//returns a bool indicating whether a number is prime
namespace Factorizor.BLL
{
    public class PrimeChecker
    {
        private bool IsPrime(int numToCheck)
        {
            int count = 0;
            for (int i = 1; i <= numToCheck; i++)
            {
                if (numToCheck % i == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            return false;
        }
    }
}
