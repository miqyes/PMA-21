namespace lab15._09;

public static class Vector
{
    private static void CheckDimensions(double[] a, double[] b)
    {
        if (a.Length != b.Length)
        {
            throw new InvalidOperationException($"Різна розмірність: {a.Length} і {b.Length}");
        }
    }

    public static double[] Add(double[] a, double[] b)
    {
        CheckDimensions(a, b);
        double[] res = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            res[i] = a[i] + b[i];
        }
        return res;
    }

    public static double[] Subtract(double[] a, double[] b)
    {
        CheckDimensions(a, b);
        double[] res = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            res[i] = a[i] - b[i];
        }
        return res;
    }

    public static double[] Multiply(double[] a, double[] b)
    {
        CheckDimensions(a, b);
        double[] res = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            res[i] = a[i] * b[i];
        }
        return res;
    }

    public static string Divide(double[] a, double[] b)
    {
        CheckDimensions(a, b);
        string[] items = new string[a.Length];

        for (int i = 0; i < a.Length; i++)
        {
            if (b[i] == 0)
            {
                items[i] = "-";
            }
            else
            {
                items[i] = Math.Round(a[i] / b[i], 2).ToString();
            }
        }

        return "(" + string.Join("; ", items) + ")";
    }

    public static string Format(double[] v)
    {
        return "(" + string.Join("; ", v) + ")";
    }
}