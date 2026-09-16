class VectorCalculator
{
    public static double[] Add(double[] vectorOne, double[] vectorTwo)
    {
        double[] result = new double[vectorOne.Length];
        for (int i = 0; i < vectorOne.Length; i++)
        {
            result[i] = vectorOne[i] + vectorTwo[i];
        }
        return result;
    }

    public static double[] Subtract(double[] vectorOne, double[] vectorTwo)
    {
        double[] result = new double[vectorOne.Length];
        for (int i = 0; i < vectorOne.Length; i++)
        {
            result[i] = vectorOne[i] - vectorTwo[i];
        }
        return result;
    }

    public static double[] Multiply(double[] vectorOne, double[] vectorTwo)
    {
        double[] result = new double[vectorOne.Length];
        for (int i = 0; i < vectorOne.Length; i++)
        {
            result[i] = vectorOne[i] * vectorTwo[i];
        }
        return result;
    }

    public static double[] Divide(double[] vectorOne, double[] vectorTwo)
    {
        double[] result = new double[vectorOne.Length];
        for (int i = 0; i < vectorOne.Length; i++)
        {
            result[i] = vectorOne[i] / vectorTwo[i];
        }
        return result;
    }

    public static bool HasZero(double[] vector)
  {
    for (int i = 0; i < vector.Length; i++)
    {
      if (vector[i] == 0)
      {
        return true;
      }
    }
    return false;
  }

    public static string ToString(double[] vector)
    {
        return "(" + string.Join(", ", vector) + ")";
    }
}