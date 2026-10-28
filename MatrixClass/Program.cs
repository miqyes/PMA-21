class Program
{
    const string matrixA = "matrixA.txt";
    const string matrixB = "matrixB.txt";
    const string result = "result.txt";

    static void Main()
    {
        try
        {
            Matrix matA = FileWorker.ReadMatrix(matrixA);
            Matrix matB = FileWorker.ReadMatrix(matrixB);

            string addStr = $"({matA}) + ({matB}) = ({matA.add(matB)})";
            string subStr = $"({matA}) - ({matB}) = ({matA.subtract(matB)})";
            string mulStr = $"({matA}) * ({matB}) = ({matA.multiply(matB)})";
            string divStr;
            try
            {
                divStr = $"({matA}) / ({matB}) = ({matA.divide(matB)})";
            }
            catch (DivideByZeroException ex)
            {
                divStr = $"({matA}) / ({matB}) = Error: Division by zero ({ex.Message})";
                Console.WriteLine($"Problem with division: {ex.Message}");
            }
            FileWorker.WriteResults(result, new string[] { addStr, subStr, mulStr, divStr });
            Console.WriteLine("Done. Check the output file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}