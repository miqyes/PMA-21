using MatrixApp;

internal class Program
{
    static void Main()
    {
        string inputPath = "matrices.txt";
        string outputPath = "res.txt";

        if (!File.Exists(inputPath))
        {
            File.WriteAllText(inputPath,
                "1 2\n" +
                "3 4\n\n" +
                "5 6\n" +
                "7 8\n");
        }

        try
        {
            var (matA, matB) = MatrixFile.ReadMatrices(inputPath);

            using var sw = new StreamWriter(outputPath, false);

            MatrixFile.PrintMatrix("Matrix A:", matA);
            MatrixFile.WriteMatrix(sw, "Matrix A:", matA);

            MatrixFile.PrintMatrix("Matrix B:", matB);
            MatrixFile.WriteMatrix(sw, "Matrix B:", matB);

            Matrix sum = matA + matB;
            MatrixFile.PrintMatrix("Sum (A + B):", sum);
            MatrixFile.WriteMatrix(sw, "Sum (A + B):", sum);

            Matrix diff = matA - matB;
            MatrixFile.PrintMatrix("Subtract (A - B):", diff);
            MatrixFile.WriteMatrix(sw, "Subtract (A - B):", diff);

            Matrix mult = matA * matB;
            MatrixFile.PrintMatrix("Multiply (A * B):", mult);
            MatrixFile.WriteMatrix(sw, "Multiply (A * B):", mult);

            // 4. Ділення
            Matrix div = matA / matB;
            MatrixFile.PrintMatrix("Divide (A / B):", div);
            MatrixFile.WriteMatrix(sw, "Divide (A / B):", div);

            Console.WriteLine("Saved in: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}