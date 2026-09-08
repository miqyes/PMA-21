using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main()
        {
            if (!File.Exists("input.txt") || !File.Exists("steps.txt"))
            {
                Console.WriteLine("Error, couldn't find needed files");
                return;
            }
            string input = File.ReadAllText("input.txt");
            string[] parts = input.Split(", ");
            int firstnum = int.Parse(parts[0]);
            int secondnum = int.Parse(parts[1]);

            string steps = File.ReadAllText("steps.txt");
            int stepscount = int.Parse(steps);


            List<int> seq = new List<int> { firstnum, secondnum };

            FibonacciRecursive(seq, stepscount);

            foreach (int i in seq)
            {
                Console.Write(i + " ");
            }

            string result = string.Join(", ", seq);
            File.WriteAllText("output.txt", result);

        }

        static void FibonacciRecursive(List<int> seq, int stepscount)
        {
            if (seq.Count >= stepscount)
            {
                return;
            }

            int new_element = seq[^1] + seq[^2];
            seq.Add(new_element);
            FibonacciRecursive(seq, stepscount); ////////////////////////
        }
    }
}
