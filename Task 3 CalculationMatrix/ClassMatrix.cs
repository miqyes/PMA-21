class Matrix
{
    public static float[][] Add(float[][] firstMatrix, float[][] secondMatrix)
    {
        float[][] result = new float[2][];
        for (int i = 0; i < 2; i++)
        {
            result[i] = new float[2];
            for (int j = 0; j < 2; j++)
            {
                result[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
            }
        }
        return result;
    }
    public static float[][] Subtract(float[][] firstMatrix, float[][] secondMatrix)
    {
        float[][] result = new float[2][];
        for (int i = 0; i < 2; i++)
        {
            result[i] = new float[2];
            for (int j = 0; j < 2; j++)
            {
                result[i][j] = firstMatrix[i][j] - secondMatrix[i][j];
            }
        }
        return result;
    }

    public static float[][] Multiply(float[][] firstMatrix, float[][] secondMatrix)
    {
        float[][] result = new float[2][];
        for (int i = 0; i < 2; i++)
        {
            result[i] = new float[2];
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    result[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
                }
            }
        }
        return result;
    }

    public static float[][] InvertMatrix(float[][] matrix)
    {
        float determinant = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];


        if (determinant == 0)
        {
            throw new InvalidOperationException("Matrix is singular");
        }

        float[][] result = new float[2][];
        for (int i = 0; i < 2; i++)
        {
            result[i] = new float[2];
        }


        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if ((i + j) % 2 == 1)
                {
                    result[i][j] = -matrix[i][j];
                }
                if ((i + j) % 2 == 0)
                {
                    result[i][i] = matrix[j - i][j - i];
                }
            }
        }
        return result;
    }

    public static float[][] Divide(float[][] firstMatrix, float[][] secondMatrix)
    {
        return Multiply(firstMatrix, InvertMatrix(secondMatrix));
    }
}