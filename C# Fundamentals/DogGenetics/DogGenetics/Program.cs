using System;
using System.Reflection.PortableExecutable;

namespace DogGenetics
{
    class Program
    {
        //grab dog name from user
        static string getPetName()
        {
            Console.Write("What is your dog's name? ");
            string petName = Console.ReadLine();
            return petName;
        }
        static void Main(string[] args)
        {
            int randomNum;
            int max = 100;
            int remainingPercent = 100;
            string[] dogTypes = { "Husky", "Eskimo", "PitBull", "German Shepard", "Lab", "Basenji", "Bearded Collie", "Yokie", "Bichon", "Bloodhound", "Bulldog"};

            string petName = getPetName();

            Console.WriteLine("\nWell then, I have this highly reliable report on {0} prestigious background right here.\n", petName);

            Console.WriteLine("{0} is:\n", petName);

            //generate report
            Random r = new Random();
            int randomBreed = r.Next(0, dogTypes.Length - 1);

            while(remainingPercent > 0)
            {
                randomNum = r.Next(1, max + 1);
                if(randomBreed > dogTypes.Length - 1)
                {
                    randomBreed = 0;
                }
                if(remainingPercent - randomNum > 0)
                {
                    Console.WriteLine("{0:#\\%} {1}", randomNum, dogTypes[randomBreed]);
                    remainingPercent -= randomNum;
                    randomBreed++;
                } else if (remainingPercent != 0)
                {
                    Console.WriteLine("{0:#\\%} {1}", remainingPercent, dogTypes[randomBreed]);
                    remainingPercent = 0;
                }
            }

            Console.WriteLine("Wow, that's QUITE the dog!");

        }
    }
}
