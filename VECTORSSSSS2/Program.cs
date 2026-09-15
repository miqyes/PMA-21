using System;
using System.IO;
using System.Linq;

namespace ArrVer
{
    class Program
    {
        static double[][] ReadVectors()
        {
            if (!File.Exists("vector.txt"))
            {
                Console.WriteLine("Couldn't find file vector.txt");
                Environment.Exit(1);
            }

            string[] input = File.ReadAllLines("vector.txt");
            if (input.Length < 2)
            {
                Console.WriteLine("vector.txt must contain at least 2 vectors");
                Environment.Exit(1);
            }

            double[][] vectors = new double[input.Length][];

            for (int i = 0; i < input.Length; i++)
            {
                vectors[i] = input[i].Split([", ", ",", " ", "\n", "\t", "\r"],
                    StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            return vectors;
        }


        static double[] Adding(double[] v1, double[] v2)
        {
            double[] outcome = { v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2] };
            Console.WriteLine($"Adding: ({string.Join(",", v1)}) + ({string.Join(",", v2)}) = ({string.Join(",", outcome)})");
            return outcome;
        }


        static double[] Subtracting(double[] v1, double[] v2)
        {
            double[] outcome = { v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2] };
            Console.WriteLine($"Subtraction: ({string.Join(",", v1)}) - ({string.Join(",", v2)}) = ({string.Join(",", outcome)})");
            return outcome;
        }

        static double[] Multiplying(double[] v1, double[] v2)
        {
            double[] outcome = { v1[0] * v2[0], v1[1] * v2[1], v1[2] * v2[2] };
            Console.WriteLine($"Multiplying: ({string.Join(",", v1)}) * ({string.Join(",", v2)}) = ({string.Join(",", outcome)})");
            return outcome;
        }

        static double[] Dividing(double[] v1, double[] v2)
        {
            if (v2[0] == 0 || v2[1] == 0 || v2[2] == 0)
            {
                Console.WriteLine("Cant divide by zero ;3");
                Environment.Exit(1);
            }
            
            double[] outcome = { v1[0] / v2[0], v1[1] / v2[1], v1[2] / v2[2] };
            Console.WriteLine($"Dividing: ({string.Join(",", v1)}) / ({string.Join(",", v2)}) = ({string.Join(",", outcome)})");
            return outcome;
        }

        
        static void SaveToFile(double[] v1, double[] v2, double[] v3, double[] v4, double[][] vectors)
        {
            
            string result = $"Adding: ({string.Join(",", vectors[0])}) + ({string.Join(",", vectors[1])}) = ({string.Join(",", v1)})\n" +
                      $"Subtraction: ({string.Join(",", vectors[0])}) - ({string.Join(",", vectors[1])}) = ({string.Join(",", v2)})\n" +
                      $"Multiplying: ({string.Join(",", vectors[0])}) * ({string.Join(",", vectors[1])}) = ({string.Join(",", v3)})\n" +
                      $"Dividing: ({string.Join(",", vectors[0])}) / ({string.Join(",", vectors[1])}) = ({string.Join(",", v4)})";

            File.WriteAllText("result.txt", result);
        }
        
        
        static void Main()
        {
            double[][] vectors = ReadVectors();
            double[] aa1 = Adding(vectors[0], vectors[1]);
            double[] bb1 = Subtracting(vectors[0], vectors[1]);
            double[] cc1 = Multiplying(vectors[0], vectors[1]);
            double[] dd1 = Dividing(vectors[0], vectors[1]);
            
            SaveToFile(aa1, bb1, cc1, dd1, vectors);
            
        }
    }
}