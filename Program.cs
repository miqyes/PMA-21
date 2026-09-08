// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections.Generic;


namespace Fibonacci
{
    class Program
    {
        //build all necessary Fibonacci numbers
        static void Fibonacci(List<int> fibonacciNumbers, int steps)
        {
            if (steps < 1)
            {
                return ;
            }
            else
            {
                int nextFibonacciNumber = fibonacciNumbers[fibonacciNumbers.Count-1] + fibonacciNumbers[fibonacciNumbers.Count - 2];

                fibonacciNumbers.Add(nextFibonacciNumber);
                Fibonacci(fibonacciNumbers, steps - 1);
            }
        }

        
        static void Main()
        {
            List<int> fibonacciNumbers;
            int steps;

            //read 2 first Fibonacci numbers
            string initialNumbersString = File.ReadAllText("C:\\Users\\annal\\RiderProjects\\Fibonacci\\input.txt");
            List<string> initialNumbersStringList = initialNumbersString.Split(',').ToList();
            try
            {
                fibonacciNumbers = initialNumbersStringList.Select(int.Parse).ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("input.txt problem:" + e.Message);
                return;
            }

            //read count of all Fibonacci numbers to build
            string stepsString = File.ReadAllText("C:\\Users\\annal\\RiderProjects\\Fibonacci\\steps.txt");
            try
            {
                steps = int.Parse(stepsString);
            }
            catch (Exception e)
            {
                Console.WriteLine("steps.txt problem: " + e.Message);
                return;
            }
            
            //we already have 2 numbers, so need steps-2 more
            Fibonacci(fibonacciNumbers, steps - 2);
            
            string outputText = string.Join(", ", fibonacciNumbers);
            File.WriteAllText("C:\\Users\\annal\\RiderProjects\\Fibonacci\\output.txt", outputText);
          
        }
    }
}