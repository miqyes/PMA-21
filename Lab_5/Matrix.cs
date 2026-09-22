using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class Matrix
{
    private double [,] matrix;
    public Matrix(double[,] matrix)
    {
        this.matrix = matrix;
    }
    public int Rows => matrix.GetLength(0);
    public int Cols => matrix.GetLength(1);
    public double this[int row, int col]
    {
        get => matrix[row, col];
        set => matrix[row, col] = value;
    }

    public static Matrix ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split().Length;
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] row = lines[i].Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(row[j]);
            }
        }

        return new Matrix(matrix);
    }

    public Matrix Add(Matrix other)
    {
        Matrix result = new Matrix(new double[Rows, Cols]);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result[i, j] = this[i, j] + other[i, j];
            }
        }

        return result;
    }

    public Matrix Sub(Matrix other)
    {
        Matrix result = new Matrix(new double[Rows, Cols]);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                result[i, j] = this[i, j] - other[i, j];
            }
        }

        return result;
    }

    public Matrix Mult(Matrix other)
    {
        if (this.Cols != other.Rows)
        {
            throw new Exception("Дві матриці можна перемножити між собою тоді і тільки тоді," +
                                " коли кількість стовпців першої матриці дорівнює кількості рядків другої матриці.");
        }

        Matrix result = new Matrix(new double[this.Rows, other.Cols]);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < other.Cols; j++)
            {
                for (int k = 0; k < Cols; k++)
                {
                    result[i, j] += this[i, k] * other[k, j];
                }
            }
        }

        return result;
    }

    public Matrix Div(Matrix other)
    {
        Matrix inverse = other.Invert();
        return Mult(inverse);
    }

    public Matrix Invert()
    {
        if (Rows != Cols)
        {
            throw new Exception("матриця повинна бути квадратна");
        }

        double[,] expanded = new double[Rows, Rows * 2];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                expanded[i, j] = matrix[i, j];
            }

            expanded[i, i + Rows] = 1;
        }

        for (int i = 0; i < Rows; i++)
        {
            int pivot = i;
            for (int j = i + 1; j < Rows; j++)
            {
                if (Math.Abs(expanded[j, i]) > Math.Abs(expanded[pivot, i]))
                {
                    pivot = j;
                }
            }

            if (pivot != i)
            {
                for (int k = 0; k < Rows * 2; k++)
                {
                    (expanded[i, k], expanded[pivot, k]) = (expanded[pivot, k], expanded[i, k]);
                }
            }

            if (Math.Abs(expanded[i, i]) < 1e-10)
            {
                throw new Exception("матриця вироджена");
            }

            double factor = expanded[i, i];
            for (int k = 0; k < Rows * 2; k++)
            {
                expanded[i, k] /= factor;
            }

            for (int j = 0; j < Rows; j++)
            {
                if (i != j)
                {
                    double f = expanded[j, i];
                    for (int k = 0; k < Rows * 2; k++)
                    {
                        expanded[j, k] -= f * expanded[i, k];
                    }
                }
            }
        }

        double[,] result = new double[Rows, Rows];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                result[i, j] = expanded[i, j + Rows];
            }
        }

        return new Matrix(result);
    }

    public void WriteMatrix( StreamWriter file)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                file.Write(matrix[i, j] + " ");
            }

            file.WriteLine();
        }
    }

    

}