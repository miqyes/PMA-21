class Program
{

    const string inputFile = "input.txt";
    const string outputFile = "output.txt";

    public static void output(double[] vecFirst, double[] vecSecond, double[] vecResult, char operation)
    {
        using (StreamWriter writer = new StreamWriter(outputFile, true))
        {
            writer.WriteLine($"({string.Join(";", vecFirst)}) {operation} ({string.Join(";", vecSecond)}) = ({string.Join(";", vecResult)})");
        }
    }

    static void Main()
    {
        File.WriteAllText(outputFile, "");

        string[] lines = File.ReadAllLines(inputFile);

        if (lines.Length >= 2)
        {
            double[] vecFirst = lines[0].Split( ',').Select(double.Parse).ToArray();
            double[] vecSecond = lines[1].Split( ',').Select(double.Parse).ToArray();
            double[] result = null;
            output(vecFirst, vecSecond, VectorMath.add(vecFirst, vecSecond), '+');
            output(vecFirst, vecSecond, VectorMath.subtract(vecFirst, vecSecond), '-');
            output(vecFirst, vecSecond, VectorMath.multiply(vecFirst, vecSecond), '*');

            try
            {
                output(vecFirst, vecSecond, VectorMath.divide(vecFirst, vecSecond), '/');
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Problem with division: {ex.Message}");
            }

        }
            Console.WriteLine("Done. Check the output file.");

    }

}
