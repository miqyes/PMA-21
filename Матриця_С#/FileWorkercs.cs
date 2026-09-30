using System;
using System.IO;

namespace Матриця_С_
{
   public class FileWorker
    {
        public static Matrix InputMatrix(string name, int size)
        {
            Console.WriteLine($"\nEnter matrix{name}:");
            Matrix matrix = new Matrix(size);

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write($"{name}[{i + 1},{j + 1}] = ");
                    matrix.Data[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }
        public static Matrix ReadMatrix(string FilePath, int MatrixSize)
        {
            string[] FileLines = File.ReadAllLines(FilePath);
            Matrix LoadedMatrix = new Matrix(MatrixSize);

            for (int RowIndex = 0; RowIndex < MatrixSize; RowIndex++)
            {
                string[] LineElements = FileLines[RowIndex].Trim().Split('\t');
                for (int ColumnIndex = 0; ColumnIndex < MatrixSize; ColumnIndex++)
                {
                    LoadedMatrix.Data[RowIndex, ColumnIndex] = double.Parse(LineElements[ColumnIndex]);
                }
            }
            return LoadedMatrix;
        }
        public static void WriteResult(string FilePath, string Content)
        {
            File.WriteAllText(FilePath, Content);
        }
    }
}
