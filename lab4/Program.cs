namespace matrixLab
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFilePath = "input.txt";
                string outputFilePath = "result.txt";
                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Input file not found at: {inputFilePath}");
                }
                string fileContent = File.ReadAllText(inputFilePath);
                List<double[,]> matrices = Matrix.parseMatricesFromFile(fileContent);

                if (matrices.Count < 2)
                {
                    throw new InvalidOperationException("The file must contain at least two matrices.");
                }

                double[,] matrixA = matrices[0];
                double[,] matrixB = matrices[1];

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Initial matrix:");
                    writer.WriteLine("Matrix A:");
                    Matrix.writeMatrixToStream(writer, matrixA);

                    writer.WriteLine("Matrix B:");
                    Matrix.writeMatrixToStream(writer, matrixB);
                    writer.WriteLine();
                    writer.WriteLine("Addition");
                    try
                    {
                        double[,] addResult = Matrix.addMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, addResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform addition: {ex.Message}");
                    }
                    writer.WriteLine();
                    writer.WriteLine("Subtraction");
                    try
                    {
                        double[,] subResult = Matrix.subtractMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, subResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform subtraction: {ex.Message}");
                    }
                    writer.WriteLine();
                    writer.WriteLine("Multiplication");
                    try
                    {
                        double[,] mulResult = Matrix.multiplyMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, mulResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform multiplication: {ex.Message}");
                    }
                    writer.WriteLine();
                    writer.WriteLine("Division");
                    try
                    {
                        double[,] divResult = Matrix.divideMatrices(matrixA, matrixB);
                        Matrix.writeMatrixToStream(writer, divResult);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"Could not perform division: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
