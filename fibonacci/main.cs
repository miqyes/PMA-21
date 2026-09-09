using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string stepsPath = "steps.txt";
        string outputPath = "output.txt";

        if (!File.Exists(inputPath) || !File.Exists(stepsPath))
        {
            Console.WriteLine("[ERROR]: Input files doesn't exist.");
            return;
        }

        string inputContent = File.ReadAllText(inputPath);
        string[] parts = inputContent.Split(new[] { ',', ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2 ||
            !BigInteger.TryParse(parts[0], out BigInteger num1) ||
            !BigInteger.TryParse(parts[1], out BigInteger num2))
        {
            Console.WriteLine("[ERROR]: File input.txt must contain >=2 symbols.");
            return;
        }

        string stepsContent = File.ReadAllText(stepsPath).Trim();
        if (!int.TryParse(stepsContent, out int steps) || steps <= 0)
        {
            Console.WriteLine("[ERROR]: steps.txt must contain a positive integer.");
            return;
        }

        Console.WriteLine($"Start numbers: {num1}, {num2}");
        Console.WriteLine($"Count of elements: {steps}");

        FibonacciGenerator generator = new FibonacciGenerator(num1, num2, steps);

        List<BigInteger> fibonacciList = generator.Generate();

        generator.SaveToFile(fibonacciList, outputPath);

        Console.WriteLine($"[Done] Result successfully saved to {outputPath}");
    }
}