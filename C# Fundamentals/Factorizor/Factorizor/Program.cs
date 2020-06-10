using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();
            
            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            bool notValid = true;
            int userInputNum;
            while(notValid){
                Console.Write("Enter a number to factor: ");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput, out userInputNum)){
                    if(userInputNum > 0){
                        return userInputNum;
                    }
                }
                Console.WriteLine("That is not a positive number! \n");
            }
            return 0;
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            Console.Write("The Factors of {0} are: ", number);
            for (int current = 1; current <= number; current++)
            {
                if (number % current == 0)
                {
                    Console.Write(current + " ");
                }
            }
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int sum = 1;
            //find all divisors and add them
            for(int i=2; i*i <= number; i++){
                if (number % i == 0) {
                    if(i*i != number){
                        sum = sum + i + number/i;
                    }
                    sum = sum + i;
                }
            }
            // if sum == num then num is perfect
            if(sum == number && number != 1){
                Console.WriteLine("\n{0} is a perfect number", number);
            } else {
                Console.WriteLine("\n{0} is not a perfect number", number);
            }
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            int count = 0;
            for(int i = 1; i <= number; i++){
                if(number % i == 0){
                    count ++;
                }
            }
            if(count == 2 ){
                Console.WriteLine("{0} is a prime number!", number);
            } else {
                Console.WriteLine("{0} is not a prime number!", number);
            }
        }
    }
}
