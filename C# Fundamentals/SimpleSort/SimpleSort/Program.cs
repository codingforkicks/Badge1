using System;

namespace SimpleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstHalf = { 3, 7, 9, 10, 16, 19, 20, 34, 55, 67, 88, 99 };
            int[] secondHalf = { 1, 4, 8, 11, 15, 18, 21, 44, 54, 79, 89, 100 };

            int[] wholeNumbers = new int[24];

            int firstHalfIndex = 0;
            int secondHalfIndex = 0;

            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                if(firstHalfIndex >= firstHalf.Length)
                {
                    wholeNumbers[i] = secondHalf[secondHalfIndex];
                    break;
                }
                if (secondHalfIndex >= secondHalf.Length)
                {
                    wholeNumbers[i] = firstHalf[firstHalfIndex];
                    break;
                }
                if (firstHalf[firstHalfIndex] < secondHalf[secondHalfIndex])
                {
                    wholeNumbers[i] = firstHalf[firstHalfIndex];
                    firstHalfIndex++;
                }
                else if(firstHalf[firstHalfIndex] > secondHalf[secondHalfIndex])
                {
                    wholeNumbers[i] = secondHalf[secondHalfIndex];
                    secondHalfIndex++;
                }
            }

            for (int i = 0; i < wholeNumbers.Length; i++)
            {
                Console.Write(wholeNumbers[i] + " " );
            }
        }
    }
}
