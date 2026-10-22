public static class MatrixOperation
{
    public static double[,] OpProcessing(string op, double[,] a, double[,] b)
    {
        switch (op)
        {
            case "+":
                return Add(a, b);
            case "-":
                return Subtract(a, b);
            case "*":
                return Multiply(a, b);
            case "/":
                return Divide(a, b);
            default:
                throw new Exception($"Невідома операція: '{op}'");
        }
    }

    private static void CheckEqualDimensions(double[,] a, double[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            throw new InvalidOperationException("Розміри матриць мають повністю збігатися.");
    }

    public static double[,] Add(double[,] a, double[,] b)
    {
        CheckEqualDimensions(a, b);
        int r = a.GetLength(0), c = a.GetLength(1);
        var res = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = a[i, j] + b[i, j];

        return res;
    }

    public static double[,] Subtract(double[,] a, double[,] b)
    {
        CheckEqualDimensions(a, b);
        int r = a.GetLength(0), c = a.GetLength(1);
        var res = new double[r, c];

        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                res[i, j] = a[i, j] - b[i, j];

        return res;
    }

    public static double[,] Multiply(double[,] a, double[,] b)
    {
        int rA = a.GetLength(0), cA = a.GetLength(1);
        int rB = b.GetLength(0), cB = b.GetLength(1);

        if (cA != rB)
            throw new InvalidOperationException("Кількість стовпців матриці A повинна дорівнювати кількості рядків матриці B.");

        var res = new double[rA, cB];
        for (int i = 0; i < rA; i++)
        {
            for (int j = 0; j < cB; j++)
            {
                double sum = 0;
                for (int k = 0; k < cA; k++)
                    sum += a[i, k] * b[k, j];
                res[i, j] = sum;
            }
        }
        return res;
    }

    public static double[,] Divide(double[,] a, double[,] b)
    {
        if (b.GetLength(0) != b.GetLength(1))
            throw new InvalidOperationException("Матриця B повинна бути квадратною для операції ділення.");

        double[,] invB = Invert(b);
        if (invB == null)
            throw new InvalidOperationException("Матриця B є виродженою (визначник = 0), ділення неможливе.");

        return Multiply(a, invB);
    }

    private static double[,] Invert(double[,] matrix)
    {
        int size = matrix.GetLength(0);
        if (size != matrix.GetLength(1))
            throw new InvalidOperationException("Матриця для ділення (B) повинна бути квадратною.");

        double[,] augmented = new double[size, 2 * size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
                augmented[i, j] = matrix[i, j];
            augmented[i, size + i] = 1.0;
        }

        for (int i = 0; i < size; i++)
        {
            int pivotRow = i;
            for (int k = i + 1; k < size; k++)
            {
                if (Math.Abs(augmented[k, i]) > Math.Abs(augmented[pivotRow, i]))
                    pivotRow = k;
            }

            if (Math.Abs(augmented[pivotRow, i]) < 1e-9)
                throw new InvalidOperationException("Матриця B є виродженою (визначник = 0), ділення неможливе.");

            for (int j = 0; j < 2 * size; j++)
            {
                double tmp = augmented[i, j];
                augmented[i, j] = augmented[pivotRow, j];
                augmented[pivotRow, j] = tmp;
            }

            double div = augmented[i, i];
            for (int j = 0; j < 2 * size; j++)
                augmented[i, j] /= div;

            for (int k = 0; k < size; k++)
            {
                if (k != i)
                {
                    double factor = augmented[k, i];
                    for (int j = 0; j < 2 * size; j++)
                        augmented[k, j] -= factor * augmented[i, j];
                }
            }
        }

        var inv = new double[size, size];
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                inv[i, j] = augmented[i, size + j];

        return inv;
    }
}