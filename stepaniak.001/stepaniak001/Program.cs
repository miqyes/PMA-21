using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static List<int> GenerateFibonacci(int first, int second, int steps){
        List<int> sequence = new List<int>();
        sequence.Add(first);
        sequence.Add(second);
        for(int i = 2; i < steps; i++){
            sequence.Add(sequence[i - 1] + sequence[i - 2]);
        }
        return sequence;
    }
    static void Main()
    {
        string input = "C:\\Users\\USER\\Desktop\\unik_labs\\stepaniak.001\\semeriak.001\\info\\input.txt";
        string steps = "C:\\Users\\USER\\Desktop\\unik_labs\\stepaniak.001\\semeriak.001\\info\\steps.txt";
        string output = "C:\\Users\\USER\\Desktop\\unik_labs\\stepaniak.001\\semeriak.001\\info\\output.txt";

        if (!File.Exists(input) || !File.Exists(steps)){
            Console.WriteLine("[ERROR] Input files don't exist.");
            return;
        }

        try
        {
            string inputContent = File.ReadAllText(input);
            string stepsContentString = File.ReadAllText(steps).Trim();
            int stepsContent = int.Parse(stepsContentString);

            int[] inputNumbers = inputContent
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (inputNumbers.Length < 2)
            {
                Console.WriteLine("[ERROR] File input.txt has <2 numbers");
                return;
            }

            if (stepsContent < 1)
            {
                Console.WriteLine("[ERROR] File steps.txt number must be >0");
                return;
            }

            List<int> fibonacciSequence = GenerateFibonacci(inputNumbers[0], inputNumbers[1], stepsContent);

            string result = string.Join(", ", fibonacciSequence);

            File.WriteAllText(output, result);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
    }
}