using System;

namespace GuessMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int answer = random.Next(0, 11);
            bool notGuessed = true;

            Console.WriteLine("Guess a number between 0 and 10: ");

            while(notGuessed)
            {
                string userGuess = Console.ReadLine();
                int userGuessNum = int.Parse(userGuess);

                if (answer == userGuessNum)
                {
                    Console.WriteLine("Wow, nice guess! That was it!");
                    notGuessed = false;
                }
                else if (userGuessNum < answer)
                    Console.WriteLine("Ha, nice try - too low! I chose {0}", answer);
                else
                    Console.WriteLine("Too bad, way too high. I chose {0}", answer);
            }
        }
    }
}
