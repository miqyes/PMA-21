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

        if (count == 1)
            return new List<BigInteger> { seedNumbers[0] };

        if (count == 2)
            return new List<BigInteger> { seedNumbers[0], seedNumbers[1] };

        List<BigInteger> list = Generate(seedNumbers, count - 1);

        list.Add(list[^1] + list[^2]);

        return list;
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