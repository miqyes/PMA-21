using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string input = File.ReadAllText("input.txt");
            Console.WriteLine(input);
            string[] parts = input.Split(" ");
           // Console.WriteLine(parts[0]);
           // Console.WriteLine(parts[1]);
           int firstsum = int.Parse(parts[0]);
           int secondsum = int.Parse(parts[1]);
           string steps = File.ReadAllText("steps.txt");
           int stepcount = int.Parse(steps);
           List<int> numbers = new List<int> {firstsum,secondsum};
           
           FibonacciRecursive(numbers, stepcount);
           foreach (int i in numbers)
           {
               Console.WriteLine(i + " ");
           }
           string result= string.Join (" ", numbers);
           File.WriteAllText("result.txt", result);
           
        }
        static void FibonacciRecursive(List<int> numbers, int stepcount)
        {
            if (numbers.Count >= stepcount)
            {
                return; 
            }
            int new_element = numbers[^1] + numbers[^2];
            numbers.Add(new_element);
            FibonacciRecursive(numbers, stepcount);
        }
    }
}
