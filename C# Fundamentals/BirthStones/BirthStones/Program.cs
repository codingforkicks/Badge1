using System;

namespace BirthStones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What birthstone are you wanting to know?");
            string response = Console.ReadLine();
            int month = int.Parse(response);

            switch (month)
            {
                case 1:
                    Console.WriteLine("January's birthstone is Garnet");
                    break;
                case 2:
                    Console.WriteLine("February's birthstone is Amethyst");
                    break;
                case 3:
                    Console.WriteLine("March's birthstone is Aquamarine");
                    break;
                case 4:
                    Console.WriteLine("April's birthstone is Diamond");
                    break;
                case 5:
                    Console.WriteLine("May's birthstone is Emerald");
                    break;
                case 6:
                    Console.WriteLine("June's birthstone is Pearl");
                    break;
                case 7:
                    Console.WriteLine("July's birthstone is Ruby");
                    break;
                case 8:
                    Console.WriteLine("August's birthstone is Peridot");
                    break;
                case 9:
                    Console.WriteLine("September's birthstone is Sapphire");
                    break;
                case 10:
                    Console.WriteLine("October's birthstone is Opal");
                    break;
                case 11:
                    Console.WriteLine("November's birthstone is Topaz");
                    break;
                case 12:
                    Console.WriteLine("December's birthstone is Turquoise");
                    break;
                default:
                    Console.WriteLine("{0} is not a valid month", month);
                    break;
            }
        }
    }
}
