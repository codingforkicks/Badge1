using BattleShip.BLL.Responses;
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

        public static void PlayerStartPrompt(int playerNumber)
        {
            Console.Clear();
            Console.WriteLine($"Player {playerNumber}, press any key to begin building your player board.");
        }

        public static void PlayerTurnPrompt(int playerNumber)
        {
            Console.Clear();
            Console.WriteLine($"Player {playerNumber}, press any key to start turn.");
        }

        //Invalid, Duplicate, Miss, Hit, HitAndSunk, Victory
        public static void DisplayShotResult(FireShotResponse response)
        {
            if(response.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("Coordinate not on board, please try again");
            } else if (response.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine("You've already shot there, please try again");
            } else if (response.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine("You've already shot there, please try again");
            } else if (response.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine("You've already shot there, please try again");
            } else if (response.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine("You've already shot there, please try again");
            } else if (response.ShotStatus == ShotStatus.Victory)
            {
                Console.WriteLine("You Are Victorious!");
            }
        }

        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
