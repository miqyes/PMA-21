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

    public static string[] Divide(double[] a, double[] b)
    {
        string[] result = new string[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (b[i] == 0)
            {
                result[i] = "-";
            }
            else
            {
                result[i] = FormatNumber(a[i] / b[i]);
            }
        }
        return result;
    }

    public static string ToString(double[] vector)
    {
        string[] parts = new string[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            parts[i] = FormatNumber(vector[i]);
        }
        return "(" + string.Join("; ", parts) + ")";
    }

    public static string ToString(string[] vector)
    {
        return "(" + string.Join("; ", vector) + ")";
    }

    private static string FormatNumber(double value)
    {
        return value.ToString(CultureInfo.InvariantCulture).Replace('.', ',');
    }
}