using System;
namespace matrix
{
    class Matrix
    {
        public static double[,] addMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            checkSameSize(firstMatrix, secondMatrix);

            int rows = firstMatrix.GetLength(0);
            int columns = firstMatrix.GetLength(1);
            double[,] resultMatrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return resultMatrix;
        }

        public static double[,] subtractMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            checkSameSize(firstMatrix, secondMatrix);

            int rows = firstMatrix.GetLength(0);
            int columns = firstMatrix.GetLength(1);
            double[,] resultMatrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return resultMatrix;
        }

        public static double[,] multiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException("Columns count of the first matrix must be equal to rows count of the second matrix");
            }

            int rows = firstMatrix.GetLength(0);
            int columns = secondMatrix.GetLength(1);
            int commonSize = firstMatrix.GetLength(1);
            double[,] resultMatrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    for (int commonIndex = 0; commonIndex < commonSize; commonIndex++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, commonIndex] * secondMatrix[commonIndex, j];
                    }
                }
            }

            return resultMatrix;
        }

        public static double[,] divisionMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            double[,] inverse = inverseMatrix(secondMatrix);

            return multiplyMatrix(firstMatrix, inverse);
        }

        public static double determinant(double[,] matrix)
        {
            checkSquare(matrix);

            int size = matrix.GetLength(0);

            if (size == 1)
            {
                return matrix[0, 0];
            }

            if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            if (size == 3)
            {
                double result =
                      matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                    - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                    + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

                return result;
            }
            throw new ArgumentException("Supported matrix sizes are 1x1, 2x2 and 3x3");
        }

        public static double[,] inverseMatrix(double[,] matrix)
        {
            checkSquare(matrix);

            double determinantValue = determinant(matrix);

            if (Math.Abs(determinantValue) ==0)
            {
                throw new DivideByZeroException("Division by zero is impossible: determinant of the second matrix is 0");
            }

            int size = matrix.GetLength(0);
            double[,] inverse = new double[size, size];

            if (size == 1)
            {
                inverse[0, 0] = 1 / determinantValue;
            }
            else if (size == 2)
            {
                inverse[0, 0] = matrix[1, 1] / determinantValue;
                inverse[0, 1] = -matrix[0, 1] / determinantValue;
                inverse[1, 0] = -matrix[1, 0] / determinantValue;
                inverse[1, 1] = matrix[0, 0] / determinantValue;
            }
            else if (size == 3)
            {
                inverse[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / determinantValue;
                inverse[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) / determinantValue;
                inverse[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / determinantValue;

                inverse[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) / determinantValue;
                inverse[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / determinantValue;
                inverse[1, 2] = (matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2]) / determinantValue;

                inverse[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / determinantValue;
                inverse[2, 1] = (matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1]) / determinantValue;
                inverse[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / determinantValue;
            }

            return inverse;
        }

        private static void checkSquare(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("Matrix must be square");
            }
        }

        private static void checkSameSize(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) || firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                throw new ArgumentException("Different size of matrices");
            }
        }
    }
}
