using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        //gets player names from user input
        //returns both player names in string array
        public string[] GetPlayerNames()
        {
            string playerName;
            string[] playerList = {null, null};
            int playerCount = 1;

            while (true)
            {
                Console.WriteLine("Enter the name for Player {0}", playerCount);
                playerName = Console.ReadLine();
                char firstLetter = playerName.ToCharArray().ElementAt(0);
                if (char.IsLetter(firstLetter))
                {
                    playerList[playerCount - 1] = playerName;
                    playerCount++;
                }
                if (playerList[1] != null)
                    return playerList;
            }
        }
    }
}
