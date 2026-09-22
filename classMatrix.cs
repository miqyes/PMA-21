using System;

namespace classMatrix
{

    public class Matrix
    {
        private double[,] data;
        private int rows;
        private int cols;

        public int Rows => rows;
        public int Cols => cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new double[rows, cols];
        }

        public Matrix(double[,] data)
        {
            this.data = data;
            this.rows = data.GetLength(0);
            this.cols = data.GetLength(1);
        }

        public double this[int row, int col]
        {
            get => data[row, col];
            set => data[row, col] = value;
        }

        public static List<Matrix> parseMatricesFromFileContent(string content)
        {
            List<Matrix> result = new List<Matrix>();
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
                    int rCount = rowList.Count;
                    int cCount = rowList[0].Length;
                    double[,] matrixData = new double[rCount, cCount];

                    for (int r = 0; r < rCount; r++)
                    {
                        if (rowList[r].Length != cCount)
                        {
                            throw new ArgumentException("Matrix rows must have the same number of columns.");
                        }
                        for (int c = 0; c < cCount; c++)
                        {
                            matrixData[r, c] = rowList[r][c];
                        }
                    }
                    result.Add(new Matrix(matrixData));
                }
            }

            return result;
        }

        public Matrix add(Matrix other)
        {
            if (this.rows != other.rows || this.cols != other.cols)
            {
                throw new ArgumentException("Matrices must have identical dimensions for addition.");
            }

            Matrix result = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = this[i, j] + other[i, j];
                }
            }
            return result;
        }

        public Matrix subtract(Matrix other)
        {
            if (this.rows != other.rows || this.cols != other.cols)
            {
                throw new ArgumentException("Matrices must have identical dimensions for subtraction.");
            }

            Matrix result = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = this[i, j] - other[i, j];
                }
            }
            return result;
        }

        public Matrix multiply(Matrix other)
        {
            if (this.cols != other.rows)
            {
                throw new ArgumentException("Columns of matrix A must equal rows of matrix B.");
            }

            Matrix result = new Matrix(this.rows, other.cols);
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < other.cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < this.cols; k++)
                    {
                        sum += this[i, k] * other[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public Matrix divide(Matrix other)
        {
            if (other.rows != other.cols)
            {
                throw new ArgumentException("Divisor matrix must be square.");
            }

            Matrix inverseB = other.getInverse();
            return this.multiply(inverseB);
        }

        public Matrix getInverse()
        {
            int n = this.rows;
            double det = this.calculateDeterminant();

            if (Math.Abs(det) < 1e-9)
            {
                throw new InvalidOperationException("Matrix determinant is zero (inverse does not exist).");
            }

            if (n == 1)
            {
                Matrix res = new Matrix(1, 1);
                res[0, 0] = 1.0 / this[0, 0];
                return res;
            }

            Matrix adjugate = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix sub = this.getSubmatrix(i, j);
                    double cofactor = Math.Pow(-1, i + j) * sub.calculateDeterminant();
                    adjugate[j, i] = cofactor;
                }
            }

            Matrix inverse = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = adjugate[i, j] / det;
                }
            }

            return inverse;
        }

        public double calculateDeterminant()
        {
            int n = this.rows;
            if (n == 1) return this[0, 0];
            if (n == 2) return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];

            double det = 0;
            for (int col = 0; col < n; col++)
            {
                Matrix sub = this.getSubmatrix(0, col);
                det += Math.Pow(-1, col) * this[0, col] * sub.calculateDeterminant();
            }
            return det;
        }

        public Matrix getSubmatrix(int excludeRow, int excludeCol)
        {
            int n = this.rows;
            Matrix sub = new Matrix(n - 1, n - 1);
            int subRow = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == excludeRow) continue;
                int subCol = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludeCol) continue;
                    sub[subRow, subCol] = this[i, j];
                    subCol++;
                }
                subRow++;
            }
            return sub;
        }

        public void writeToStream(StreamWriter writer)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write($"{this[i, j]:F2}\t");
                }
                writer.WriteLine();
            }
        }
    }
}
