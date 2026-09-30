using System;
using System.IO;

namespace Матриця_класС_
{
    public class FileWorker
    {
        public static Matrix InputMatrix(string Name, int Size)
        {
            Console.WriteLine($"\nEnter matrix{Name}:");
            Matrix NewMatrix = new Matrix(Size);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{Name}[{i + 1},{j + 1}] = ");
                    NewMatrix.Data[i, j] = double.Parse(Console.ReadLine());
                }
            }
            return NewMatrix;
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
