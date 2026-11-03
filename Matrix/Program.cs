namespace Matrix
{
    class Program
    {
        private const string InputFilename = "matrix.txt";
        private const string OutputFilename = "result.txt";

        static double[][,] ReadTwoMatrices()
        {
            if (!File.Exists(InputFilename))
            {
                File.WriteAllText(OutputFilename, $"Couldn't find file {InputFilename}");
                Environment.Exit(1);
            }
            
            
            string input = File.ReadAllText(InputFilename);
            double[] parts = input.Split([", ", ",", " ", "\n", "\t", "\r"], StringSplitOptions.RemoveEmptyEntries)
                                 .Select(double.Parse)
                                 .ToArray();

            
            
            double[][,] matrices = new double[2][,];
            int index = 0;

            for (int m = 0; m < 2; m++)
            {
                matrices[m] = new double[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        matrices[m][i, j] = parts[index++];
                    }
                }
            }

            return matrices;
        }

        
        static void SaveToFile(double[,] mAdding, double[,] mSubtracting, double[,] mMultiplying, double[,] mDividing, double[][,] matrices)
        {
            double[,] a = matrices[0];
            double[,] b = matrices[1];

            string[] lines = new string[]
            {
                "Adding",
                $"{a[0, 0]} {a[0, 1]} + {b[0, 0]} {b[0, 1]} = {mAdding[0, 0]} {mAdding[0, 1]}",
                $"{a[1, 0]} {a[1, 1]}   {b[1, 0]} {b[1, 1]}   {mAdding[1, 0]} {mAdding[1, 1]}",
                "",
                "Subtraction",
                $"{a[0, 0]} {a[0, 1]} - {b[0, 0]} {b[0, 1]} = {mSubtracting[0, 0]} {mSubtracting[0, 1]}",
                $"{a[1, 0]} {a[1, 1]}   {b[1, 0]} {b[1, 1]}   {mSubtracting[1, 0]} {mSubtracting[1, 1]}",
                "",
                "Multiplying",
                $"{a[0, 0]} {a[0, 1]} * {b[0, 0]} {b[0, 1]} = {mMultiplying[0, 0]} {mMultiplying[0, 1]}",
                $"{a[1, 0]} {a[1, 1]}   {b[1, 0]} {b[1, 1]}   {mMultiplying[1, 0]} {mMultiplying[1, 1]}",
                "",
                "Dividing",
                $"{a[0, 0]} {a[0, 1]} / {b[0, 0]} {b[0, 1]} = {mDividing[0, 0]} {mDividing[0, 1]}",
                $"{a[1, 0]} {a[1, 1]}   {b[1, 0]} {b[1, 1]}   {mDividing[1, 0]} {mDividing[1, 1]}"
            };

            File.WriteAllLines(OutputFilename, lines);
        }
        

        static void Main()
        {
           
            File.WriteAllText(OutputFilename, "");
            
            double[][,] matrices = ReadTwoMatrices();
            
            double[,] adding = MatrixCalculator.Adding(matrices[0], matrices[1]);
            double[,] subtracting = MatrixCalculator.Subtracting(matrices[0], matrices[1]);
            double[,] multiplying = MatrixCalculator.Multiplying(matrices[0], matrices[1]);
            double[,] dividing = MatrixCalculator.Dividing(matrices[0], matrices[1]);

        
            SaveToFile(adding, subtracting, multiplying, dividing, matrices);
            
            
            
        }
    }
}