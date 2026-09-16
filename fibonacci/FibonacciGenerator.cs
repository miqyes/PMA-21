using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

public static class FibonacciGenerator
{
    public static List<BigInteger> Generate(IReadOnlyList<BigInteger> seedNumbers, int count)
    {
        if (seedNumbers == null || seedNumbers.Count < 2)
            throw new ArgumentException("seedNumbers must contain >=2.", nameof(seedNumbers));

        if (count <= 0)
            return new List<BigInteger>();

        List<BigInteger> result = new List<BigInteger>(count);
        result.Add(seedNumbers[0]);

        if (count > 1)
        {
            result.Add(seedNumbers[1]);
            GenerateRecursive(seedNumbers[0], seedNumbers[1], count - 2, result);
        }

        return result;
    }

    private static void GenerateRecursive(BigInteger a, BigInteger b, int remaining, List<BigInteger> result)
    {
        if (remaining <= 0)
            return;

        BigInteger next = a + b;
        result.Add(next);

        GenerateRecursive(b, next, remaining - 1, result);
    }

    public static void SaveToFile(List<BigInteger> numbers, string filePath)
    {
        const int bufferSize = 8 * 1024 * 1024;

        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.ASCII, bufferSize))
        {
            if (numbers != null && numbers.Count > 0)
            {
                writer.Write(string.Join(',', numbers));
            }
        }
    }
}