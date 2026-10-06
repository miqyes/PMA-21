namespace MatrixClass;

public class Matrix
{
    private double[,] matrix;
    private int rows, cols;
    
    public Matrix(double[,] matrixA)
    {
        this.matrix = matrixA;
        this.rows = matrixA.GetLength(0);
        this.cols = matrixA.GetLength(1);
    }

    public double[,] matr
    {
        get
        {
            return matrix;
        }
    }

    public int Rows
    {
        get
        {
            return matrix.GetLength(0);
        }
    }

    public int Cols
    {
        get
        {
            return matrix.GetLength(1);
        }
    }
    
    public static double[,] ReadMatrix(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        int rows = lines.Length;
        int cols = lines[0].Split(' ').Length;
        
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            string[] nums = lines[i].Split(' ');
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(nums[j]);
            }
        }
        return matrix;
    }

    public static void WriteMatrix(StreamWriter sw, double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sw.Write(matrix[i, j] + " ");
            }
            sw.WriteLine();
        }
    }

    public void CheckLength(Matrix other)
    {
        if (rows != other.rows || cols != other.cols) 
        {
            throw new ArgumentException("Error: matrices must be the same size!");
        }
    }

    public Matrix AddMatrix(Matrix other)
    {
        CheckLength(other);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] + other.matrix[i, j];
            }
        }
        return new Matrix(result);
    }

    public Matrix SubMatrix(Matrix other)
    {
        CheckLength(other);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] - other.matrix[i, j];
            }
        }
        return new Matrix(result);
    }

    public Matrix MultMatrix(Matrix other)
    {
        if (rows != other.cols || other.rows != other.cols || rows != other.rows) 
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
                    sum += matrix[i, k] * other.matrix[k, j];
                }
                result[i, j] = sum;
            }
        }
        return new Matrix(result);
    }

    public static double Determinant(double[,] matrix, int size)
    {
        if (size == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        throw new Exception("Determinant is zero.");
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
        return result;
    }

    public Matrix DivMatrix(Matrix other)
    {
        if ( rows != cols || other.rows != other.cols || rows != other.rows) 
        {
            throw new ArgumentException("Error: you must have square matrices");
        }

        double[,] reverse = ReverseMatrix(other.matrix, other.rows);
        double[,] result = new double[other.rows, other.cols];
        for (int i = 0; i < other.rows; i++)
        {
            for (int j = 0; j < other.cols; j++)
            {
                double sum = 0;

                for (int k = 0; k < other.cols; k++)
                {
                    sum += matrix[i, k] * reverse[k, j];
                }
                result[i, j] = sum;
            }
        }
        return new Matrix(result);
    }
}
