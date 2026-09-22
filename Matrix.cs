namespace matrixClass;

public class Matrix
{
    private double[,] elements;

    public Matrix(double[,] e)
    {
        elements = e;
    }

    public double this[int i, int j]
    {
        get { return elements[i, j]; }
    }

    public int Rows
    {
        get { return elements.GetLength(0); }
    }

    public int Cols
    {
        get { return elements.GetLength(1); }
    }

    public static Matrix operator +(Matrix first, Matrix second)
    {
        if (first.Rows != second.Rows || first.Cols != second.Cols)
        {
            throw new Exception("Додавання і віднімання відбутися не зможе, бо різна кількість ствовпців і рядків");
        }

        double[,] res = new double[first.Rows, first.Cols];
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < first.Cols; j++)
            {
                res[i, j] = first[i, j] + second[i, j];
            }
        }

        return new Matrix(res);
    }

    public static Matrix operator -(Matrix first, Matrix second)
    {
        double[,] res = new double[first.Rows, first.Cols];
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < first.Cols; j++)
            {
                res[i, j] = first[i, j] - second[i, j];
            }
        }

        return new Matrix(res);
    }

    public static Matrix operator *(Matrix first, Matrix second)
    {
        if (first.Rows != second.Cols)
        {
            throw new Exception("Різна кількість ствовпців і рядків, тому множення неможливе");
        }

        double[,] res = new double[first.Rows, first.Cols];
        for (int i = 0; i < first.Rows; i++)
        {
            for (int j = 0; j < second.Cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < first.Cols; k++)
                {
                    sum += first[i, k] * second[k, j];
                }

                res[i, j] = sum;
            }
        }

        return new Matrix(res);
    }

    public static double determinant(Matrix matrix)
    {
        double determinant = 0;
        if (matrix.Rows != matrix.Cols)
        {
            throw new Exception("Ділення не можливе, бо це не квадратна матриця");
        }

        if (matrix.Rows == 2 && matrix.Cols == 2)
        {
            determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        if (matrix.Rows == 3 && matrix.Cols == 3)
        {
            determinant = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                          matrix[0, 2] * matrix[1, 0] * matrix[2, 1] - matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
                          matrix[0, 0] * matrix[1, 2] * matrix[2, 1] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2];
        }

        if (determinant == 0)
        {
            throw new Exception("Визначник матриці дорівнює 0, матриця вироджена");
        }

        return determinant;
    }

    public static Matrix reverse(Matrix matrix)
    {
        double determinant = Matrix.determinant(matrix);
        double[,] res = new double[matrix.Rows, matrix.Cols];
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                if (matrix.Rows == 2)
                {
                    res[0, 0] = matrix[1, 1] / determinant;
                    res[0, 1] = -matrix[0, 1] / determinant;
                    res[1, 0] = -matrix[1, 0] / determinant;
                    res[1, 1] = matrix[0, 0] / determinant;
                }
                else 
                {
                    res[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / determinant;
                    res[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) / determinant;
                    res[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / determinant;
                    res[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) / determinant;
                    res[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / determinant;
                    res[1, 2] = (matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2]) / determinant;
                    res[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / determinant;
                    res[2, 1] = (matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1]) / determinant;
                    res[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / determinant;
                }
            }
        }
        return new Matrix (res);
    }

    public static Matrix operator /(Matrix first, Matrix second)
    {
        return first * reverse(second);
    }
}