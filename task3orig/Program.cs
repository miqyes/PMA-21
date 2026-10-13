namespace task3orig
{
    class Program
    {
        private const string FirstMatrixFile = "first.txt";
        private const string SecondMatrixFile = "second.txt";
        private const string ResultFile = "result.txt";

        static void Main()
        {
            try
            {
                Matrix firstMatrix = FileWorker.ReadMatrix(FirstMatrixFile);
                Matrix secondMatrix = FileWorker.ReadMatrix(SecondMatrixFile);

                if (firstMatrix.Size != secondMatrix.Size)
                {
                    Console.WriteLine("Error: matrices must have the same size.");
                    return;
                }

                FileWorker.WriteResult(ResultFile, ReportBuilder.Build(firstMatrix, secondMatrix));
                Console.WriteLine("Result in " + ResultFile);
            }
            catch (Exception ex) when (ex is IOException or FormatException)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}