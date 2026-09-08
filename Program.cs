using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1 = "C:\\Users\\Користувач\\source\\repos\\Fibonacci\\input.txt";
            string input2 = "C:\\Users\\Користувач\\source\\repos\\Fibonacci\\step.txt";

            int[] numbers = Fibonacci.readNumbers(input1);
            int step = Fibonacci.readStep(input2);

            List<int> fib = new List<int>();
            Fibonacci.CalculateFibonacci(numbers[0], numbers[1], 1, step, fib);

            string output = "C:\\Users\\Користувач\\source\\repos\\Fibonacci\\output.txt";
            Fibonacci.writeFibonacci(output, fib);
        }
    }
}