using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MatrixApp
{
    

    public static class MatrixOperation
    {
        public static bool AreEqual(double[,] a, double[,] b, double tolerance = 1e-9)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                return false;

            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(a[i, j] - b[i, j]) > tolerance)
                        return false;
                }
            }

            return true;
        }

        public static double[,] Add(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new InvalidOperationException("Matrix dimensions must match for addition.");

            int r = a.GetLength(0), c = a.GetLength(1);
            var res = new double[r, c];

            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i, j] = a[i, j] + b[i, j];

            return res;
        }

        public static double[,] Subtract(double[,] a, double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new InvalidOperationException("Matrix dimensions must match for subtraction.");

            int r = a.GetLength(0), c = a.GetLength(1);
            var res = new double[r, c];

            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i, j] = a[i, j] - b[i, j];

            return res;
        }

        public static double[,] Multiply(double[,] a, double[,] b)
        {
            int rA = a.GetLength(0), cA = a.GetLength(1);
            int rB = b.GetLength(0), cB = b.GetLength(1);

            if (cA != rB)
                throw new InvalidOperationException("Columns of Matrix A must equal rows of Matrix B.");

            var res = new double[rA, cB];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < cA; k++)
                        sum += a[i, k] * b[k, j];
                    res[i, j] = sum;
                }
            }
            return res;
        }

        public static double[,] Invert(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
                throw new InvalidOperationException("Matrix must be square to invert.");

            double[,] augmented = new double[size, 2 * size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    augmented[i, j] = matrix[i, j];
                augmented[i, size + i] = 1.0;
            }

            for (int i = 0; i < size; i++)
            {
                int pivotRow = i;
                for (int k = i + 1; k < size; k++)
                {
                    if (Math.Abs(augmented[k, i]) > Math.Abs(augmented[pivotRow, i]))
                        pivotRow = k;
                }

                if (Math.Abs(augmented[pivotRow, i]) < 1e-9)
                    throw new InvalidOperationException("Matrix is singular (determinant = 0), cannot invert.");

                for (int j = 0; j < 2 * size; j++)
                {
                    double tmp = augmented[i, j];
                    augmented[i, j] = augmented[pivotRow, j];
                    augmented[pivotRow, j] = tmp;
                }

                double div = augmented[i, i];
                for (int j = 0; j < 2 * size; j++)
                    augmented[i, j] /= div;

                for (int k = 0; k < size; k++)
                {
                    if (k != i)
                    {
                        double factor = augmented[k, i];
                        for (int j = 0; j < 2 * size; j++)
                            augmented[k, j] -= factor * augmented[i, j];
                    }
                }
            }

            var inv = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    inv[i, j] = augmented[i, size + j];

            return inv;
        }

        public static double[,] Divide(double[,] a, double[,] b)
        {
            double[,] invB = Invert(b);
            return Multiply(a, invB);
        }
    }
    public static class MatrixFile
    {
        public static (double[,] mtrxA, double[,] mtrxB) ReadMtrx(string path)
        {
            var up = new List<string[]>();
            var down = new List<string[]>();
            string? line;
            bool readingSecond = false;

            using (var sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line))
                    {
                        if (up.Count > 0)
                            readingSecond = true;
                        continue;
                    }

                    var tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!readingSecond)
                        up.Add(tokens);
                    else
                        down.Add(tokens);
                }
            }

            if (up.Count == 0 || down.Count == 0)
                throw new FormatException("Invalid file format. File must contain two matrices separated by a blank line.");

            int rowsA = up.Count, colsA = up[0].Length;
            var matA = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
                for (int j = 0; j < colsA; j++)
                    matA[i, j] = double.Parse(up[i][j], CultureInfo.InvariantCulture);

            int rowsB = down.Count, colsB = down[0].Length;
            var matB = new double[rowsB, colsB];
            for (int i = 0; i < rowsB; i++)
                for (int j = 0; j < colsB; j++)
                    matB[i, j] = double.Parse(down[i][j], CultureInfo.InvariantCulture);

            return (matA, matB);
        }

        public static void WriteMatrix(StreamWriter sw, double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sw.Write($"{matrix[i, j]:F2}\t");
                }
                sw.WriteLine();
            }
        }

        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]:F2}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}