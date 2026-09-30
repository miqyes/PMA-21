class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string inputPath = "matrix.txt";
        string outputPath = "output.txt";

        try
        {
            MatrixFileService.ReadMtrx(inputPath, out double[,] matA, out string op, out double[,] matB);

            double[,] result = MatrixOperation.OpProcessing(op, matA, matB);

            MatrixFileService.WriteResult(outputPath, result);
            Console.WriteLine($"Успішно обчислено та записано у {outputPath}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
        }
    }
}