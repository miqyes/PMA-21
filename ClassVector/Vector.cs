namespace ClassVector;

 public class Vector
    {

    private double[] coordinates;

    public Vector(double[] data)
    {
        coordinates = data;
    }
    
    public int GetLength()
    {
        return coordinates.Length;
    }

    private static void SameLength(Vector a, Vector b)
    {
        if (a.coordinates.Length != b.coordinates.Length)
        {
            throw new Exception("Different number of elements");
        }
    }

    public override string ToString()
    {
        return $"({string.Join(";", coordinates)})";
    }

    public static Vector operator +(Vector a, Vector b) 
    {
        SameLength(a, b);

        double[] result = new double[a.coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.coordinates[i] + b.coordinates[i];
        }
            return new Vector(result);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        SameLength(a, b);

        double[] result = new double[a.coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.coordinates[i] - b.coordinates[i];
        }
        return new Vector(result);
    }

    public static Vector operator *(Vector a, Vector b)
    {
        SameLength(a, b);

        double[] result = new double[a.coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = a.coordinates[i] * b.coordinates[i];
        }
        return new Vector(result);
    }

    public static Vector operator /(Vector a, Vector b)
    {
        SameLength(a, b);

        double[] result = new double[a.coordinates.Length];
        for (int i = 0; i < result.Length; i++)
        {
            if (b.coordinates[i] == 0)
            {
                throw new DivideByZeroException("division by zero is impossible at index" + i);
            }
            result[i] = a.coordinates[i] / b.coordinates[i];
        }
        return new Vector(result);
    }

}
