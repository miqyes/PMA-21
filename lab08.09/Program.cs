using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

class Program
{
    static void Main()
    {
        int count = int.Parse(File.ReadAllText("steps.txt").Trim());
        string[] parts = File.ReadAllText("input.txt").Trim().Split(',');
        
        List<BigInteger> numbers = new List<BigInteger>
        {
            BigInteger.Parse(parts[0].Trim()),
            BigInteger.Parse(parts[1].Trim())
        };

        Fibonacci.Generate(count, numbers);

        File.WriteAllText("output.txt", string.Join(", ", numbers));
        Console.WriteLine("Saved in output.txt");
    }
}