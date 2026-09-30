class Vector
{
    public float[] Values;

    public Vector(float[] values)
    {
        Values = values;
    }

    public int Length
    {
        get { return Values.Length; }
    }

    public static Vector Add(Vector first, Vector second)
    {
        if (first.Length != second.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }

        float[] result = new float[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first.Values[i] + second.Values[i];
        }
        return new Vector(result);
    }

    public static Vector Multiply(Vector vector, float scalar)
    {
        float[] result = new float[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = vector.Values[i] * scalar;
        }
        return new Vector(result);
    }

    public static Vector Division(Vector vector, float scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException();
        }

        float[] result = new float[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = vector.Values[i] / scalar;
        }
        return new Vector(result);
    }

    public static Vector Subtract(Vector first, Vector second)
    {
        if (first.Length != second.Length)
        {
            throw new ArgumentException("Vectors must have the same length");
        }

        float[] result = new float[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            result[i] = first.Values[i] - second.Values[i];
        }
        return new Vector(result);
    }

    public override string ToString()
    {
        return "(" + string.Join(", ", Values) + ")";
    }
}