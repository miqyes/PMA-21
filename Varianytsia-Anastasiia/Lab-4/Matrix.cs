using System;
using System.Text;

class Matrix
{
    const string SEPARATOR = " ";

    private readonly double[,] elements;

    public int RowsCount { get; }
    public int ColumnsCount { get; }

    public Matrix(int rowsCount, int columnsCount)
    {
        RowsCount = rowsCount;
        ColumnsCount = columnsCount;
        elements = new double[rowsCount, columnsCount];
    }

    public Matrix(double[,] initialData)
    {
        RowsCount = initialData.GetLength(0);
        ColumnsCount = initialData.GetLength(1);
        elements = (double[,])initialData.Clone();
    }

    public double this[int row, int column]
    {
        get => elements[row, column];
        set => elements[row, column] = value;
    }

    public static bool HaveSameDimensions(Matrix firstMatrix, Matrix secondMatrix)
    {
        return firstMatrix.RowsCount == secondMatrix.RowsCount &&
               firstMatrix.ColumnsCount == secondMatrix.ColumnsCount;
    }

    public static bool CanMultiply(Matrix firstMatrix, Matrix secondMatrix)
    {
        return firstMatrix.ColumnsCount == secondMatrix.RowsCount;
    }

    public bool IsSquare()
    {
        return RowsCount == ColumnsCount;
    }

    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix resultMatrix = new(firstMatrix.RowsCount, firstMatrix.ColumnsCount);

        for (int row = 0; row < firstMatrix.RowsCount; row++)
        {
            for (int column = 0; column < firstMatrix.ColumnsCount; column++)
            {
                resultMatrix[row, column] = firstMatrix[row, column] + secondMatrix[row, column];
            }
        }

        return resultMatrix;
    }

    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix resultMatrix = new(firstMatrix.RowsCount, firstMatrix.ColumnsCount);

        for (int row = 0; row < firstMatrix.RowsCount; row++)
        {
            for (int column = 0; column < firstMatrix.ColumnsCount; column++)
            {
                resultMatrix[row, column] = firstMatrix[row, column] - secondMatrix[row, column];
            }
        }

        return resultMatrix;
    }

    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix resultMatrix = new(firstMatrix.RowsCount, secondMatrix.ColumnsCount);
        int commonDimension = firstMatrix.ColumnsCount;

        for (int row = 0; row < firstMatrix.RowsCount; row++)
        {
            for (int column = 0; column < secondMatrix.ColumnsCount; column++)
            {
                double sum = 0;
                for (int index = 0; index < commonDimension; index++)
                {
                    sum += firstMatrix[row, index] * secondMatrix[index, column];
                }
                resultMatrix[row, column] = sum;
            }
        }

        return resultMatrix;
    }

    public double CalculateDeterminant()
    {
        return elements[0, 0] * elements[1, 1] - elements[0, 1] * elements[1, 0];
    }

    // B^(-1) = (1 / det) * adj(B)
    public Matrix Invert()
    {
        if (!IsSquare() || RowsCount != 2)
        {
            return null;
        }

        double determinant = CalculateDeterminant();

        if (Math.Abs(determinant) < 1e-9)
        {
            return null;
        }

        Matrix inverseMatrix = new(2, 2);

        inverseMatrix[0, 0] = elements[1, 1] / determinant;
        inverseMatrix[0, 1] = -elements[0, 1] / determinant;
        inverseMatrix[1, 0] = -elements[1, 0] / determinant;
        inverseMatrix[1, 1] = elements[0, 0] / determinant;

        return inverseMatrix;
    }

    // A / B = A * B^(-1)
    public static Matrix operator /(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix inverseSecondMatrix = secondMatrix.Invert();
        if (inverseSecondMatrix == null)
        {
            return null;
        }

        return firstMatrix * inverseSecondMatrix;
    }

    public override string ToString()
    {
        StringBuilder builder = new();

        for (int row = 0; row < RowsCount; row++)
        {
            string[] rowParts = new string[ColumnsCount];
            for (int column = 0; column < ColumnsCount; column++)
            {
                rowParts[column] = Math.Round(elements[row, column], 4).ToString();
            }
            builder.AppendLine(string.Join(SEPARATOR, rowParts));
        }

        return builder.ToString().TrimEnd();
    }
}