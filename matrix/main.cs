class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string inputPath = "matrix.txt";
        string outputPath = "output.txt";

        var (matA, op, matB) = MatrixFileService.ReadMtrx(inputPath);

        double[,] result = MatrixOperation.OpProcessing(op, matA, matB);

        MatrixFileService.WriteResult(outputPath, result);
        Console.WriteLine($"Успішно обчислено та записано у {outputPath}");
    }
}