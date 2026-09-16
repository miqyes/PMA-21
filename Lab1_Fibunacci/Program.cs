using System;
using System.IO;

namespace Fibonacci
{
    class Fibonacci
    {
        public static long[] CreateRow(long first, long second, int steps)
        {
            long[] row = new long[steps];

            for (int i = 0; i < steps; i++)
            {
                if (i == 0)
                {
                    row[i] = first;
                }
                else if (i == 1)
                {
                    row[i] = second;
                }
                else
                {
                    row[i] = row[i - 1] + row[i - 2];
                }
            }

            return row;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("input.txt");
            string[] parts = text.Split(',');

            long first = long.Parse(parts[0].Trim());
            long second = long.Parse(parts[1].Trim());

            int steps = int.Parse(File.ReadAllText("step.txt").Trim());

            long[] row = Fibonacci.CreateRow(first, second, steps);

            string result = "";

            for (int i = 0; i < steps; i++)
            {
                result += row[i];

                if (i < steps - 1)
                {
                    result += ",";
                }
            }

            File.WriteAllText("output.txt", result);

            Console.WriteLine("Result: " + result);
        }
    }
}
