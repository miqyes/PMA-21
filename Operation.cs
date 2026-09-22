namespace matrix;

class Operation
{
    public static double[,] add(double[,] firstMatrix, double[,] secondMatrix)
    {
        if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) || firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
        {
            throw new ArgumentException("Різний розмір матриць, додавання і віднімання не можливе.");
        }
        double [,] result = new double[firstMatrix.GetLength(0),firstMatrix.GetLength(1)];
        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                result[i, j] = firstMatrix[i,j]+secondMatrix[i,j];
            }
        }

        return result;
    }
    public static double[,] difference(double[,] firstMatrix, double[,] secondMatrix)
    {
        double[,] result = new double [firstMatrix.GetLength(0), firstMatrix.GetLength(1)];
        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                result[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
            }
        }

        return result;
    }

    public static double[,] multiply(double[,] firstMatrix, double[,] secondMatrix)
    {
        if (firstMatrix.GetLength(0) != secondMatrix.GetLength(1))
        {
            throw new ArgumentException("Множення не можливе, бо різна довжина рядків і стовпців");
        }
        double[,] result = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < secondMatrix.GetLength(1); j++)
            {
                double sum = 0;
                for (int k = 0; k < firstMatrix.GetLength(1); k++)
                {
                    sum += firstMatrix[i, k] * secondMatrix[k,j];
                }

                result[i, j] = sum;
            }
        }
        return result;
    }
    public static double determinant(double[,] matrix)
    {
        double determinant=0;
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new Exception("Ділення не можливе. Матриця повинна бути квадратна");
        }

        if (matrix.GetLength(0)==2&&matrix.GetLength(1)==2)
        {
            determinant=matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        if (matrix.GetLength(0) == 3 && matrix.GetLength(1) == 3)
        {
            determinant=matrix[0,0]*matrix[1,1]*matrix[2,2] + matrix[0,1]*matrix[1,2]*matrix[2,0] + matrix[0,2]*matrix[1,0]*matrix[2,1] - matrix[0,2]*matrix[1,1]*matrix[2,0] - matrix[0,0]*matrix[1,2]*matrix[2,1] - matrix[0,1]*matrix[1,0]*matrix[2,2];
        }
        if (determinant == 0)
        {
            throw new Exception("Визначник дорівнює нулю, далі обрахунки не можливі");
        }
        return determinant;
    }

    public static double[,] reverse(double[,] matrix)
    {
        double determinant = Operation.determinant(matrix);
        double[,] res = new double[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix.GetLength(0) == 2)
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
        return res;
    }

    public static double[,] division(double[,] firstMatrix, double[,] secondMatrix)
    {
        double[,] reverseMatrix = Operation.reverse(secondMatrix);
        return multiply(firstMatrix, reverseMatrix);
    }
}