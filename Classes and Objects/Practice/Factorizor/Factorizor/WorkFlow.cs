using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Factorizor.BLL;

//workflow calls all project files in order
namespace Factorizor
{
    public class WorkFlow
    {
        public void RunFactorFinder()
        {
            ConsoleOutput.DisplayTitle();
            int input = ConsoleInput.GetUserInput();
            FactorFinder findFactors = new FactorFinder();
            int[] factors = findFactors.FactorArray(input);

            PrimeChecker checkPrime = new PrimeChecker();
            bool isPrime = checkPrime.IsPrime(input);
            PerfectChecker checkPerfect = new PerfectChecker();
            bool isPerfect = checkPerfect.IsPerfect(input);

            ConsoleOutput.DisplayResults(input, factors, isPrime, isPerfect);
        }
    }
}
