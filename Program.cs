using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        public static int[] readNumbers(string path)
        {
            string[] numbers = File.ReadAllText(path).Split();
            int[] ints = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                ints[i] = int.Parse(numbers[i]);
            }
            return ints;
        }
        public static int readStep(string path)
        {
            string number = File.ReadAllText(path);
            int step = int.Parse(number);
            return step;
        }
        public static void writeFibonacci(string path, List<int> fib, List<int> fiblimit)
        {
            File.WriteAllText(path, string.Join(" ", fib));
            File.AppendAllText(path, "\n" + string.Join(" ", fiblimit));
        }
        static void Main(string[] args)
        {
           

        string input1 = "input.txt";
            string input2 = "step.txt";
            string input3 = "limit.txt";

            int[] numbers = readNumbers(input1);
            int step = readStep(input2);
            int limit = readStep(input3);

            List<int> fib = new List<int>();
            fib.Add(numbers[0]);    
            fib.Add(numbers[1]);    
           Fibonacci.CalculateFibonacci(step, fib);

            List<int> fiblimit = new List<int>();
            fiblimit.Add(numbers[0]);
            fiblimit.Add(numbers[1]);
            Fibonacci.CalculateFibonacciLimitations(limit, fiblimit);

            string output = "output.txt";
            Console.WriteLine("Finish");
           writeFibonacci(output, fib, fiblimit);
            


        }
    }
}
