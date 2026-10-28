class Program
{

    const string inputFile = "input.txt";
    const string outputFile = "output.txt";

    static void Main()
    {
            try
            {
                double[][] vectors = FileWorker.input(inputFile);
                double[] vecFirst = vectors[0];
                double[] vecSecond = vectors[1];

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

            catch (Exception ex)
            {
                File.WriteAllText(outputFile, $"Problem: {ex.Message}");
                Console.WriteLine($"Problem: {ex.Message}");

            }
    }

}