class VectorCalculator
{
    public static double[] Add(double[] v1, double[] v2)
    {
        double[] result = new double[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i] + v2[i];
        }
        return result;
    }

    public static double[] Subtract(double[] v1, double[] v2)
    {
        double[] result = new double[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i] - v2[i];
        }
        return result;
    }

    public static double[] Multiply(double[] v1, double[] v2)
    {
        double[] result = new double[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i] * v2[i];
        }
        return result;
    }

    public static double[] Divide(double[] v1, double[] v2)
    {
        double[] result = new double[v1.Length];
        for (int i = 0; i < v1.Length; i++)
        {
            result[i] = v1[i] / v2[i];
        }
        return result;
    }

    public static string ToString(double[] vector)
    {
        return "(" + string.Join(", ", vector) + ")";
    }
}