using System;

namespace YourLifeInMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What year where you born?");
            string birthYear = Console.ReadLine();
            int birthYearNum = int.Parse(birthYear);

            Console.WriteLine("Did you know that ");

            if (birthYearNum < 2005)
                Console.WriteLine("Pixar's 'Up' came out half a decade ago.");
            if (birthYearNum < 1995)
                Console.WriteLine("The first Harry Potter came out over 15 years ago.");
            if (birthYearNum < 1985)
                Console.WriteLine("Space Jam came out not last decade, but the one before THAT.");
            if (birthYearNum < 1975)
                Console.WriteLine("The original Jurassic Park release is closer to the lunar landing, than today.");
            if (birthYearNum < 1965)
                Console.WriteLine("MASH has been around for almost half a century!");
        }
    }
}
