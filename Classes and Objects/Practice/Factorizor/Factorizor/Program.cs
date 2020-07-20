using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Program.Main() should only contain two statements, one to instantiate your workflow object and the second to start the Factorizor work flow. */
namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkFlow factor = new WorkFlow();
            factor.RunFactorFinder();
        }
    }
}
