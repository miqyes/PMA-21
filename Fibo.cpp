using System;
using System.IO;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"C:\Users\asus\source\repos\Fibo\Fibo\input.txt");
            int steps = int.Parse(File.ReadAllText(@"C:\Users\asus\source\repos\Fibo\Fibo\steps.txt"));

            string[] numbers = input.Split(',');
            int[] fib = new int[steps];
            fib[0] = int.Parse(numbers[0]);
            fib[1] = int.Parse(numbers[1]);

            for (int i = 2; i < steps; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            string result = string.Join(",", fib);
            File.WriteAllText(@"C:\Users\asus\source\repos\Fibo\Fibo\output.txt", result);
        }
    }