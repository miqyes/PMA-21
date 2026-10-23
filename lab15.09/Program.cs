namespace lab15._09;

class Program
{
    static void Main()
    {

        string inputFile = "vector.txt";
        string outputFile = "result.txt";

        double[][] vectors;
        
        try
        {
            vectors = Files.ReadVectors(inputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error while reading file: " + ex.Message);
            return;
        }

        if (vectors.Length < 2)
        {
            Console.WriteLine("File must contain at least 2 vectors");
            return;
        }

        int pairsCount = vectors.Length - 1;
        string[] report = new string[pairsCount * 6];
        int reportIndex = 0;

        for (int i = 0; i < pairsCount; i++)
        {
            double[] vectorOne = vectors[i];
            double[] vectorTwo = vectors[i + 1];

            string formattedOne = Vector.Format(vectorOne);
            string formattedTwo = Vector.Format(vectorTwo);

            report[reportIndex++] = $"--- Pair {i + 1} and {i + 2} ---";

            try
            {
                double[] sum = Vector.Add(vectorOne, vectorTwo);
                report[reportIndex++] = $"{formattedOne} + {formattedTwo} = {Vector.Format(sum)}";

                double[] sub = Vector.Subtract(vectorOne, vectorTwo);
                report[reportIndex++] = $"{formattedOne} - {formattedTwo} = {Vector.Format(sub)}";

                double[] mul = Vector.Multiply(vectorOne, vectorTwo);
                report[reportIndex++] = $"{formattedOne} * {formattedTwo} = {Vector.Format(mul)}";

                string divResult = Vector.Divide(vectorOne, vectorTwo);
                report[reportIndex++] = $"{formattedOne} / {formattedTwo} = {divResult}";
            }
            catch (InvalidOperationException ex)
            {
                report[reportIndex++] = $"Dimension error: {ex.Message}";
            }

            report[reportIndex++] = "";
        }

        Files.WriteLines(outputFile, report);
        Console.WriteLine("Results saved to " + outputFile);
    }
}