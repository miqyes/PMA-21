using System;

namespace matrixLab
{
    public static class Matrix
    {
        public static List<double[,]> parseMatricesFromFile(string content)
        {
            List<double[,]> result = new List<double[,]>();
            string[] rawMatrices = content.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string rawMatrix in rawMatrices)
            {
                string[] lines = rawMatrix.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                List<double[]> rowList = new List<double[]>();

                foreach (string line in lines)
                {
                    string[] elements = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (elements.Length == 0) continue;

                    double[] row = new double[elements.Length];
                    for (int i = 0; i < elements.Length; i++)
                    {
                        if (!double.TryParse(elements[i], out row[i]))
                        {
                            throw new FormatException($"Invalid number format: '{elements[i]}'");
                        }
                    }
                    rowList.Add(row);
                }

                if (rowList.Count > 0)
                {
                    int rows = rowList.Count;
                    int cols = rowList[0].Length;
                    double[,] matrix = new double[rows, cols];

                    for (int r = 0; r < rows; r++)
                    {
                        if (rowList[r].Length != cols)
                        {
                            throw new ArgumentException("Matrix rows must have the same number of columns.");
                        }
                        for (int c = 0; c < cols; c++)
                        {
                            matrix[r, c] = rowList[r][c];
                        }
                    }
                    result.Add(matrix);
                }
            }

            return result;
        }
        public static double[,] addMatrices(double[,] a, double[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                throw new ArgumentException("Matrices must have identical dimensions for addition.");
            }

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
        public static double[,] subtractMatrices(double[,] a, double[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if (rowsA != rowsB || colsA != colsB)
            {
                throw new ArgumentException("Matrices must have identical dimensions for subtraction.");
            }

            double[,] result = new double[rowsA, colsA];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }
        public static double[,] multiplyMatrices(double[,] a, double[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if (colsA != rowsB)
            {
                throw new ArgumentException("Columns of matrix A must equal rows of matrix B.");
            }

            double[,] result = new double[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        public static double[,] divideMatrices(double[,] a, double[,] b)
        {
            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if (rowsB != colsB)
            {
                throw new ArgumentException("Divisor matrix must be square.");
            }

            double[,] inverseB = getInverseMatrix(b);
            return multiplyMatrices(a, inverseB);
        }
        public static double[,] getInverseMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double det = calculateDeterminant(matrix);

            if (Math.Abs(det) < 1e-9)
            {
                throw new InvalidOperationException("Matrix determinant is zero (inverse does not exist).");
            }

            if (n == 1)
            {
                double[,] res = new double[1, 1];
                res[0, 0] = 1.0 / matrix[0, 0];
                return res;
            }

            double[,] adjugate = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double[,] sub = getSubmatrix(matrix, i, j);
                    double cofactor = Math.Pow(-1, i + j) * calculateDeterminant(sub);
                    adjugate[j, i] = cofactor;
                }
            }

            double[,] inverse = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = adjugate[i, j] / det;
                }
            }

            return inverse;
        }
        public static double calculateDeterminant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) return matrix[0, 0];
            if (n == 2) return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double det = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] sub = getSubmatrix(matrix, 0, col);
                det += Math.Pow(-1, col) * matrix[0, col] * calculateDeterminant(sub);
            }
            return det;
        }
        public static double[,] getSubmatrix(double[,] matrix, int excludeRow, int excludeCol)
        {
            int n = matrix.GetLength(0);
            double[,] sub = new double[n - 1, n - 1];
            int subRow = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == excludeRow) continue;
                int subCol = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludeCol) continue;
                    sub[subRow, subCol] = matrix[i, j];
                    subCol++;
                }
                subRow++;
            }
            return sub;
        }
        public static void writeMatrixToStream(StreamWriter writer, double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write($"{matrix[i, j]:F2}\t");
                }
                writer.WriteLine();
            }
        }
    }
}
