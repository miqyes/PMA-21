using System.Numerics;

namespace Task1Fibonacci;

class Program
{
    private const string StepsFilePath = "steps.txt";
    private const string InputFilePath = "input.txt";
    private const string OutputFilePath = "output.txt";

    static void Main()
    {
        int count = int.Parse(File.ReadAllText(StepsFilePath).Trim());

        List<BigInteger> numbers = File.ReadAllText(InputFilePath)
            .Split(',')
            .Select(p => BigInteger.Parse(p.Trim()))
            .ToList();

        Fibonacci.Generate(count, numbers);

        File.WriteAllText(OutputFilePath, string.Join(", ", numbers));
        Console.WriteLine($"Saved in {OutputFilePath}");
    }
}