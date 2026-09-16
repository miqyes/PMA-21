using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

public static class FibonacciGenerator
{
    public static void GenerateByCount(int count, List<BigInteger> numbers)
    {
        if (numbers == null || numbers.Count < 2 || numbers.Count >= count)
            return;

        BigInteger next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];
        numbers.Add(next);

        GenerateByCount(count, numbers);
    }
    public static void GenerateByLimit(BigInteger limit, List<BigInteger> numbers)
    {
        if (numbers == null || numbers.Count < 2)
            return;

        BigInteger next = numbers[numbers.Count - 1] + numbers[numbers.Count - 2];

        if (next > limit)
            return;

        numbers.Add(next);

        GenerateByLimit(limit, numbers);
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