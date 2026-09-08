namespace FibonacciTask;
class Program
{
    static void Main(string[] args)
    {
        string sourceFile = "input.txt";
        string stepsFile = "steps.txt";
        if (!File.Exists(sourceFile) || !File.Exists(stepsFile))
        {   Console.WriteLine("File not found");
            return;
        }
        string rawInput = File.ReadAllText(sourceFile);
        string[] tokens = rawInput.Split(' ', ',');
        int start1, start2;
        if (tokens.Length < 2 || !int.TryParse(tokens[0], out start1) || !int.TryParse(tokens[1], out start2))
        {   Console.WriteLine("Not correct numbers");
            return;
        }
        if (start1 < 0 || start2 < 0 || (start1 == 0 && start2 == 0))
        {   Console.WriteLine("Invalid input(output.txt)");
            return;
        }
        string rawSteps = File.ReadAllText(stepsFile);
        int stepsCount;
        if (!int.TryParse(rawSteps, out stepsCount))
        {   Console.WriteLine("Not correct numbers");
            return;
        }
        if (stepsCount < 0)
        {  Console.WriteLine("Invalid input(steps.txt)");
            return;
        }
        List<int> sequence = new List<int>() { start1, start2 };
        ComputeFibonacci(sequence, stepsCount);
        string outputData = string.Join(" ", sequence);
        Console.WriteLine("Written to file output.txt: " + outputData);
        File.WriteAllText("output.txt", outputData);
    }

    public static List<int> ComputeFibonacci(List<int> elements, int remaining)
    {
        if (remaining > 2)
        {
            elements.Add(elements[^1] + elements[^2]);
            return ComputeFibonacci(elements, remaining - 1);
        }
        return elements;
    }
}