using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add regex for simple validation
using System.Text.RegularExpressions;
//add requests for ship placement
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        //gets player names from user input
        //returns both player names in string array
        public static string[] GetPlayerNames()
        {
            string playerName;
            string[] playerList = {null, null};
            int playerCount = 1;

            while (true)
            {
                Console.Write("Enter a name for Player {0}: ", playerCount);
                playerName = Console.ReadLine();
                if(playerName.Length > 0)
                {
                    char firstLetter = playerName.ToCharArray().ElementAt(0);
                    if (char.IsLetter(firstLetter))
                    {
                        playerList[playerCount - 1] = playerName;
                        playerCount++;
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("\nError: Name must begin with a character");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nError: Name can not be blank");
                }
                if (playerList[1] != null) {
                    return playerList;
                }
            }
        }

        //validates coordinates
        public static bool isValid(string coordinates)
        {
            //check if length of input is correct length
            if (coordinates.Length < 2 || coordinates.Length > 3)
            {
                return false;
            }

            //grab first letter and subseqent input
            string row = coordinates.Substring(0, 1);
            string column = coordinates.Substring(1, coordinates.Length - 1);
           
            //check if first letter is A-J and following is integer 1-10
            if (Regex.Matches(row, @"[a-j,A-J]").Count > 0)
            {
                if (Regex.Matches(column, @"[1-9]|10").Count > 0)
                {
                    //regex only checks characters
                    if (int.TryParse(column, out int num))
                    {
                        if(num <= 10)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //gets player coordinates
        public static string GetCoordinates()
        {
            string coordinates;
            while (true)
            {
                Console.WriteLine("Enter Coordinates: ");
                coordinates = Console.ReadLine();
                if (isValid(coordinates))
                {
                    return coordinates;
                } else
                {
                    //Console.Clear();
                    Console.WriteLine($"{coordinates} is invalid!\n Coordinates must contain a letter A-J followed by a number 1-10\n\n");
                }

            }
        }

        public static ShipDirection GetShipDirection()
        {
            while (true)
            {
                Console.WriteLine("Enter Direction: ");
                if (Enum.TryParse(Console.ReadLine(), out ShipDirection direction))
                {
                    Console.WriteLine($"direction: {direction}");
                    return direction;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{direction} is not a valid direction!");
                }
            }
        }

        public static ShipType GetShipType()
        {
            while (true)
            {
                Console.WriteLine("Enter ShipType:\n" +
                    "0 Destroyer, 1 Submarine, 2 Cruiser, 3 Battleship, 4 Carrier ");
                if (Enum.TryParse(Console.ReadLine(), out ShipType ship))
                {
                    Console.WriteLine($"ship: {ship} selected");
                    return ship;
                }
                else
                {
                    Console.WriteLine("That is not a valid ship type!");
                }
            }
        }

        private static bool isValidExitCommand(string command)
        {
            if (command == "yes" || command == "no")
            {
                return true;
            }
            return false;
        }
        public static bool PlayAgain(string playerName)
        {
            Console.WriteLine($"{playerName} is Victorious!");
            while (true)
            {
                Console.WriteLine("Would you like to play again?\n Enter yes or no");
                string response = Console.ReadLine().ToLower();
                if (isValidExitCommand(response.Trim(null)))
                {
                    if(response[0] == 'y')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    Console.WriteLine("Invalid command. I didn't get that");
                }
            }
        }
    }
}
