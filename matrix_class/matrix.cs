using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

public class Matrix
{
    public int Rows { get; }
    public int Cols { get; }
    private readonly double[,] _data;

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
            throw new ArgumentException("Розміри матриці повинні бути більшими за 0.");

        Rows = rows;
        Cols = cols;
        _data = new double[rows, cols];
    }

    public double this[int r, int c]
    {
        get => _data[r, c];
        set => _data[r, c] = value;
    }

    public bool IsSquare => Rows == Cols;
}

public interface IMatrixCalculator
{
    Matrix Add(Matrix a, Matrix b);
    Matrix Subtract(Matrix a, Matrix b);
    Matrix Multiply(Matrix a, Matrix b);
    Matrix Divide(Matrix a, Matrix b);
    Matrix Invert(Matrix a);
}

public class MatrixCalculator : IMatrixCalculator
{
    private const double Epsilon = 1e-9;

    public Matrix Add(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new InvalidOperationException("" +
                "Розміри матриць мають бути однаковими для додавання.");

        var res = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                res[i, j] = a[i, j] + b[i, j];

        return res;
    }

    public Matrix Subtract(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new InvalidOperationException("Розміри матриць мають бути однаковими для додавання.");

        var res = new Matrix(a.Rows, b.Cols);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                res[i, j] = a[i, j] - b[i, j];

        return res;
    }

    public Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
            throw new InvalidOperationException("Кількість стовпчиків першої матриці має дорівнювати кількості рядків другої.");

        var res = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
            for(int t = 0; t < a.Cols; t++)
                for (int j = 0; j < b.Cols; j++)
                    res[i, j] += a[i, t] * b[t, j];

        return res;
    }

    public Matrix Invert(Matrix a)
    {
        if (!a.IsSquare)
            throw new InvalidOperationException("Обернену матрицю можна знайти лише для квадратної матриці.");

        int n = a.Rows;
        double[,] aug = new double[n, 2 * n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                aug[i, j] = a[i, j];
            aug[i, n + i] = 1.0;
        }

        for (int i = 0; i < n; i++)
        {
            int pivot = i;
            for (int k = i + 1; k < n; k++)
                if (Math.Abs(aug[k, i]) > Math.Abs(aug[pivot, i]))
                    pivot = k;

            if (Math.Abs(aug[pivot, i]) < Epsilon)
                throw new InvalidOperationException("Матриця є виродженою (визначник = 0), ділення неможливе.");

            for (int j = 0; j < 2 * n; j++)
            {
                double tmp = aug[i, j];
                aug[i, j] = aug[pivot, j];
                aug[pivot, j] = tmp;
            }

            double div = aug[i, i];
            for (int j = 0; j < 2 * n; j++)
                aug[i, j] /= div;

            for (int k = 0; k < n; k++)
            {
                if (k != i)
                {
                    double factor = aug[k, i];
                    for (int j = 0; j < 2 * n; j++)
                        aug[k, j] -= factor * aug[i, j];
                }
            }
        }

        var inv = new Matrix(n, n);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                inv[i, j] = aug[i, n + j];

        return inv;
    }

    public Matrix Divide(Matrix a, Matrix b)
    {
        Matrix bInv = Invert(b);
        return Multiply(a, bInv);
    }
}

public class MatrixFileService
{
    public List<Matrix> ReadMatricesFromFile(string filePath)
    {
        var matrices = new List<Matrix>();
        
        string[] lines = File.ReadAllLines(filePath);
        var currentRows = new List<double[]>();

        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                if (currentRows.Count > 0)
                {
                    matrices.Add(CreateMatrixFromList(currentRows));
                    currentRows.Clear();
                }
                continue;
            }

            string[] tokens = trimmed.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double[] rowValues = new double[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                rowValues[i] = double.Parse(tokens[i], CultureInfo.InvariantCulture);
            }

            currentRows.Add(rowValues);
        }
        
        if (currentRows.Count > 0)
        {
            matrices.Add(CreateMatrixFromList(currentRows));
        }

        return matrices;
    }

    private Matrix CreateMatrixFromList(List<double[]> rowList)
    {
        int rows = rowList.Count;
        int cols = rowList[0].Length;

        var matrix = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            if (rowList[i].Length != cols)
            {
                throw new InvalidOperationException("Всі рядки однієї матриці повинні мати однакову кількість елементів.");
            }

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rowList[i][j];
            }
        }

        return matrix;
    }

    public void AppendOperationLog(StreamWriter writer, string title, Matrix matrix)
    {
        writer.WriteLine(title);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            { 
                writer.Write($"{Math.Round(matrix[i, j], 2),8:F2} "); 
            }
            writer.WriteLine();
        }
        writer.WriteLine();
    }
}