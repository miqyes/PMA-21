class Program
{

    private static string inputFile = "input.txt";
    private static string outputFile = "output.txt";

    public static void output(string text, double[] vecFirst, double[] vecSecond, double[] vecResult, char operation)
    {
        using (StreamWriter writer = new StreamWriter(outputFile, true))
        {
            writer.WriteLine($"{text}({string.Join(";", vecFirst)}) {operation} ({string.Join(";", vecSecond)}) = ({string.Join(";", vecResult)})");
        }
    }

    static void Main()
    {
        File.WriteAllText(outputFile, "");

        string[] lines = File.ReadAllLines(inputFile);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] vector = line.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries); 
            double[] vecFirst = vector[0].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            char operation = vector[1].Trim()[0];
            double[] vecSecond = vector[2].Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] result = null;

            switch (operation)
            {
                case '+':
                    result = VectorMath.add(vecFirst, vecSecond);
                    break;
                case '-':
                    result = VectorMath.subtract(vecFirst, vecSecond);
                    break;
                case '*':
                    result = VectorMath.multiply(vecFirst, vecSecond);
                    break;
                case '/':
                    try
                    {
                        result = VectorMath.divide(vecFirst, vecSecond);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Problem in line '{line}': {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown operation: {operation}");
                    continue;

            }

            if (result != null)
            {
                output("Result: ", vecFirst, vecSecond, result, operation);
            }
        }

        Console.WriteLine("Done. Check the output file.");

    }

}