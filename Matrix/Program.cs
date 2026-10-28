class Program
{
    const string matrixA = "matrixA.txt";
    const string matrixB = "matrixB.txt";
    const string result = "result.txt";

    static void Main()
    {
        try
        {
            double[,] matA = FileWorker.ReadMatrix(matrixA);
            double[,] matB = FileWorker.ReadMatrix(matrixB);

            string addStr = $"({Matrix.ToStr(matA)}) + ({Matrix.ToStr(matB)}) = ({Matrix.ToStr(Matrix.add(matA, matB))})";
            string subStr = $"({Matrix.ToStr(matA)}) - ({Matrix.ToStr(matB)}) = ({Matrix.ToStr(Matrix.subtract(matA, matB))})";
            string mulStr = $"({Matrix.ToStr(matA)}) * ({Matrix.ToStr(matB)}) = ({Matrix.ToStr(Matrix.multiply(matA, matB))})";
            string divStr = "";
            try
            {
                divStr = $"({Matrix.ToStr(matA)}) / ({Matrix.ToStr(matB)}) = ({Matrix.ToStr(Matrix.divide(matA, matB))})";
            }
            catch (DivideByZeroException ex)
            {
                divStr = $"({Matrix.ToStr(matA)}) / ({Matrix.ToStr(matB)}) = Error: Division by zero ({ex.Message})";
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