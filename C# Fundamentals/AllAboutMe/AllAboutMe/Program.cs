using System;

namespace AllAboutMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Tia";
            string favFood = "food";
            byte numOfPets = 2;
            bool gnocchi = false;
            byte whistleAge = 8;

            Console.WriteLine($"Hello! My name is {name}. \n" +
                $"I have {numOfPets} dogs. \n" +
                $"My favorite food is {favFood}. \n" +
                $"It is {gnocchi} that I have eaten gnocchi. \n" +
                $"I was {whistleAge} when I learned to whistle");
        }
    }
}
