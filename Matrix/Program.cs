using System;
using System.IO;

namespace MatrixApp
{
    internal class Program
    {
        static void Main()
        {
            string inputPath = "matrices.txt";
            string outputPath = "res.txt";

            try
            {
                var (matA, matB) = MatrixFile.ReadMtrx(inputPath);

                using var sw = new StreamWriter(outputPath, false);

                double[,] sum = MatrixOperation.Add(matA, matB);

                Console.WriteLine("Sum:");
                //sw.WriteLine("Sum");
                MatrixFile.PrintMatrix(sum);
                MatrixFile.WriteMatrix(sw, sum);

                Console.WriteLine();
                sw.WriteLine();


                double[,] diff = MatrixOperation.Subtract(matA, matB);

                Console.WriteLine("Subtract:");
                MatrixFile.PrintMatrix(diff);
                MatrixFile.WriteMatrix(sw, diff);

                Console.WriteLine();
                sw.WriteLine();


                double[,] mult = MatrixOperation.Multiply(matA, matB);

                Console.WriteLine("Multiply:");
                MatrixFile.PrintMatrix(mult);
                MatrixFile.WriteMatrix(sw, mult);

                Console.WriteLine();
                sw.WriteLine();


                double[,] div = MatrixOperation.Divide(matA, matB);

                Console.WriteLine("Divide:");
                MatrixFile.PrintMatrix(div);
                MatrixFile.WriteMatrix(sw, div);

                Console.WriteLine();
                Console.WriteLine("Saved in:");
                Console.WriteLine(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}