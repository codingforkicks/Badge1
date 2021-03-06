﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

//Create a game workflow object that will contain two boards, keep track of which player's turn it is, and process each player's turn.
namespace BattleShip.UI
{
    public class GameWorkflow
    {
        public int DetermineWhoStarts()
        {
            Random num = new Random();
            return num.Next(0, 2);
        }
        public string SwitchPlayer(string currentPlayer, string[] playerlist)
        {
            if(currentPlayer == playerlist[0])
            {
                return playerlist[1];
            }
            return playerlist[0];
        }
        public Coordinate GetShotCoordinates(string currentPlayer)
        {
            ConsoleOutput.PlayerTurnPrompt(currentPlayer);
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

        //converts coordinates back to orginal string
        public string CoordinatesToString(Coordinate coordinates)
        {
            const string letters = "ABCDEFGHIJ";

            string coordinateAsString = letters[coordinates.XCoordinate - 1] + coordinates.YCoordinate.ToString();

            return coordinateAsString;
        }



        /*Show a grid with marks from the their board's shot history. Place a yellow M in a coordinate if a shot has been fired and missed at that location or a red H if a shot has been fired that has hit.*/
        public void ShowGrid(Dictionary<Coordinate, ShotHistory> shotHistory)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shot History: ");
            Console.ResetColor();
            
            foreach(var shot in shotHistory)
            {
                if (shot.Value == ShotHistory.Hit)
                {
                    Console.Write($"{CoordinatesToString(shot.Key)}: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" H ");
                    Console.ResetColor();
                } else if (shot.Value == ShotHistory.Miss)
                {
                    Console.Write($"{CoordinatesToString(shot.Key)}: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" M ");
                    Console.ResetColor();
                }
            }
        }

        public void PlayGame()
        {
            bool gameOver = false;
            //welcome message
            ConsoleOutput.Welcome();

            while (gameOver == false)
            {
                string[] playerlist = ConsoleInput.GetPlayerNames();
                int startingPlayer = DetermineWhoStarts();
                string currentPlayer = playerlist[startingPlayer];
            
                //run game setup
                SetupWorkflow gameBoard = new SetupWorkflow();
                Board player1Board;
                Board player2Board;

                if(currentPlayer == playerlist[0])
                {
                    ConsoleOutput.PlayerStartPrompt(playerlist[0]);
                    player1Board = gameBoard.GameSetUp();
                    ConsoleOutput.PlayerStartPrompt(playerlist[1]);
                    player2Board = gameBoard.GameSetUp();
                } else
                {
                    ConsoleOutput.PlayerStartPrompt(playerlist[1]);
                    player2Board = gameBoard.GameSetUp();
                    ConsoleOutput.PlayerStartPrompt(playerlist[0]);
                    player1Board = gameBoard.GameSetUp();
                }

                bool winnerFound = false;
                while (winnerFound == false)
                {
                    /*Show a grid with marks from the their board's shot history. Place a yellow M in a coordinate if a shot has been fired and missed at that location or a red H if a shot has been fired that has hit.*/
                    if (currentPlayer == playerlist[0])
                    {
                        ShowGrid(player1Board.GetShotHistory());
                    }
                    else
                    {
                        ShowGrid(player2Board.GetShotHistory());
                    }

                   //Prompt the user for a coordinate entry (ex: B10). Validate the entry; if valid, create a coordinate object, convert the letter to a number, and call the opponent board's FireShot() method.
                    Coordinate shot = GetShotCoordinates(currentPlayer);
                    FireShotResponse response;

                    if (currentPlayer == playerlist[0])
                    {
                        response = player2Board.FireShot(shot);
                    }
                    else
                    {
                        response = player1Board.FireShot(shot);
                    }

                    //Retrieve the response from the FireShot method and display an appropriate message to the user.
                    ConsoleOutput.DisplayShotResult(response);

                    if (response.ShotStatus == ShotStatus.Victory)
                    {
                        winnerFound = true;
                    }
                    
                    //if the shot is not invalid and not a duplicate switch players
                    if (response.ShotStatus != ShotStatus.Invalid && response.ShotStatus != ShotStatus.Duplicate)
                    {
                        Console.Clear();
                        currentPlayer = SwitchPlayer(currentPlayer, playerlist);
                    }
                }
                //ask if they would like to play again
                //reset boards if they do
                //exit if they dont
                bool playAgain = ConsoleInput.PlayAgain(currentPlayer);
                if (playAgain == false)
                {
                    gameOver = true;
                }
            }
            //Ending message
            ConsoleOutput.GameOver();
        }
    }
}
