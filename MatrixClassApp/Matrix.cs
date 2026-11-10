using System;
using System.Collections.Generic;
using System.IO;

namespace MatrixApp
{
    public class Matrix
    {
        private readonly double[,] _data;

        public int Rows { get; }
        public int Columns { get; }

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new ArgumentException("Size of the matrix must be positive.");

            Rows = rows;
            Columns = columns;
            _data = new double[rows, columns];
        }

        public Matrix(double[,] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            Rows = data.GetLength(0);
            Columns = data.GetLength(1);
            _data = (double[,])data.Clone();
        }

        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new InvalidOperationException("Matrix dimensions must match for addition.");

            var res = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    res[i, j] = a[i, j] + b[i, j];

            return res;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new InvalidOperationException("Matrix dimensions must match for subtraction.");

            var res = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    res[i, j] = a[i, j] - b[i, j];

            return res;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new InvalidOperationException("Number of columns in matrix A must equal the number of rows in matrix B.");

            var res = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < a.Columns; k++)
                        sum += a[i, k] * b[k, j];

                    res[i, j] = sum;
                }
            }

            return res;
        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            Matrix invB = b.Invert();
            return a * invB;
        }

        public Matrix Invert()
        {
            if (Rows != Columns)
                throw new InvalidOperationException("The inverse of a matrix can only be found for a square matrix.");

            int n = Rows;
            double[,] augmented = new double[n, 2 * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    augmented[i, j] = _data[i, j];
                augmented[i, n + i] = 1.0;
            }

            for (int i = 0; i < n; i++)
            {
                int pivotRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(augmented[k, i]) > Math.Abs(augmented[pivotRow, i]))
                        pivotRow = k;
                }

                if (Math.Abs(augmented[pivotRow, i]) < 1e-9)
                    throw new InvalidOperationException("The matrix is singular (determinant = 0), division is not possible.");

                for (int j = 0; j < 2 * n; j++)
                {
                    double tmp = augmented[i, j];
                    augmented[i, j] = augmented[pivotRow, j];
                    augmented[pivotRow, j] = tmp;
                }

                double div = augmented[i, i];
                for (int j = 0; j < 2 * n; j++)
                    augmented[i, j] /= div;

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = augmented[k, i];
                        for (int j = 0; j < 2 * n; j++)
                            augmented[k, j] -= factor * augmented[i, j];
                    }
                }
            }

            var inv = new Matrix(n, n);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inv[i, j] = augmented[i, n + j];

            return inv;
        }
    }

    public static class MatrixFile
    {
        public static (Matrix matA, Matrix matB) ReadMatrices(string path)
        {
            var rowsA = new List<double[]>();
            var rowsB = new List<double[]>();
            bool readingSecond = false;

            using (var sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line))
                    {
                        if (rowsA.Count > 0)
                            readingSecond = true;
                        continue;
                    }

                    var tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var row = new double[tokens.Length];
                    for (int i = 0; i < tokens.Length; i++)
                        row[i] = double.Parse(tokens[i]);

                    if (!readingSecond)
                        rowsA.Add(row);
                    else
                        rowsB.Add(row);
                }
            }

            if (rowsA.Count == 0 || rowsB.Count == 0)
                throw new FormatException("The file must contain two matrices separated by an empty line.");

            return (CreateFromArray(rowsA), CreateFromArray(rowsB));
        }

        private static Matrix CreateFromArray(List<double[]> list)
        {
            int r = list.Count;
            int c = list[0].Length;
            var matrix = new Matrix(r, c);

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    matrix[i, j] = list[i][j];
            }
            return matrix;
        }

        public static void PrintMatrix(string title, Matrix matrix)
        {
            Console.WriteLine(title);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix[i, j]:F2}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void WriteMatrix(StreamWriter sw, string title, Matrix matrix)
        {
            sw.WriteLine(title);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sw.Write($"{matrix[i, j]:F2}\t");
                }
                sw.WriteLine();
            }
            sw.WriteLine();
        }
    }
}