using System;
using System.Globalization;
using System.Linq;

class MatrixCalculator
{
    const string SEPARATOR = " ";

    public static bool HaveSameDimensions(double[,] matrixOne, double[,] matrixTwo)
    {
        return matrixOne.GetLength(0) == matrixTwo.GetLength(0) &&
               matrixOne.GetLength(1) == matrixTwo.GetLength(1);
    }

    public static bool CanMultiply(double[,] matrixOne, double[,] matrixTwo)
    {
        return matrixOne.GetLength(1) == matrixTwo.GetLength(0);
    }

    public static bool IsSquare(double[,] matrix)
    {
        return matrix.GetLength(0) == matrix.GetLength(1);
    }

    public static double[,] Add(double[,] matrixOne, double[,] matrixTwo)
    {
        int rowsCount = matrixOne.GetLength(0);
        int columnsCount = matrixOne.GetLength(1);
        double[,] resultMatrix = new double[rowsCount, columnsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int column = 0; column < columnsCount; column++)
            {
                resultMatrix[row, column] = matrixOne[row, column] + matrixTwo[row, column];
            }
        }

        return resultMatrix;
    }

    public static double[,] Subtract(double[,] matrixOne, double[,] matrixTwo)
    {
        int rowsCount = matrixOne.GetLength(0);
        int columnsCount = matrixOne.GetLength(1);
        double[,] resultMatrix = new double[rowsCount, columnsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int column = 0; column < columnsCount; column++)
            {
                resultMatrix[row, column] = matrixOne[row, column] - matrixTwo[row, column];
            }
        }

        return resultMatrix;
    }

    public static double[,] Multiply(double[,] matrixOne, double[,] matrixTwo)
    {
        int rowsCount = matrixOne.GetLength(0);
        int columnsCount = matrixTwo.GetLength(1);
        int commonDimension = matrixOne.GetLength(1);

        double[,] resultMatrix = new double[rowsCount, columnsCount];

        for (int row = 0; row < rowsCount; row++)
        {
            for (int column = 0; column < columnsCount; column++)
            {
                resultMatrix[row, column] = Enumerable
                    .Range(0, commonDimension)
                    .Sum(index => matrixOne[row, index] * matrixTwo[index, column]);
            }
        }

        return resultMatrix;
    }

    public static double CalculateDeterminant(double[,] matrix)
    {
        double mainDiagonalProduct = matrix[0, 0] * matrix[1, 1];
        double secondaryDiagonalProduct = matrix[0, 1] * matrix[1, 0];

        return mainDiagonalProduct - secondaryDiagonalProduct;
    }

    // B^(-1) = (1 / det) * adj(B)
    public static double[,] InvertMatrix(double[,] matrix)
    {
        if (!IsSquare(matrix))
        {
            return null;
        }

        double determinant = CalculateDeterminant(matrix);

        if (Math.Abs(determinant) < 1e-9)
        {
            return null;
        }

        int rowsCount = matrix.GetLength(0);
        int columnsCount = matrix.GetLength(1);
        double[,] inverseMatrix = new double[rowsCount, columnsCount];

        inverseMatrix[0, 0] = matrix[1, 1] / determinant;
        inverseMatrix[0, 1] = -matrix[0, 1] / determinant;
        inverseMatrix[1, 0] = -matrix[1, 0] / determinant;
        inverseMatrix[1, 1] = matrix[0, 0] / determinant;

        return inverseMatrix;
    }

    // A / B = A * B^(-1)
    public static double[,] Divide(double[,] matrixOne, double[,] matrixTwo)
    {
        double[,] inverseSecondMatrix = InvertMatrix(matrixTwo);
        if (inverseSecondMatrix == null)
        {
            return null;
        }

        return Multiply(matrixOne, inverseSecondMatrix);
    }

    public static string ToString(double[,] matrix)
    {
        int rowsCount = matrix.GetLength(0);
        int columnsCount = matrix.GetLength(1);

        var formattedLines = Enumerable.Range(0, rowsCount).Select(row =>
        {
            var rowValues = Enumerable.Range(0, columnsCount)
                                      .Select(column => Math.Round(matrix[row, column], 4).ToString(CultureInfo.InvariantCulture));

            return string.Join(SEPARATOR, rowValues);
        });

        return string.Join(Environment.NewLine, formattedLines);
    }
}