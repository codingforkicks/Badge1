using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        static void Execute()
        {
            //TODO:  Implement FizzBuzz
            /* Write a loop that outputs the numbers from 1 to 100 in the console.
                If the number is a multiple of 3, print the word “Fizz” next to the number.
                If the number is a multiple of 5, print the word “Buzz” next to the number.
                If it is both, print “FizzBuzz” next to the number. */
            bool notValid = true;
            int num = 0;

            while(notValid){
                Console.WriteLine("Enter a number for Fizzbuzz: ");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out num)){
                    notValid = false;
                }
            }

            for(int i = 1; i <= num; i++){
                if(i % 5 == 0 && i % 3 == 0){
                    Console.WriteLine("{0} Fizzbuzz", i);
                } else if (i % 3 == 0){
                    Console.WriteLine("{0} Fizz", i);
                } else if (i % 5 == 0){
                    Console.WriteLine("{0} Buzz", i);
                } else{
                    Console.WriteLine(i);
                }
            }
        }
    }
}
