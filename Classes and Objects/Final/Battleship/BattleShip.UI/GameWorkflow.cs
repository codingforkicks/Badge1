using System;
using System.Collections.Generic;
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
            return num.Next(1, 2);
        }
        public int SwitchPlayer(int currentPlayerNumber)
        {
            if(currentPlayerNumber == 1)
            {
                return 2;
            }
            return 1;
        }
        public Coordinate GetShotCoordinates()
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
        /*
         * A player's turn is as follows:
        Show a grid with marks from the their board's shot history. Place a yellow M in a coordinate if a shot has been fired and missed at that location or a red H if a shot has been fired that has hit.
        Prompt the user for a coordinate entry (ex: B10).
        Validate the entry; if valid, create a coordinate object, convert the letter to a number, and call the opponent board's FireShot() method.
        Retrieve the response from the FireShot method and display an appropriate message to the user.
        Reme
         */

        public void PlayGame()
        {
            bool gameOver = false;
            //welcome message
            ConsoleOutput.Welcome();

            while (gameOver == false)
            {
                int currentPlayer = DetermineWhoStarts();
            
                //run game setup
                SetupWorkflow player1 = new SetupWorkflow();
                SetupWorkflow player2 = new SetupWorkflow();
                Board player1Board;
                Board player2Board;

                //player prompt
                ConsoleOutput.PlayerStartPrompt(currentPlayer);
                if(currentPlayer == 1)
                {
                    player1Board = player1.GameSetUp();
                    player2Board = player2.GameSetUp();
                } else
                {
                    player2Board = player2.GameSetUp();
                    player1Board = player1.GameSetUp();
                }

                bool winnerFound = false;
                while (winnerFound == false)
                {
                    //Prompt the user for a coordinate entry (ex: B10). Validate the entry; if valid, create a coordinate object, convert the letter to a number, and call the opponent board's FireShot() method.
                    Coordinate shot = GetShotCoordinates();
                    FireShotResponse response;

                    if (currentPlayer == 1)
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
                        currentPlayer = SwitchPlayer(currentPlayer);
                        ConsoleOutput.PlayerTurnPrompt(currentPlayer);
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
