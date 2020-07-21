using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

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
        public int FindOpponentPlayerNumber(int currentPlayer)
        {
            if(currentPlayer == 1)
            {
                return 2;
            }
            return 1;
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

            //welcome message
            ConsoleOutput.Welcome();

            int currentPlayer = 0;
            if (currentPlayer == 0)
            {
                currentPlayer = DetermineWhoStarts();
            }
            
            //run game setup
            SetupWorkflow player1 = new SetupWorkflow();
            SetupWorkflow player2 = new SetupWorkflow();
            player1.GameSetUp();

            //Prompt the user for a coordinate entry (ex: B10). Validate the entry;
            string coordinates = ConsoleInput.GetCoordinates();
            //if valid, create a coordinate object, convert the letter to a number, and call the opponent board's FireShot() method.
            char row = coordinates[0];
            int column = int.Parse(coordinates.Remove(0, 1));
            int letterToNumber = (int)row % 32;

            Coordinate userEntry = new Coordinate(letterToNumber, column);

            //opponentsBoard.FireShot(userEntry);
        }
    }
}
