using System;
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
            Console.WriteLine("[ERROR]: Input files dosen`t exist.");
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
        if (!long.TryParse(stepsContent, out long steps) || steps <= 0)
        {
            Console.WriteLine("[ERROR]: steps.txt повинен містити додатне ціле число.");
            return;
        }

        Console.WriteLine($"Start numbers: {num1}, {num2}");
        Console.WriteLine($"Count of elements: {steps}");

        GenerateFibonacciStream1(num1, num2, steps, outputPath);

    }
    static void GenerateFibonacciStream1(BigInteger a, BigInteger b, long steps, string outputPath)
    {
        if (steps <= 0) return;

        const int streamBufferSize = 8 * 1024 * 1024;

        using var fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, streamBufferSize);
        using var writer = new StreamWriter(fs, System.Text.Encoding.ASCII, streamBufferSize);

        writer.Write(a);

        long progressStep = steps / 100 == 0 ? 1 : steps / 100;

        for (long i = 2; i <= steps; i++)
        {
            writer.Write(',');
            writer.Write(b);

            BigInteger next = a + b;
            a = b;
            b = next;

            if (i % progressStep == 0)
            {
                Console.Write($"\r[Processing]: {i * 100 / steps}% (step: {i})");
            }
        }

        Console.WriteLine($"\n[Done] Result succesfuly saved to {outputPath}");
    }
}
