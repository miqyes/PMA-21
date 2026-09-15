using ConsoleApp4;
using System;
namespace fibonacci
{
    class Program
    {
        static void Main()
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Error: cannot find file input.txt");
                return;
            }

            string[] numbers = File.ReadAllText("input.txt").Split(',');
            if (numbers.Length < 2)
            {
                Console.WriteLine("Error: in file input.txt should be at least 2 numbers");
                return;
            }

            int first = int.Parse(numbers[0]);
            int second = int.Parse(numbers[1]);

            if (!File.Exists("steps.txt"))
            {
                Console.WriteLine("Error: cannot find file steps.txt");
                return;
            }
            int steps = int.Parse(File.ReadAllText("steps.txt"));

            if (!File.Exists("limit.txt"))
            {
                Console.WriteLine("Error: cannot find file limit.txt");
                return;

            }
            int lim = int.Parse(File.ReadAllText("limit.txt"));

            List<int> list = new List<int>();

            list.Add(first);
            list.Add(second);

            Fibonacci.Recursion(list, steps);
            Fibonacci.Limit(list, lim);   

            string result = string.Join(",", list);
            File.WriteAllText("output.txt", result);
            Console.WriteLine(result);

        }
    }
}