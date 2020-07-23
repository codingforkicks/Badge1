using BattleShip.BLL.Requests;
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
            Console.WriteLine("Welcome to battle ship!  Press any key to start!");
            Console.ReadKey();
        }

        public static void PlayerStartPrompt(string playerName)
        {
            Console.Clear();
            Console.WriteLine($"Player {playerName}, press any key to begin building your player board.");
            Console.ReadKey();
        }

        public static void PlayerTurnPrompt(string playerName)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Player {playerName}'s Turn");
            Console.ResetColor();
        }

        //NotEnoughSpace, Overlap,Ok
        public static void DisplayShipPlacementResult(ShipPlacement response)
        {
            if(response == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("There is not enough room to place this ship here.");
            } else if (response == ShipPlacement.Overlap)
            {
                Console.WriteLine("There is already a ship here. You can not overlap ships!");
            }else if (response == ShipPlacement.Ok)
            {
                Console.Clear();
                Console.WriteLine($"Ship placed successfully");
            }
        }

        //Invalid, Duplicate, Miss, Hit, HitAndSunk, Victory
        public static void DisplayShotResult(FireShotResponse response)
        {
            if(response.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("Coordinate not on board, press any key to try again");
                Console.ReadKey();
            } else if (response.ShotStatus == ShotStatus.Duplicate)
            {
                Console.WriteLine("You've already shot there, please try again");
                Console.ReadKey();
            } else if (response.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine("You Missed!");
                Console.ReadKey();
            } else if (response.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine("Their Battleship was hit!");
                Console.ReadKey();
            } else if (response.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine($"You Sunk their {response.ShipImpacted} battleship!");
                Console.ReadKey();
            } else if (response.ShotStatus == ShotStatus.Victory)
            {
                Console.WriteLine("You Are Victorious!");
                Console.ReadKey();
            }
        }

        public static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
