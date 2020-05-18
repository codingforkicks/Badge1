using System;
using System.Runtime.InteropServices;

namespace MenuOfChampions
{
    class Program
    {
        static void Main(string[] args)
        {
            //styled console output
            Console.WriteLine($"WELCOME TO RESTAURANT NIGHT VALE! \n" +
                $"{"Today's Menu Is...", -2} \n\n");

            string ricoPizza = "Slice of Big Rico Pizza";
            string strawberryPie = "Invisible Strawberry Pie";
            string omlet = "Denver Omelet";
            double ricoPizzaPrice = 500.00;
            double piePrice = 2.00;
            double omletPrice = 1.50;

            //menu
            //:C adds dollar sign and shows two decimal places
            Console.WriteLine($"{ricoPizza} {ricoPizzaPrice:C}\n" +
                $"{strawberryPie} {piePrice:C}\n" +
                $"{omlet} {omletPrice:C}");
        }
    }
}
