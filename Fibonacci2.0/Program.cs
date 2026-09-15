using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static List<int> GetInitialSeq()
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Couldn't find file input.txt");
                return new List<int> { 0, 1 };
            }
            
            string input = File.ReadAllText("input.txt");
            List<int> seq = input.Split([ ", ", ",", " ", "\n", "\t", "\r"], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            if (seq.Count < 2)
            {
                Console.WriteLine ("Wrong amount of input lines");
                return new List<int> { 0, 1 };
            }

            return seq;

        }

        static int Amount()
        {
            if (!File.Exists("steps.txt"))
            {
                Console.WriteLine ("Couldn't find file steps.txt");
                return 0;
            }

            string input = File.ReadAllText("steps.txt").Trim();
            int amount = int.Parse(input);
            
            return amount;

        }

        static int GetLimit()
        {
            if (!File.Exists("limit.txt"))
            {
                Console.WriteLine ("Couldn't find file limit.txt");
            }
            string input = File.ReadAllText("limit.txt").Trim();
            int limit = int.Parse(input);
            return limit;
           
            
        }

        static void SaveToFile(List <int> seq1, List<int> seq2)
        {
           string result = "Sequence with certain amount of numbers: " + string.Join(", ", seq1) + "\n" + "Sequence with limit: " + string.Join(", ", seq2);
           File.WriteAllText("output.txt", result);
        }

        static void ShowOnConsole(List<int> seq)
        {
            foreach (int i in seq)
                {
                Console.Write(i + " ");
                }
        }

        static List<int> GenerateStepsSeq()
        {
            List<int> sseq = GetInitialSeq();
            int steps = Amount();
            Fibonacci.StepsSeq(sseq, steps);
            return sseq;
        }

        static List<int> GenerateLimSeq()
        {
            List<int> lseq = GetInitialSeq();
            int limit = GetLimit();
            Fibonacci.LimitedSeq(lseq, limit);
            return lseq;
        }
        
        static void Main()
        {
            List<int> seqSteps = GenerateStepsSeq();
            ShowOnConsole(seqSteps);
            
            Console.WriteLine();
            
            List<int> seqLimit = GenerateLimSeq();
            ShowOnConsole(seqLimit);
           
            SaveToFile(seqSteps, seqLimit);
            
        }
        
    }
}
