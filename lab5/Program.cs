
namespace classMatrix
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
                List<Matrix> matrices = Matrix.parseMatricesFromFileContent(fileContent);

                if (matrices.Count < 2)
                {
                    throw new InvalidOperationException("The file must contain at least two matrices.");
                }

                Matrix matrixA = matrices[0];
                Matrix matrixB = matrices[1];

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine("Initial matrix:");
                    writer.WriteLine("matrix a:");
                    matrixA.writeToStream(writer);
                    writer.WriteLine();

                    writer.WriteLine("matrix b:");
                    matrixB.writeToStream(writer);
                    writer.WriteLine();

                    writer.WriteLine("Addition:");
                    try
                    {
                        Matrix addResult = matrixA.add(matrixB);
                        addResult.writeToStream(writer);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"could not perform addition: {ex.Message}");
                    }
                    writer.WriteLine();

                    writer.WriteLine("Subtraction:");
                    try
                    {
                        Matrix subResult = matrixA.subtract(matrixB);
                        subResult.writeToStream(writer);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"could not perform subtraction: {ex.Message}");
                    }
                    writer.WriteLine();

                    writer.WriteLine("Multiplication:");
                    try
                    {
                        Matrix mulResult = matrixA.multiply(matrixB);
                        mulResult.writeToStream(writer);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"could not perform multiplication: {ex.Message}");
                    }
                    writer.WriteLine();

                    writer.WriteLine("Division:");
                    try
                    {
                        Matrix divResult = matrixA.divide(matrixB);
                        divResult.writeToStream(writer);
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"could not perform division: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
    }
}
