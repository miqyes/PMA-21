namespace task_3;

using System.Globalization;

class vc
{
    public static double[] Add(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    public static double[] Subtract(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }

    public static double[] Multiply(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
        return result;
    }

    public static double[] Divide(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] / b[i];
        }
        return result;
    }

    public static bool HasZero(double[] vector)
    {
        foreach (double val in vector)
        {
            if (val == 0)
            {
                return true;
            }
        }
        return false;
    }

    public static string ToString(double[] vector)
    {
        string[] parts = new string[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            parts[i] = vector[i].ToString(CultureInfo.InvariantCulture);
        }
        return "(" + string.Join(", ", parts) + ")";
    }
}