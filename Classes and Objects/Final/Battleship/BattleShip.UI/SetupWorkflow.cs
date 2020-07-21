using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

//creates a board instance for the game workflow with ships populated by the user.
namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        public Board GameSetUp()
        {
            //create board instance for current player
            //create placementRequest
            Board playerBoard = new Board();
            PlaceShipRequest placementRequest = new PlaceShipRequest();
            int shipsPlaced = 0;

            bool isDone = false;
            //get ship type
            while(isDone == false)
            {
                Console.WriteLine("Enter ShipType: ");
                if(Enum.TryParse(Console.ReadLine(), out ShipType ship))
                {
                    Console.WriteLine($"ship: {ship}");
                    placementRequest.ShipType = ship;
                    isDone = true;
                } else
                {
                    Console.WriteLine("That is not a valid ship type!");
                }
            }

            isDone = false;
            //populate ships on board for current player based on their input
            //get coordinates
            Console.WriteLine("Enter Ship Coordinates: ");
            string coordinates = ConsoleInput.GetCoordinates();
            char row = coordinates[0];
            int column = int.Parse(coordinates.Remove(0, 1));
            int letterToNumber = (int)row % 32;

            Coordinate userEntry = new Coordinate(letterToNumber, column);
            placementRequest.Coordinate = userEntry;


            while (isDone == false)
            {
                Console.WriteLine("Enter Direction: ");
                if (Enum.TryParse(Console.ReadLine(), out ShipDirection direction))
                {
                    Console.WriteLine($"direction: {direction}");
                    placementRequest.Direction = direction;
                    isDone = true;
                }
                else
                {
                    Console.WriteLine("That is not a valid direction!");
                }
            }

            Enum response = playerBoard.PlaceShip(placementRequest);
            if (Enum.IsDefined(ShipPlacement, response))
            {
                shipsPlaced++;
            }

            if(shipsPlaced >= 5)
            {
                return playerBoard;
            }
        }
    }
}
