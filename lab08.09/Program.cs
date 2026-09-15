using System;
using System.Collections.Generic;
using System.IO;

class Fibonacci
{
    public static void Generate(int count, int a, int b, List<int> result)
    {
        if (result.Count >= count) return;
        result.Add(a);
        Generate(count, b, a + b, result);
    }
}

class Program
{
    static void Main()
    {
        int count = int.Parse(File.ReadAllText("steps.txt").Trim());
        string[] parts = File.ReadAllText("input.txt").Trim().Split(',');
        int first = int.Parse(parts[0]);
        int second = int.Parse(parts[1]);

        List<int> result = new List<int>(count);
        Fibonacci.Generate(count, first, second, result);

        File.WriteAllText("output.txt", string.Join(", ", result));
        Console.WriteLine("Saved in output.txt");
    }
}