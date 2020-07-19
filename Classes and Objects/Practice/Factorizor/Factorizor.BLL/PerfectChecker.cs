using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//returns a bool indicating whether a number is perfect
namespace Factorizor.BLL
{
    public class PerfectChecker
    {
        private bool isPerfect(int numToCheck)
        {
            int sum = 1;
            //find all divisors and add them
            for (int i = 2; i * i <= numToCheck; i++)
            {
                if (numToCheck % i == 0)
                {
                    if (i * i != numToCheck)
                    {
                        sum = sum + i + numToCheck / i;
                    }
                    sum = sum + i;
                }
            }
            // if sum == num then num is perfect. Return true.
            if (sum == numToCheck && numToCheck != 1)
            {
                return true;
            }
            return false;
        }
    }
}
