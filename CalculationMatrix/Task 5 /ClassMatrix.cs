class Matrix
{
    public float[][] Values;
    public Matrix()
    {
        Values = new float[2][];
        for (int i = 0; i < 2; i++)
        {
            Values[i] = new float[2];
        }
    }

    public Matrix(float[][] values)
    {
        Values = values;
    }

    public Matrix Add(Matrix secondMatrix)
    {
        Matrix result = new Matrix();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result.Values[i][j] = Values[i][j] + secondMatrix.Values[i][j];
            }
        }
        return result;
    }

    public Matrix Subtract(Matrix secondMatrix)
    {
        Matrix result = new Matrix();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                result.Values[i][j] = Values[i][j] - secondMatrix.Values[i][j];
            }
        }
        return result;
    }

    public Matrix Multiply(Matrix secondMatrix)
    {
        Matrix result = new Matrix();
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    result.Values[i][j] += Values[i][k] * secondMatrix.Values[k][j];
                }
            }
        }
        return result;
    }

    public Matrix InvertMatrix()
    {
        float determinant = Values[0][0] * Values[1][1] - Values[0][1] * Values[1][0];

        if (determinant == 0)
        {
            throw new InvalidOperationException("Matrix is singular");
        }

        Matrix result = new Matrix();
        result.Values[0][0] = Values[1][1] / determinant;
        result.Values[0][1] = -Values[0][1] / determinant;
        result.Values[1][0] = -Values[1][0] / determinant;
        result.Values[1][1] = Values[0][0] / determinant;

        return result;
    }

    public Matrix Divide(Matrix secondMatrix)
    {
        return Multiply(secondMatrix.InvertMatrix());
    }

    public string ToString(int row)
    {
        return string.Join(" ", Values[row]);
    }

    public override string ToString()
    {
        return ToString(0) + "\n" + ToString(1);
    }
}
