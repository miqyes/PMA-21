public static class VectorMath
{
    public static double[] add(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
            return result;
    }

    public static double[] subtract(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a[i] - b[i];
        }
            return result;
    }

    public static double[] multiply(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a[i] * b[i];
        }
        return result;
    }

    public static double[] divide(double[] a, double[] b)
    {
        double[] result = new double[a.Length];
        
        for (int i = 0; i < result.Length; i++)
        {
            if (b[i] == 0)
            {
                throw new DivideByZeroException("division by zero is impossible at index" + i);
            }
            result[i] = a[i] / b[i];
        }
        return result;
    }
}
