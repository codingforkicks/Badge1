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
        public bool IsPerfect(int numToCheck)
        {
            if (numToCheck <= 1)
            {
                return false;
            }
            int sum = 0;
            //find all divisors and add them
            for (int i = 1; i < numToCheck; i++)
            {
                if (numToCheck % i == 0)
                {
                    sum = sum + i;
                }
            }
            // if sum == num then num is perfect. Return true.

            Console.WriteLine("sum: {0} number: {1}", sum, numToCheck);
            if (sum == numToCheck)
            {
                return true;
            }
            return false;
        }
    }
}
