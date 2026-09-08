using System;
using System.IO;
namespace Фібоначчі
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllText("input.txt");
            int steps = int.Parse(File.ReadAllText("steps.txt"));

            string[] numbers = input.Split(',');
            int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);

            string result = a + "," + b;
            for (int i = 2; i < steps; i++)
            {
                int next = a + b;
                result = result + "," + next;
                a = b;
                b = next;
            }
            Console.WriteLine("Result: " + result);
            File.WriteAllText("result.txt", result);
        }
    }
}