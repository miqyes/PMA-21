namespace Matrix;

public static class MatrixOperations
{
    public static int[,] Add(int[,] matA, int[,] matB)
    {
        int[,] result = new int[2, 2];
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 2; col++)
                result[row, col] = matA[row, col] + matB[row, col];
        }
        return result;
    }

    public static int[,] Subtract(int[,] matA, int[,] matB)
    {
        int[,] result = new int[2, 2];
        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 2; col++)
                result[row, col] = matA[row, col] - matB[row, col];
        }
        return result;
    }

    public static int GetDeterminant(int[,] mat)
    {
        int det = mat[0, 0] * mat[1, 1] - mat[0, 1] * mat[1, 0];
        if (det == 0)
            throw new InvalidOperationException("Визначник дорівнює 0, обернена матриця не існує.");
        
        return det;
    }

    public static double[,] InvertMatrix(int[,] mat)
    {
        int det = GetDeterminant(mat);
        double detInv = 1.0 / det;
        
        double[,] inverse = new double[2, 2];

        for (int row = 0; row < 2; row++)
        {
            for (int col = 0; col < 2; col++)
            {
                int minor = mat[1 - row, 1 - col];

                int sign = ((row + col) % 2 == 0) ? 1 : -1;
                double cofactor = sign * minor;

                inverse[col, row] = cofactor * detInv;
            }
        }

        return inverse; 
    }

    public static int[,] Multiply(int[,] matA, int[,] matB)
    {
        int[,] result = new int[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                    result[i, j] += matA[i, k] * matB[k, j];
            }
        }
        return result;
    }

    public static double[,] Multiply(int[,] matA, double[,] matB)
    {
        double[,] result = new double[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                    result[i, j] += matA[i, k] * matB[k, j];
            }
        }
        return result;
    }

    public static double[,] Divide(int[,] matA, int[,] matB)
    {
        double[,] invB = InvertMatrix(matB);
        return Multiply(matA, invB);
    }
}