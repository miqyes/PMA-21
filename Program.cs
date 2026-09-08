using System;
namespace fibonacci
{
    class Program
    {
        static List<int> Fibonacci(List<int> numbers, int steps)
        {
            if (steps <= 0)
            {
                return numbers;
            }
            int nextNum = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
            numbers.Add(nextNum);
            return Fibonacci(numbers, steps - 1);
        }
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
            List<int> list = new List<int>();

            list.Add(first);
            list.Add(second);

            Fibonacci(list, steps);

            string result = string.Join(",", list);
            File.WriteAllText("output.txt", result);
            Console.WriteLine(Path.GetFullPath("output.txt"));
            Console.WriteLine(result);
        }
    }
}