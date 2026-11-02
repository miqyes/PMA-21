namespace Vector;

public static class VectorOperations
{
    private static void ValidateSameDimensions(int[] a, int[] b) // перевірка
    {
        if (a == null || b == null)
            throw new ArgumentNullException("Вектори не можуть бути null.");
        if (a.Length != b.Length)
            throw new InvalidOperationException("Розмірності векторів мають збігатися.");
    }
    
    public static int[] Add(int[] a, int[] b) // додавання
    {
        ValidateSameDimensions(a, b);
        int[] result = Enumerable.Range(0, a.Length)
            .Select(i => a[i] + b[i])
            .ToArray();
        return result;
        //int[] result = new int[a.Length];
        // for (int i = 0; i < a.Length; i++)
          //  result[i] = a[i] + b[i];
        //return result;
    }

    public static int[] Subtract(int[] a, int[] b) // віднімання
    {
        ValidateSameDimensions(a, b);
        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
            result[i] = a[i] - b[i];
        return result;
    }

    public static int[] Multiply(int[] a, int[] b) // множення
    {
        ValidateSameDimensions(a, b);
        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
            result[i] = a[i] * b[i];
        return result;
    }

    public static double[] Divide(int[] a, int[] b) // ділення
    {
        ValidateSameDimensions(a, b);
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (b[i] == 0)
                throw new DivideByZeroException($"Ділення на нуль у координаті {i + 1}.");
            result[i] = (double)a[i] / b[i];
        }
        return result;
    }
}