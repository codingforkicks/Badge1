using System;

namespace HealthyHearts
{
    /*Make a simple calculator that asks the user for their age. Then calculate the healthy heart rate range for that age, and display it.

    Their maximum heart rate should be 220 - their age.
    The target heart rate zone is the 50 - 85% of the maximum.
     */
    class Program
    {
        //get user input
        static int getInput()
        {
            int age;
            do
            {
                Console.Write("What is your age? ");
                string response = Console.ReadLine();

                if (int.TryParse(response, out age))
                {
                    return age;
                }
                Console.WriteLine("Invalid input");
            } while (true);
        }

        //target heart rate
        static int targetHeartRate(int age)
        {
            const int MAX = 220;
            return MAX - age;
        }
        //target heart rate
        static int[] targetHeartRateZone(int rate)
        {
            const double MIN = .50;
            const double MAX = .85;

            int[] range = { Convert.ToInt32(rate*MIN), Convert.ToInt32(rate*MAX)};

            return range;
        }
        static void Main(string[] args)
        {
            int age = getInput();
            int targetRate = targetHeartRate(age);
            int rangeMin = targetHeartRateZone(targetRate)[0];
            int rangeMax = targetHeartRateZone(targetRate)[1];

            Console.WriteLine($"Your maximum heart rate should be {targetRate} beats per minute");
            Console.WriteLine($"Your target HR Zone is {rangeMin} - {rangeMax} beats per minute");
        }
    }
}
