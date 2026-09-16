using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string stepsPath = "steps.txt";
        string outputPath = "output.txt";

        if (!File.Exists(inputPath) || !File.Exists(stepsPath))
        {
            Console.WriteLine("[ERROR]: Input files don't exist.");
            return;
        }

        string inputContent = File.ReadAllText(inputPath);
        string[] parts = inputContent.Split(new[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2 ||
            !BigInteger.TryParse(parts[0], out BigInteger num1) ||
            !BigInteger.TryParse(parts[1], out BigInteger num2))
        {
            Console.WriteLine("[ERROR]: File input.txt must contain at least 2 valid numbers.");
            return;
        }

        string stepsContent = File.ReadAllText(stepsPath).Trim();
        if (!BigInteger.TryParse(stepsContent, out BigInteger value) || value <= 0)
        {
            Console.WriteLine("[ERROR]: steps.txt must contain a positive number.");
            return;
        }

        Console.WriteLine($"Start numbers: {num1}, {num2}");

        var numbers = new List<BigInteger> { num1, num2 };
        int count = (int)value;


        Console.WriteLine($"Count of elements: {count}");
        FibonacciGenerator.GenerateByCount(count, numbers);

        // Console.WriteLine($"Max limit value: {value}");
        // FibonacciGenerator.GenerateByLimit(value, numbers);
        FibonacciGenerator.SaveToFile(numbers, outputPath);

        Console.WriteLine($"[Done] Successfully saved {numbers.Count} numbers to {outputPath}");
    }
}