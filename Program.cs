using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

public class Fibonacci
{
    public static void Generate(BigInteger a, BigInteger b, int count, List<BigInteger> result)
    {
        if (count <= 0)
            return;

        result.Add(a);
        Generate(b, a + b, count - 1, result);
    }
}

class Program
{
    static void Main()
    {
        string inputData = File.ReadAllText("input.txt");
        BigInteger[] numbers = inputData
            .Split(new char[] { ',', ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();

        int steps = int.Parse(File.ReadAllText("steps.txt").Trim());

        List<BigInteger> sequence = new List<BigInteger>();
        Fibonacci.Generate(numbers[0], numbers[1], steps, sequence);

        string result = string.Join(", ", sequence);
        File.WriteAllText("output.txt", result);

        Console.WriteLine("Saved to output.txt: " + result);
    }
}