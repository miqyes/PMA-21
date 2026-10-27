using System;
using System.IO;

namespace matrix
{
    class Program
    {
        const string firstMatrixFile = "firstMatrixInput.txt";
        const string secondMatrixFile = "secondMatrixInput.txt";
        const string resultFile = "result.txt";

        static void Main()
        {
            try
            {
                double[,] firstMatrix = Format.ReadMatrix(firstMatrixFile);
                double[,] secondMatrix = Format.ReadMatrix(secondMatrixFile);

                using (StreamWriter writer = new StreamWriter(resultFile))
                {
                    WriteOperationBlock(writer, firstMatrix, "+", secondMatrix, Matrix.addMatrix(firstMatrix, secondMatrix));
                    WriteOperationBlock(writer, firstMatrix, "-", secondMatrix, Matrix.subtractMatrix(firstMatrix, secondMatrix));
                    WriteOperationBlock(writer, firstMatrix, "*", secondMatrix, Matrix.multiplyMatrix(firstMatrix, secondMatrix));
                    WriteOperationBlock(writer, firstMatrix, "/", secondMatrix, Matrix.divisionMatrix(firstMatrix, secondMatrix));
                }

                Console.WriteLine("Result is saved in " + resultFile);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
        }

        static void WriteOperationBlock(StreamWriter writer, double[,] matrix1, string sign, double[,] matrix2, double[,] result)
        {
            WriteMatrix(writer, matrix1);
            writer.WriteLine(sign);
            WriteMatrix(writer, matrix2);
            writer.WriteLine("=");
            WriteMatrix(writer, result);
            writer.WriteLine(); 
        }

        static void WriteMatrix(StreamWriter writer, double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    writer.Write(matrix[i, j] + "\t");
                }
                writer.WriteLine();
            }
        }
    }
}
