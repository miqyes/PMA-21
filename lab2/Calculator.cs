namespace Vector;

public static class Calculator
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
    
    public static double[] Sub(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
        return result;
    }
    
    public static double[] Mult(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
        return result;
    }

    public static double[] Div(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (b[i] == 0)
            {
                throw new DivideByZeroException();
            }

            result[i] = a[i] / b[i];
        }
        return result;
    }
}