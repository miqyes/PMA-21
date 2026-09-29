namespace Matrix;

public static class MatrixCalculate
{
    public static double[,] AddMatrix(double[,] matrixA, double[,] matrixB, int rows, int cols)
    {
        if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
        {
            throw new ArgumentException("Error: matrices must be the same size!");
        }

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return result;
    }

    public static double[,] SubMatrix(double[,] matrixA, double[,] matrixB, int rows, int cols)
    {
        if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
        {
            throw new ArgumentException("Error: matrices must be the same size!");
        }

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }

        return result;
    }

    public static double[,] MultMatrix(double[,] matrixA, double[,] matrixB, int rows, int cols)
    {
        if (rows != cols)
        {
            throw new ArgumentException("Error: you must have square matrix");
        }

        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < cols; k++)
                {
                    sum += matrixA[i, k] * matrixB[k, j];
                }

                result[i, j] = sum;
            }
        }

        return result;
    }

    public static double Determinant(double[,] matrix, int size)
    {
        double det = 0;

        if (size == 2)
        {
            det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else if (size == 3)
        {
            det = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                  matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                  matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
                  matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
                  matrix[0, 0] * matrix[1, 2] * matrix[2, 1] -
                  matrix[0, 1] * matrix[1, 0] * matrix[2, 2];
        }

        if (det == 0)
        {
            throw new Exception("Determinant is zero.");
        }

        return det;
    }

    public static double[,] ReverseMatrix(double[,] matrix, int size)
    {
        double det = Determinant(matrix, size);
        double[,] result = new double[size, size];

        if (size == 2)
        {
            result[0, 0] = matrix[1, 1] / det;
            result[0, 1] = -matrix[0, 1] / det;
            result[1, 0] = -matrix[1, 0] / det;
            result[1, 1] = matrix[0, 0] / det;
        }
        else if (size == 3)
        {
            result[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / det;
            result[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) / det;
            result[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / det;

            result[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) / det;
            result[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / det;
            result[1, 2] = (matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2]) / det;

            result[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / det;
            result[2, 1] = (matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1]) / det;
            result[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / det;
        }

        return result;
    }

    public static double[,] DivMatrix(double[,] matrixA, double[,] matrixB, int rows, int cols)
    {
        if (rows != cols)
        {
            throw new ArgumentException("Error: you must have square matrix");
        }

        double[,] reverse = ReverseMatrix(matrixB, rows);
        return MultMatrix(matrixA, reverse, rows, cols);
    }
}