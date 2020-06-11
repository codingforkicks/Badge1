using System;
using System.Reflection.Metadata;

/* RULES:
    Each player chooses Rock, Paper, or Scissors.
    If both players choose the same thing, the round is a tie.
    Otherwise:
    Paper wraps Rock to win
    Scissors cut Paper to win
    Rock breaks Scissors to win
 */
namespace RockPaperScissors
{
    class Program
    {
        //get number of rounds user wants to play
        static int GetRounds(int min, int max)
        {
            int rounds;

            do {
                Console.Write("How many rounds would you like to play?" +
                    "\nPlease select a value between {0} and {1}: ", min, max);
                string response = Console.ReadLine();
                if (int.TryParse(response, out rounds))
                {
                    if (rounds > min && rounds < max)
                    {
                        return rounds;
                    } else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input {0} out of range", rounds);
                        Console.ResetColor();
                    }
                } else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} is not a number!", response);
                    Console.ResetColor();
                }
            } while (true);
        }

        //get user choice (rock, paper, scissors)
        static int GetChoice()
        {
            int choice;
            do
            {
                Console.WriteLine("Enter your choice\n" +
                    "1 = rock\n" +
                    "2 = paper\n" +
                    "3 = scissors");
                string response = Console.ReadLine();
                if (int.TryParse(response, out choice))
                {
                    if (choice > 0 && choice < 4)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input {0} out of range", choice);
                        Console.ResetColor();
                    }
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} is not a number!", response);
                    Console.ResetColor();
                }
            } while (true);
        }

        //determine round winner
        //win = return 1
        //lose = return 2
        // draw = return 3
        static int PlayRound(int userSelection, int computerSelection)
        {
            if(userSelection == computerSelection)
            {
                return 3;
            }
            else if((userSelection == 1 && computerSelection == 3) ||
                (userSelection == 2 && computerSelection == 1) ||
                (userSelection == 3 && computerSelection == 2))
            {
                return 1;
            }
            return 2;
        }

        //ending message
        static void GameOver(int[] results, int rounds)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGame Over:\n");
            Console.ResetColor();
            Console.WriteLine("Number of Rounds {0}\n" +
                "User Wins: {1}\n" +
                "User Losses: {2}\n" +
                "Ties: {3}\n", rounds, results[0], results[1], results[2]);

            if(results[0] > results[1] && results[0] > results[2])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congrats, You Won!");
                Console.ResetColor();
            } else if(results[1] > results[0] && results[1] > results[2])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, You Lose.");
                Console.ResetColor();
            } else
            {
                Console.WriteLine("It's a TIE!");
            }
        }

        //play again
        static bool PlayAgain()
        {
            do
            {
                Console.Write("Would you like to play again (y/n)? ");
                string response = Console.ReadLine();
                if (Char.IsLetter(response[0]))
                {
                    if (response.ToLower() == "y" || response.ToLower() == "yes")
                    {
                        return true;
                    }
                    else if (response.ToLower() == "n" || response.ToLower() == "no")
                    {
                        return false;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please select yes or no");
                    Console.ResetColor();
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input!");
                    Console.ResetColor();
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            const int MAX = 10;
            const int MIN = 1;
            bool stillPlaying = true;
            int currentRoundNumber = 0;
            int[] winLoseDraw = { 0, 0, 0 };
            int computerSelection;
            int userSelection;

            Console.WriteLine("Welcome to Rock Paper Scissors!");

            //get number of rounds user wants to play
            int numOfRounds = GetRounds(MIN, MAX);

            //create random variable
            Random r = new Random();

            //while they are still rounds to play
            while (stillPlaying)
            {
                if(currentRoundNumber < numOfRounds)
                {
                    //get track of rounds, grab user selection and computer selection

                    currentRoundNumber++;
                    Console.WriteLine("\nRound {0}:", currentRoundNumber);
                    userSelection = GetChoice();
                    computerSelection = r.Next(1, 3);

                    //complete vs
                    int winner = PlayRound(userSelection, computerSelection);

                    //update win/lose/draw per winner
                    if (winner == 1)
                    {
                        winLoseDraw[0] += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Round Winner: User");
                        Console.ResetColor();
                    }
                    else if (winner == 2)
                    {
                        winLoseDraw[1] += 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Round Winner: Computer");
                        Console.ResetColor();
                    }
                    else if (winner == 3)
                    {
                        winLoseDraw[2] += 1;
                        Console.WriteLine("Round: Tie");
                    }
                } else
                {
                    //if all rounds have been played
                    GameOver(winLoseDraw, currentRoundNumber);
                    bool replay = PlayAgain();

                    if (replay)
                    {
                        winLoseDraw = new int[3];
                        currentRoundNumber = 0;
                        numOfRounds = GetRounds(MIN, MAX);
                    } else
                    {
                        stillPlaying = false;
                    }
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
