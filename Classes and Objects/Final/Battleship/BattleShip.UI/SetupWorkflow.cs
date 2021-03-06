﻿using System;
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
        public Coordinate GetShipCoordinates()
        {
            while (true)
            {
                string coordinates = ConsoleInput.GetCoordinates();
                char row = coordinates[0];
                int column = int.Parse(coordinates.Remove(0, 1));
                int letterToNumber = (int)row % 32;

                Coordinate userEntry = new Coordinate(letterToNumber, column);
                return userEntry;
            }
        }
        public Board GameSetUp()
        {
            //create board instance for current player
            //create placementRequest
            Board playerBoard = new Board();
            PlaceShipRequest placementRequest = new PlaceShipRequest();
            int shipsPlaced = 0;

            while (shipsPlaced < 5)
            {
                //populate ships on board for current player based on their input
                //get ship type
                ShipType ship = ConsoleInput.GetShipType();
                placementRequest.ShipType = ship;

                //get coordinates
                Coordinate shipCoordinates = GetShipCoordinates();
                placementRequest.Coordinate = shipCoordinates;

                //get ship direction
                ShipDirection direction = ConsoleInput.GetShipDirection();
                placementRequest.Direction = direction;

                ShipPlacement response = playerBoard.PlaceShip(placementRequest);
                ConsoleOutput.DisplayShipPlacementResult(response);
                if(response == ShipPlacement.Ok)
                {
                    shipsPlaced++;
                }
            }
            Console.Clear();
            return playerBoard;
        }
    }
}
