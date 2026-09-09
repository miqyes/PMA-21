using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

public class FibonacciGenerator
{
    private BigInteger first;
    private BigInteger second;
    private int count;

    public FibonacciGenerator(BigInteger first, BigInteger second, int count)
    {
        this.first = first;
        this.second = second;
        this.count = count;
    }

    public List<BigInteger> Generate()
    {
        List<BigInteger> result = new List<BigInteger>(count);

        if (count <= 0)
            return result;

        result.Add(first);
        if (count == 1)
            return result;

        result.Add(second);

        BigInteger a = first;
        BigInteger b = second;

        for (int i = 2; i < count; i++)
        {
            BigInteger next = a + b;
            result.Add(next);
            a = b;
            b = next;
        }

        return result;
    }

    public void SaveToFile(List<BigInteger> numbers, string filePath)
    {
        int bufferSize = 8 * 1024 * 1024;

        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.ASCII, bufferSize))
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i > 0)
                {
                    writer.Write(',');
                }
                writer.Write(numbers[i]);
            }
        }
    }
}