class Program
{

    const string inputFile = "input.txt";
    const string outputFile = "output.txt";

    static void Main()
    {
        string[] lines = File.ReadAllLines(inputFile);

        if (lines.Length >= 2)
        {
            double[] vecFirst = lines[0].Split(',').Select(double.Parse).ToArray();
            double[] vecSecond = lines[1].Split(',').Select(double.Parse).ToArray();
            string addStr = $"({string.Join(";", vecFirst)}) + ({string.Join(";", vecSecond)}) = ({string.Join(";", VectorMath.add(vecFirst, vecSecond))})";
            string subStr = $"({string.Join(";", vecFirst)}) - ({string.Join(";", vecSecond)}) = ({string.Join(";", VectorMath.subtract(vecFirst, vecSecond))})";
            string mulStr = $"({string.Join(";", vecFirst)}) * ({string.Join(";", vecSecond)}) = ({string.Join(";", VectorMath.multiply(vecFirst, vecSecond))})";
            string divStr = "";
            try
            {
                divStr = $"({string.Join(";", vecFirst)}) / ({string.Join(";", vecSecond)}) = ({string.Join(";", VectorMath.divide(vecFirst, vecSecond))})";
            }
            catch (DivideByZeroException ex)
            {
                divStr = $"({string.Join(";", vecFirst)}) / ({string.Join(";", vecSecond)}) = Error: Division by zero ({ex.Message})";
                Console.WriteLine($"Problem with division: {ex.Message}");
            }

            File.WriteAllLines(outputFile, new string[] { addStr, subStr, mulStr, divStr });
            Console.WriteLine("Done. Check the output file.");
        }

    }

}