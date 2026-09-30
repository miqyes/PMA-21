namespace matrix;

class Matrix
{
    public static double[,] add(double[,] matrixA, double[,] matrixB)
    {
        int colsA = matrixA.GetLength(1);
        int rowsA = matrixA.GetLength(0);
        int colsB = matrixB.GetLength(1);
        int rowsB = matrixB.GetLength(0);

        if (colsA != colsB || rowsA != rowsB)
        
        {
            return null;
           
        }
        double[,] matrixResult = new double[rowsA, colsA];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                matrixResult[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }
        return matrixResult;
    }

    public static double[,] subtraction(double[,] matrixA, double[,] matrixB)
    {
        int colsA = matrixA.GetLength(1);
        int rowsA = matrixA.GetLength(0);
        int colsB = matrixB.GetLength(1);
        int rowsB = matrixB.GetLength(0);

        if (colsA != colsB || rowsA != rowsB)
        {
            return null;
        }
        double[,] matrixResult = new double[rowsA, colsA];
        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                matrixResult[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }
        return matrixResult;
    }

    public static double[,] multiply(double[,] matrixA, double[,] matrixB)
    {
        int colsA = matrixA.GetLength(1);
        int rowsA = matrixA.GetLength(0);
        int colsB = matrixB.GetLength(1);
        int rowsB = matrixB.GetLength(0);

        if (colsA != rowsB)
        {
            return null;
        }
        double[,] matrixResult = new double[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                double s = 0;
                for (int t = 0; t < colsA; t++)
                {
                    s += matrixA[i, t] * matrixB[t, j];
                }
                matrixResult[i, j] = s;
            }
        }
        return matrixResult;
    }

    public static double determinant(double[,] matrix)
    {
        double det = 0;
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            return 0;
        }

        if (matrix.GetLength(0) == 1 && matrix.GetLength(1) == 1)
        {
            det = matrix[0, 0];
        }

        if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
        {
            det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        if (matrix.GetLength(0) == 3 && matrix.GetLength(1) == 3)
        {
            det = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] + matrix[0, 1] * matrix[1, 2] * matrix[2, 0] + matrix[0, 2] * matrix[1, 0] * matrix[2, 1] - matrix[0, 2] * matrix[1, 1] * matrix[2, 0] - matrix[0, 0] * matrix[1, 2] * matrix[2, 1] - matrix[0, 1] * matrix[1, 0] * matrix[2, 2];
        }
        return det;
    }
    public static double[,] reverse(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        if (n != matrix.GetLength(1))
        {
            return null;
        }

        double[,] matrixResult = new double[n,n];
        double det = determinant(matrix);
        if (det == 0)
        {
            return null;
        }
        if (n == 1)
        {
            matrixResult[0, 0] = 1 / det;
            return matrixResult;

        }
        
        if (n == 2)
        {
            matrixResult[0,0] = matrix[1,1] / det;
            matrixResult[0,1] = -matrix[0,1] / det;
            matrixResult[1,0] = -matrix[1,0] / det;
            matrixResult[1, 1] = matrix[0,0] / det;
            return matrixResult;
        }

        if (n == 3)
        {
           
                 matrixResult[0,0] = (matrix[1,1] * matrix[2,2] - matrix[1,2] * matrix[2,1]) / det; 
                 matrixResult[0,1] = (matrix[0,2] * matrix[2,1] - matrix[0,1] * matrix[2,2]) / det;
                 matrixResult[0,2] = (matrix[0,1] * matrix[1,2] - matrix[0,2] * matrix[1,1]) / det;
                 matrixResult[1,0] = (matrix[1,2] * matrix[2,0] - matrix[1,0] * matrix[2,2]) / det;
                 matrixResult[1,1] = (matrix[0,0] * matrix[2,2] - matrix[0,2] * matrix[2,0]) / det;
                 matrixResult[1,2] = (matrix[0,2] * matrix[1,0] - matrix[0,0] * matrix[1,2]) / det;
                 matrixResult[2,0] = (matrix[1,0] * matrix[2,1] - matrix[1,1] * matrix[2,0]) / det;
                 matrixResult[2,1] = (matrix[0,1] * matrix[2,0] - matrix[0,0] * matrix[2,1]) / det;
                 matrixResult[2,2] = (matrix[0,0] * matrix[1,1] - matrix[0,1] * matrix[1,0]) / det;
                 return matrixResult;
        }

        return null;
    }

    public static double[,] division(double[,] firstMatrix, double[,] secondMatrix)
    {
        double[,] reverseMatrix = Matrix.reverse(secondMatrix);

        if (reverseMatrix == null)
        {
            return null;
        }

        return multiply(firstMatrix, reverseMatrix);
    }
}
                    