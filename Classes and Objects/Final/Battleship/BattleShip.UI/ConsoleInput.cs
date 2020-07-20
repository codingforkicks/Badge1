using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add regex for simple validation
using System.Text.RegularExpressions;

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

        //validates coordinates
        public bool isValid(string coordinates)
        {
            //check if length of input is correct length
            if (coordinates.Length < 1 || coordinates.Length > 2)
            {
                return false;
            }

            //grab first letter and subseqent input
            string row = coordinates.Substring(0, 1);
            string column = coordinates.Substring(1, coordinates.Length - 1);
            //check if first letter is A-J and following is 1-10
            if (Regex.Matches(row, @"[a-j,A-J]").Count > 0)
            {
                if (Regex.Matches(column, @"[1-9]|10").Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        //gets player coordinates
        public string GetCordinates()
        {
            string coordinates;
            while (true)
            {
                Console.WriteLine("Enter shot coordinates");
                coordinates = Console.ReadLine();
                if (isValid(coordinates))
                {
                    return coordinates;
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Coordinates!");
                }

            }
        }
    }
}
