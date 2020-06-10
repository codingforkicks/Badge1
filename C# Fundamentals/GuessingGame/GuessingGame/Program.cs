using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        //get user name
        static string GetUserName()
        {
            bool notValid = true;
            string name = "";
            
            while (notValid)
            {
                Console.Write("What is your name? ");
                name = Console.ReadLine();
                if (String.IsNullOrEmpty(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Whoops, your input was empty.");
                    Console.ResetColor();
                } else if(Char.IsLetter(name[0]))
                {
                    break;
                } else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} doesn't look right...names must start with a character A-Z", name);
                    Console.ResetColor();
                }
            }
            return name;
        }

        //intro message for game
        static void introMessage(string userName)
        {
            Console.Clear();
            Console.WriteLine("Hello, {0}. Welcome to the game", userName);
            Console.WriteLine("I am thinking of a number, can you guess it?");
        }

        //select mode
        static int modeSelect()
        {
            const int EASY = 5;
            const int NORMAL = 20;
            const int HARD = 50;
            int mode;
            bool modeSelected = false;

            do
            {
                Console.WriteLine("\nSelect your mode:\n" +
                    "1 = Easy mode 1-5\n" +
                    "2 = Normal mode 1 - 20\n" +
                    "3 = Hard mode 1 - 50");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out mode))
                {
                    if(mode > 3 || mode < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input was not valid. Plese enter 1-3");
                        Console.ResetColor();
                    } else if (mode == 1) {
                        mode = EASY;
                        modeSelected = true;
                        Console.Clear();
                        Console.WriteLine("Easy mode selected!");
                    } else if (mode == 2)
                    {
                        mode = NORMAL;
                        modeSelected = true;
                        Console.Clear();
                        Console.WriteLine("Normal mode selected!");
                    } else
                    {
                        mode = HARD;
                        modeSelected = true;
                        Console.Clear();
                        Console.WriteLine("Hard mode selected!");
                    }
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input was not valid.");
                    Console.ResetColor();
                }
            } while (!modeSelected);

            return mode;
        }

        static void Main(string[] args)
        {
            int theAnswer;
            int playerGuess;
            string playerInput;
            int count = 0;

            //welcome and get user name
            string name = GetUserName();
            introMessage(name);

            //get limit
            int modeLimit = modeSelect();

            Random r = new Random();
            theAnswer = r.Next(1, modeLimit + 1);


            do
            {
                // get player input
                Console.Write("Enter your guess (1-{0} or Q to quit): ", modeLimit);
                playerInput = Console.ReadLine();

                //exit game if input is q
                if(playerInput == "q" || playerInput == "Q")
                {
                    return;
                }
                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    count++;
                    if (playerGuess == theAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        if(count == 1)
                        {
                            Console.Write("HOLE IN ONE!!! ");
                        }
                        Console.WriteLine($"{theAnswer} was the number.  You Win!");
                        break;
                    }
                    else
                    {
                        if (playerGuess <= 20 && playerGuess > 0)
                        {
                            Console.WriteLine("Your guess was outside the given range {0}", name);
                        }
                        else if (playerGuess > theAnswer)
                        {
                            Console.WriteLine("Your guess was too High {0}!", name);
                        }
                        else
                        {
                            Console.WriteLine("Your guess was too low {0}!", name);
                        }
                    }
                } else
                {
                    Console.WriteLine("That wasn't a number {0}!", name);
                }

            } while (true);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
