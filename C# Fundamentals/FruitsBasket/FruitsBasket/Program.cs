using System;

namespace FruitsBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] fruit = { "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Apple", "Apple", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Orange", "Orange", "Orange", "Apple", "Apple", "Apple", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Apple", "Orange", "Orange" };
            int apple = 0;
            int orange = 0;

            for(int i = 0; i < fruit.Length; i++)
            {
                if (fruit[i] == "Apple")
                    apple++;
                else if (fruit[i] == "Orange")
                    orange++;
                else
                    break;
            }

            Console.WriteLine("Total # of Fruit in Basket: {0}", fruit.Length);
            Console.WriteLine("Number of Apples {0}", apple);
            Console.WriteLine("Number of Oranges {0}", orange);

        }
    }
}
