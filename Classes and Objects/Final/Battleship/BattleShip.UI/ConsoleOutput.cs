using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to battle ship!  Press any key to start");
            Console.ReadKey();
        }

    }
}
