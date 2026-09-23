namespace Task3;

class Operation
{
    public static int[,] add(int[,] matrixFirst, int[,] matrixSecond)
    {
        int[,] res = new int[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrixFirst[i, j] + matrixSecond[i, j];
        }

        return res;
    }

    public static int[,] difference(int[,] matrixFirst, int[,] matrixSecond)
    {
        int[,] res = new int[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
                res[i, j] = matrixFirst[i, j] - matrixSecond[i, j];
        }

        return res;
    }

    public static int determinant(int[,] matrix)
    {
        int determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        if (determinant == 0)
            throw new Exception("Визначник дорівнює 0");
        return determinant;
    }

    public static double[,] reverseMatrix(int[,] matrix)
    {
        int det = determinant(matrix);
        double[,] res = new double[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (i + j % 2 == 1)
                    res[i, j] = (double)-matrix[i, j] / det;
                res[i, i] = matrix[j-i, j-i]/det;
            }
        }

        return res;
    }

    public static T[,] multiply<T>(int[,] matrixFirst, T[,] matrixSecond)
    {
        T[,] res = new T[2, 2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                    res[i, j] = (T)((dynamic)res[i, j] + matrixFirst[i, k] * (dynamic)matrixSecond[k, j]);
            }
        }

        return res;
    }

    public static double[,] divide(int[,] matrixFirst, int[,] matrixSecond)
    {
        double[,] reverse = reverseMatrix(matrixSecond);
        return multiply(matrixFirst, reverse);
    }
}