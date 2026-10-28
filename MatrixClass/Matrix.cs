public class Matrix
{
    private double[,] data;
    private int rows;
    private int cols;

    public Matrix(int r, int c)
    {
        rows = r;
        cols = c;
        data = new double[r, c];
    }

    public Matrix(double[,] d)
    {
        data = d;
        rows = d.GetLength(0);
        cols = d.GetLength(1);

    }

    public override string ToString()
    {
        string[] lines = new string[rows];
        for (int i = 0; i < rows; i++)
        {
            string[] row = new string[cols];
            for (int j = 0; j < cols; j++)
            {
                row[j] = data[i, j].ToString();
            }
            lines[i] = string.Join(" ", row);
        }
        return string.Join("; ", lines);
    }

    private void checkSameDimension(Matrix other)
    {
        if (rows != other.rows || cols != other.cols)
        {
            throw new Exception("Different dimensions of matrices");
        }
    }
    
    public Matrix add(Matrix other)
    {
        checkSameDimension(other);
        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i, j] = data[i, j] + other.data[i, j];
            }
        }
        return result;
    }

    public Matrix subtract(Matrix other)
    {
        checkSameDimension(other);
        Matrix result = new Matrix(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result.data[i, j] = data[i, j] - other.data[i, j];
            }
        }
        return result;
    }

    public Matrix multiply(Matrix other)
    {
        if (cols != other.rows)
        {
            throw new Exception("Number of columns in A must equal number of rows in B");
        }

        Matrix result = new Matrix(rows, other.cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < other.cols; j++)
            {
                for (int k = 0; k < cols; k++)
                {
                    result.data[i, j] += data[i, k] * other.data[k, j];
                }
            }
        }
        return result;
    }

    public double determinant()
    {
        double mainDiagonal = data[0, 0] * data[1, 1];
        double secondaryDiagonal = data[0, 1] * data[1, 0];
        return mainDiagonal - secondaryDiagonal;
    }

    public Matrix inverse()
    {
        if (rows != cols)
        {
            throw new Exception("Matrix must be square for division");
        }

        double det = determinant();

        if (Math.Abs(det) < 1e-9)
        {
            throw new DivideByZeroException("Determinant is 0, inverse matrix doesn`t exist");
        }

        Matrix res = new Matrix(rows, cols);

        res.data[0, 0] = data[1, 1] / det;
        res.data[0, 1] = -data[0, 1] / det;
        res.data[1, 0] = -data[1, 0] / det;
        res.data[1, 1] = data[0, 0] / det;

        return res;

    }

    public Matrix divide(Matrix other)
    {
        return multiply(other.inverse());
    }

}